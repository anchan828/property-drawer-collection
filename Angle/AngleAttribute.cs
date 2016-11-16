using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using System.Reflection;
#endif

/// <summary>
/// Angle attribute.
/// </summary>
public class AngleAttribute : PropertyAttribute
{
    public float min = -1, max = -1;
    public string unit = string.Empty;
    public Color backgroundColor = Color.gray, activeColor = Color.red;
    public bool showValue = true;
    public float knobSize = 32;
    public AngleAttribute()
    {
    }

    public AngleAttribute(float min, float max)
    {
        this.min = min;
        this.max = max;
    }

    public AngleAttribute(float min, float max, string unit)
        : this(min, max)
    {
        this.unit = unit;
    }

    public AngleAttribute(float min, float max, string unit, Color backgroundColor)
        : this(min, max, unit)
    {
        this.backgroundColor = backgroundColor;
    }

    public AngleAttribute(float min, float max, string unit, Color backgroundColor, Color activeColor)
        : this(min, max, unit, backgroundColor)
    {
        this.activeColor = activeColor;
    }

    public AngleAttribute(float min, float max, string unit, Color backgroundColor, Color activeColor, bool showValue)
        : this(min, max, unit, backgroundColor, activeColor)
    {
        this.showValue = showValue;
    }

    public AngleAttribute(float min, float max, string unit, Color backgroundColor, Color activeColor, bool showValue, float knobSize)
        : this(min, max, unit, backgroundColor, activeColor, showValue)
    {
        this.knobSize = knobSize;
    }
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(AngleAttribute))]
public class AngleDrawer : PropertyDrawer
{
    private AngleAttribute angleAttribute { get { return (AngleAttribute)attribute; } }

    private readonly MethodInfo knobMethodInfo = typeof(EditorGUI).GetMethod("Knob",
        BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType == SerializedPropertyType.Float)
        {
            using (new EditorGUI.PropertyScope(position, label, property))
            {
                EditorGUI.LabelField(position, label);
                var knobRect = new Rect(position);
                knobRect.x += EditorGUIUtility.labelWidth;
                property.floatValue = Knob(knobRect, Vector2.one * angleAttribute.knobSize, property.floatValue, angleAttribute.min,
               angleAttribute.max, angleAttribute.unit, angleAttribute.backgroundColor, angleAttribute.activeColor, angleAttribute.showValue);
            }
        }
        else
            EditorGUI.PropertyField(position, property, label);
    }

    private float Knob(Rect position, Vector2 knobSize, float currentValue, float start, float end, string unit, Color backgroundColor, Color activeColor, bool showValue)
    {
        var invoke = knobMethodInfo.Invoke(null, new object[] { position, knobSize, currentValue, start, end, unit, backgroundColor, activeColor, showValue, GUIUtility.GetControlID("Knob".GetHashCode(), FocusType.Passive, position) });
        return (float)(invoke ?? 0);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var height = base.GetPropertyHeight(property, label);
        return property.propertyType != SerializedPropertyType.Float ? height : angleAttribute.knobSize + 4;
    }
}
#endif