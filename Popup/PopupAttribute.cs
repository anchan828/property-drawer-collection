using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using System;
#endif 
public class PopupAttribute : PropertyAttribute
{
    public object[] list;
    
    public PopupAttribute (params object[] list)
    {
        this.list = list;
    }
}


#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(PopupAttribute))]
public class PopupDrawer : PropertyDrawer
{

    private Action<int> setValue;
    private Func<int, int> validateValue;
    private string[] _list = null;

    private string[] list
    {
        get
        {
            if (_list == null)
            {
                _list = new string[popupAttribute.list.Length];
                for (int i = 0; i < popupAttribute.list.Length; i++)
                {
                    _list[i] = popupAttribute.list[i].ToString();
                }
            }
            return _list;
        }
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (validateValue == null && setValue == null)
            SetUp(property);


        if (validateValue == null && setValue == null)
        {
            base.OnGUI(position, property, label);
            return;
        }

        int selectedIndex = 0;

        for (int i = 0; i < list.Length; i++)
        {
            selectedIndex = validateValue(i);
            if (selectedIndex != 0)
                break;
        }

        EditorGUI.BeginChangeCheck();
        selectedIndex = EditorGUI.Popup(position, label.text, selectedIndex, list);
        if (EditorGUI.EndChangeCheck())
        {
            setValue(selectedIndex);
        }
    }

    void SetUp(SerializedProperty property)
    {
        if (variableType == typeof(string))
        {

            validateValue = (index) =>
            {
                return property.stringValue == list[index] ? index : 0;
            };

            setValue = (index) =>
            {
                property.stringValue = list[index];
            };
        }
        else if (variableType == typeof(int))
        {

            validateValue = (index) =>
            {
                return property.intValue == Convert.ToInt32(list[index]) ? index : 0;
            };

            setValue = (index) =>
            {
                property.intValue = Convert.ToInt32(list[index]);
            };
        }
        else if (variableType == typeof(float))
        {
            validateValue = (index) =>
            {
                return property.floatValue == Convert.ToSingle(list[index]) ? index : 0;
            };
            setValue = (index) =>
            {
                property.floatValue = Convert.ToSingle(list[index]);
            };
        }

    }

    PopupAttribute popupAttribute
    {
        get { return (PopupAttribute)attribute; }
    }

    private Type variableType
    {
        get
        {
            return popupAttribute.list[0].GetType();
        }
    }
}

#endif