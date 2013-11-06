using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif 
public class TooltipAttribute : PropertyAttribute
{

    public string tooltip;

    public TooltipAttribute(string tooltip)
    {
        this.tooltip = tooltip;
    }
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(TooltipAttribute))]
public class TooltipDrawer : PropertyDrawer
{
    TooltipAttribute tooltipAttribute
    {
        get
        {
            return (TooltipAttribute) attribute;
        }
    }


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (!string.IsNullOrEmpty(tooltipAttribute.tooltip))
        {
            label.tooltip = tooltipAttribute.tooltip;
        }

        EditorGUI.PropertyField(position, property, label);
    }
}
#endif