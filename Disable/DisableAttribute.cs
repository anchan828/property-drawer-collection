using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class DisableAttribute : PropertyAttribute {
}

#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(DisableAttribute))]
public class DisableDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginDisabledGroup(true);
        EditorGUI.PropertyField(position, property, label);
        EditorGUI.EndDisabledGroup();
    }
}

#endif