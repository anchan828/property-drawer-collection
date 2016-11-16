using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using System.IO;
#endif 
public class PreviewTextureAttribute : PropertyAttribute
{
    public Rect lastPosition = new Rect (0, 0, 0, 0);
    public long expire = 6000000000; // 10min
    public WWW www;
    public Texture2D cached;

    public PreviewTextureAttribute ()
    {

    }

    public PreviewTextureAttribute (int expire)
    {
        this.expire = expire * 1000 * 10000;
    }
}


#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(PreviewTextureAttribute))]
public class PreviewTextureDrawer : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        position.height = 16;
        if (property.propertyType == SerializedPropertyType.String)
        {
            DrawStringValue(position, property, label);
        }
        else if (property.propertyType == SerializedPropertyType.ObjectReference)
        {
            DrawTextureValue(position, property, label);
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + previewTextureAttribute.lastPosition.height;
    }

    PreviewTextureAttribute previewTextureAttribute
    {
        get { return (PreviewTextureAttribute)attribute; }
    }

    void DrawTextureValue(Rect position, SerializedProperty property, GUIContent label)
    {
        property.objectReferenceValue = (Texture2D)EditorGUI.ObjectField(position, label, property.objectReferenceValue, typeof(Texture2D), false);

        if (property.objectReferenceValue != null)
            DrawTexture(position, (Texture2D)property.objectReferenceValue);
    }

    void DrawStringValue(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginChangeCheck();
        property.stringValue = EditorGUI.TextField(position, label, property.stringValue);
        if (EditorGUI.EndChangeCheck())
        {
            previewTextureAttribute.www = null;
            previewTextureAttribute.cached = null;
        }
        string path = GetCachedTexturePath(property.stringValue);

        if (!string.IsNullOrEmpty(path))
        {
            if (IsExpired(path))
            {
                Delete(path);
            }
            else if (previewTextureAttribute.cached == null)
                previewTextureAttribute.cached = GetTextureFromCached(path);
        }
        else
            previewTextureAttribute.cached = null;

        if (previewTextureAttribute.cached == null)
        {
            previewTextureAttribute.cached = GetTextureFromWWW(position, property);
        }
        else
            DrawTexture(position, previewTextureAttribute.cached);
    }

    bool IsExpired(string path)
    {
        string fileName = Path.GetFileNameWithoutExtension(path);
        string[] split = fileName.Split('_');
        return System.DateTime.Now.Ticks >= long.Parse(split[1]);
    }

    string GetCachedTexturePath(string stringValue)
    {
        int hash = stringValue.GetHashCode();
        foreach (string path in Directory.GetFiles("Temp"))
        {
            if (Path.GetFileNameWithoutExtension(path).StartsWith(hash.ToString()))
            {
                return path;
            }
        }
        return string.Empty;
    }

    Texture2D GetTextureFromWWW(Rect position, SerializedProperty property)
    {
        if (previewTextureAttribute.www == null)
        {
            previewTextureAttribute.www = new WWW(property.stringValue);
        }
        else if (!previewTextureAttribute.www.isDone)
        {
            previewTextureAttribute.lastPosition = new Rect(position.x, position.y + 16, position.width, 16);
            EditorGUI.ProgressBar(previewTextureAttribute.lastPosition, previewTextureAttribute.www.progress, "Downloading... " + (previewTextureAttribute.www.progress * 100) + "%");
        }
        else if (previewTextureAttribute.www.isDone)
        {

            if (previewTextureAttribute.www.error != null)
                return null;

            int hash = property.stringValue.GetHashCode();
            long expire = (System.DateTime.Now.Ticks + previewTextureAttribute.expire);
            File.WriteAllBytes(string.Format("Temp/{0}_{1}_{2}_{3}", hash, expire, previewTextureAttribute.www.texture.width, previewTextureAttribute.www.texture.height), previewTextureAttribute.www.bytes);
            return previewTextureAttribute.www.texture;
        }
        return null;
    }

    Texture2D GetTextureFromCached(string path)
    {
        string[] split = Path.GetFileNameWithoutExtension(path).Split('_');
        int width = int.Parse(split[2]);
        int height = int.Parse(split[3]);
        Texture2D t = new Texture2D(width, height);

        return t.LoadImage(File.ReadAllBytes(path)) ? t : null;
    }

    private GUIStyle style;

    void DrawTexture(Rect position, Texture2D texture)
    {
        float width = Mathf.Clamp(texture.width, position.width * 0.7f, position.width * 0.7f);
        previewTextureAttribute.lastPosition = new Rect(position.width * 0.15f, position.y + 16, width, texture.height * (width / texture.width));

        if (style == null)
        {
            style = new GUIStyle();
            style.imagePosition = ImagePosition.ImageOnly;
        }
        style.normal.background = texture;
        GUI.Label(previewTextureAttribute.lastPosition, "", style);
    }

    void Delete(string path)
    {
        File.Delete(path);
        previewTextureAttribute.cached = null;
    }
}

#endif