using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SelectableLabelAttribute))]
public class SelectableLabelDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.SelectableLabel(position, selectableLabelAttribute.text);
    }

    private SelectableLabelAttribute selectableLabelAttribute
    {
        get
        {
            return (SelectableLabelAttribute)attribute;
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {


        return selectableLabelAttribute.text.Split('\n').Length * base.GetPropertyHeight(property, label);
    }
}
