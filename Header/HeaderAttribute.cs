using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif 

public class HeaderAttribute : PropertyAttribute
{
		public string headerText;
		public string text;

		public HeaderAttribute (string header)
		{
				headerText = header;
		}
		public HeaderAttribute (string header, string text)
		{
				headerText = header;
				this.text = text;
		}
}


#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(HeaderAttribute))]
public class HeaderDrawer : PropertyDrawer
{
    const int HeaderHeight = 23, TextHeight = 17, LineHeight = 2;
    const int HeaderY = 10, LineX = 15;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        position.y += HeaderY;
        position.height = HeaderHeight;

        //DrawHeader
        EditorGUI.LabelField(position, headerAttribute.headerText, headerStyle);

        if (!string.IsNullOrEmpty(headerAttribute.text))
        {
            position.y += HeaderHeight - 4;
            EditorGUI.LabelField(position, headerAttribute.text, EditorStyles.largeLabel);
        }

        position.y += string.IsNullOrEmpty(headerAttribute.text) ? HeaderHeight : TextHeight;
        position.x += LineX;
        position.height = LineHeight;
        GUI.Box(position, "");
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + HeaderHeight + (string.IsNullOrEmpty(headerAttribute.text) ? 0 : TextHeight);
    }

    HeaderAttribute headerAttribute
    {
        get
        {
            return (HeaderAttribute)attribute;
        }
    }

    static GUIStyle headerStyle
    {
        get
        {
            GUIStyle style = new GUIStyle(EditorStyles.largeLabel);
            style.fontStyle = FontStyle.Bold;
            style.fontSize = 18;
            style.normal.textColor = EditorGUIUtility.isProSkin ? new Color(0.7f, 0.7f, 0.7f, 1f) : new Color(0.4f, 0.4f, 0.4f, 1f);
            return style;
        }
    }
}

#endif