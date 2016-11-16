using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Animations;
using System;
using System.Collections.Generic;
#endif

/// <summary>
/// Animator Paramater attribute.
/// </summary>
public class AnimatorParameterAttribute : PropertyAttribute
{
    /// <summary>
    /// パラメータの型。デフォルトでは型を考慮しない
    /// </summary>
    public ParameterType parameterType = ParameterType.None;

    /// <summary>
    /// 現在選択中のindex
    /// </summary>
    public int selectedValue = 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="AnimatorParameterAttribute"/> class.
    /// </summary>
    public AnimatorParameterAttribute () : this(ParameterType.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AnimatorParameterAttribute"/> class.
    /// </summary>
    /// <param name='ParamaterType'>
    /// 型を指定して選択肢たい場合に設定する
    /// </param>
    public AnimatorParameterAttribute (ParameterType parameterType)
    {
        this.parameterType = parameterType;
    }
 
    /// <summary>
    /// 型のタイプ。型指定をしたい時に使用する
    /// </summary>
    public enum ParameterType
    {
        Float = 1,
        Int = 3,
        Bool = 4,
        Trigger = 9,
        None = 9999,
    }
}

#if UNITY_EDITOR

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
[CustomPropertyDrawer(typeof(AnimatorParameterAttribute))]
public class AnimatorParameterDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var animatorController = GetAnimatorController(property);

        if (animatorController == null)
        {
            DefaultInspector(position, property, label);
            return;
        }
        var parameters = animatorController.parameters;

        if (parameters.Length == 0)
        {
            Debug.LogWarning("AnimationParamater is 0");
            property.stringValue = string.Empty;
            DefaultInspector(position, property, label);
            return;
        }

        var eventNames = parameters
            .Where(t => CanAddEventName(t.type))
            .Select(t => t.name).ToList();

        if (eventNames.Count == 0)
        {
            Debug.LogWarning(string.Format("{0} Parameter is 0", animatorParameterAttribute.parameterType));
            property.stringValue = string.Empty;
            DefaultInspector(position, property, label);
            return;
        }

        var eventNamesArray = eventNames.ToArray();

        var matchIndex = eventNames
            .FindIndex(eventName => eventName.Equals(property.stringValue));

        if (matchIndex != -1)
        {
            animatorParameterAttribute.selectedValue = matchIndex;
        }

        animatorParameterAttribute.selectedValue = EditorGUI.IntPopup(position, label.text, animatorParameterAttribute.selectedValue, eventNamesArray, SetOptionValues(eventNamesArray));

        property.stringValue = eventNamesArray[animatorParameterAttribute.selectedValue];

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

    AnimatorController GetAnimatorController(SerializedProperty property)
    {
        var component = property.serializedObject.targetObject as Component;

        if (component == null)
        {
            throw new InvalidCastException("Couldn't cast targetObject");
        }

        var anim = component.GetComponent<Animator>();

        if (anim == null)
        {
            Debug.LogException(new MissingComponentException("Missing Aniamtor Component"));
            return null;
        }

       return anim.runtimeAnimatorController as AnimatorController;
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

    bool CanAddEventName(AnimatorControllerParameterType animatorControllerParameterType)
    {
        return !(animatorParameterAttribute.parameterType != AnimatorParameterAttribute.ParameterType.None
                 && (int)animatorControllerParameterType != (int)animatorParameterAttribute.parameterType);
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
    int[] SetOptionValues(string[] eventNames)
    {
        int[] optionValues = new int[eventNames.Length];
        for (int i = 0; i < eventNames.Length; i++)
        {
            optionValues[i] = i;
        }
        return optionValues;
    }

    AnimatorParameterAttribute animatorParameterAttribute
    {
        get
        {
            return (AnimatorParameterAttribute)attribute;
        }
    }

    void DefaultInspector(Rect position, SerializedProperty property, GUIContent label)
    {
            EditorGUI.PropertyField(position, property, label);
    }
}

#endif