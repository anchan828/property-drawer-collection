using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif 
public class Vector3FieldAttribute : PropertyAttribute {

}


#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(Vector3FieldAttribute))]
public sealed class Vector3FieldDrawer : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUIUtility.LookLikeControls();

        if (property.propertyType == SerializedPropertyType.Vector3)
        {
            property.vector3Value = EditorGUI.Vector3Field(position, label.text, property.vector3Value);
        }
        else if (property.propertyType == SerializedPropertyType.Vector2)
        {
            property.vector2Value = EditorGUI.Vector2Field(position, label.text, property.vector2Value);
        }
        else
            EditorGUI.LabelField(position, label.text, "Use Compact with Vector3 or Vector2.");
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + 30;
    }

}

#endif