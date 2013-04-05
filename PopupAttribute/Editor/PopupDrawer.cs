using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(PopupAttribute))]
public class PopupDrawer : PropertyDrawer
{
 
    
    public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
    {
        if (popupAttribute.names.Length == 0 || property.propertyType != SerializedPropertyType.String) {
            base.OnGUI (position, property, label);
            return;
        }
        
        int selectedIndex = 0;
        for (int i = 0; i < popupAttribute.names.Length; i++) {
            if (popupAttribute.names [i] == property.stringValue) {
                selectedIndex = i;
                break;
            }
        }
        
        EditorGUI.BeginChangeCheck ();
        selectedIndex = EditorGUI.Popup (position, label.text, selectedIndex, popupAttribute.names);
        if (EditorGUI.EndChangeCheck ()) {
            property.stringValue = popupAttribute.names [selectedIndex];
        }
        
    }
    
    PopupAttribute popupAttribute {
        get{ return (PopupAttribute)attribute;}
    }
}
