using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Animatorウィンドウにあるパラメータをスクリプトでタイプセーフに扱うためのPropertyDrawer
/// </summary>
/// <exception cref='InvalidCastException'>
/// Is thrown when an explicit conversion (casting operation) fails because the source type cannot be converted to the
/// destination type.
/// </exception>
/// <exception cref='MissingComponentException'>
/// Is thrown when the missing component exception.
/// </exception>
[CustomPropertyDrawer(typeof(AnimatorParamaterAttribute))]
public class AnimatorParamaterDrawer : PropertyDrawer
{
    public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
    {
        AnimatorController animatorController = GetAnimatorController (property);
        if( animatorController == null)return;
        int eventCount = animatorController.GetEventCount ();

        if (eventCount == 0)
        {
            Debug.LogWarning ("AnimationParamater is 0");
            property.stringValue = string.Empty;
            return;
        }

        List<string> eventNames = new List<string> ();

        for (int i = 0; i < eventCount; i++)
        {
            if (CanAddEventName (animatorController, i) == false)
            {
                continue;
            }
            eventNames.Add (animatorController.GetEventName (i));
        }

        if (eventNames.Count == 0)
        {
            Debug.LogWarning (string.Format ("{0} Paramater is 0", animatorParamaterAttribute.paramaterType));
            property.stringValue = string.Empty;
            return;
        }

        string[] eventNamesArray = eventNames.ToArray ();

        int matchIndex = eventNames.FindIndex (eventName => eventName.Equals (property.stringValue));

        if (matchIndex != -1)
        {
            animatorParamaterAttribute.selectedValue = matchIndex;
        }

        animatorParamaterAttribute.selectedValue = EditorGUI.IntPopup (position, label.text, animatorParamaterAttribute.selectedValue, eventNamesArray, SetOptionValues (eventNamesArray));

        property.stringValue = eventNamesArray [animatorParamaterAttribute.selectedValue];

    }

    /// <summary>
    /// Gets the animator controller.
    /// </summary>
    /// <returns>
    /// The animator controller.
    /// </returns>
    /// <param name='property'>
    /// Property.
    /// </param>

    AnimatorController GetAnimatorController (SerializedProperty property)
    {
        Component component = property.serializedObject.targetObject as Component;

        if (component == null)
        {
            throw new InvalidCastException ("Couldn't cast targetObject");
        }

        Animator anim = component.GetComponent<Animator> ();
        if (anim == null)
        {
            Debug.LogException(new MissingComponentException ("Missing Aniamtor Component"));
            return null;
        }

        AnimatorController animatorController = AnimatorController.GetAnimatorController (anim);
        return animatorController;
    }

    /// <summary>
    /// Determines whether this instance can add event name the specified animatorController index.
    /// </summary>
    /// <returns>
    /// <c>true</c> if this instance can add event name the specified animatorController i; otherwise, <c>false</c>.
    /// </returns>
    /// <param name='animatorController'>
    /// If set to <c>true</c> animator controller.
    /// </param>
    /// <param name='index'>
    /// If set to <c>true</c> index.
    /// </param>

    bool CanAddEventName (AnimatorController animatorController, int index)
    {
        return !(animatorParamaterAttribute.paramaterType != AnimatorParamaterAttribute.ParamaterType.None
                 && animatorController.GetEventType (index) != (int)animatorParamaterAttribute.paramaterType);
    }

    /// <summary>
    /// Sets the option values.
    /// </summary>
    /// <returns>
    /// The option values.
    /// </returns>
    /// <param name='eventNames'>
    /// Event names.
    /// </param>
    int[] SetOptionValues (string[] eventNames)
    {
        int[] optionValues = new int[eventNames.Length];
        for (int i = 0; i < eventNames.Length; i++)
        {
            optionValues [i] = i;
        }
        return optionValues;
    }

    AnimatorParamaterAttribute animatorParamaterAttribute
    {
        get
        {
            return (AnimatorParamaterAttribute)attribute;
        }
    }

}
