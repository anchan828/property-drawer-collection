using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using System;
#endif 
public class XTransitionAttribute : PropertyAttribute
{
	public int selectedValue;
	
	public XTransitionAttribute ()
	{
		
	}
}


#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(XTransitionAttribute))]
public class XTransitionDrawer : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType != SerializedPropertyType.String)
        {
            return;
        }
        PresetName presetName = PresetName.FadeIn;
        if (string.IsNullOrEmpty(property.stringValue) == false)
        {
            presetName = (PresetName)Enum.Parse(typeof(PresetName), property.stringValue, true);
        }

        presetName = (PresetName)EditorGUI.EnumPopup(position, label, presetName);

        property.stringValue = presetName.ToString();

    }


    enum PresetName
    {
        FadeIn,
        FadeOut,
        AfterImage,
        Distort04,
        Distort01,
        Distort02,
        Distort03,
        FadeInOutMask,
        Slide01,
        Slide02,
        Slide03,
        Slide04,
        Slide05,
        Slide06,
        Slide07,
        Slide08,
        Slide09,
        ScaleOut01,
        ScaleOut02,
        ScaleOut03,
        ScaleOut04,
        ScaleOut05,
        ScaleOut06,
        ScaleOut07,
        ScaleOut08,
        ScaleOut09,
        ScaleOut10,
        ScaleOut11,
        ScaleOut12,
        ScaleOut13,
        ScaleOut14
    }
}

#endif