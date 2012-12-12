using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(PasswordAttribute))]
public class PasswordDrawer : PropertyDrawer
{
	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{
		if (!IsSupported (property)) {
			return;
		}
		
		string password = property.stringValue;
		int maxLength = passwordAttribute.maxLength;
		
		if (property.stringValue.Length > maxLength) {
			password = password.Substring (0, maxLength);
		}

		if (!passwordAttribute.useMask) {
			property.stringValue = EditorGUI.TextField (position, label, password);
		} else {
			property.stringValue = EditorGUI.PasswordField (position, label, password);
		}
		
		if (IsValid (property)) {
			DrawHelpBox (position);
		}
	}

	void DrawHelpBox (Rect position)
	{
		position.x += 10;
		position.y += 16;
		position.width -= 10;
		position.height -= 20;
		EditorGUI.HelpBox (position, string.Format ("Password must contain at least {0} characters!", passwordAttribute.minLength), MessageType.Error);
	}
	
	bool IsSupported (SerializedProperty property)
	{
		return property.propertyType == SerializedPropertyType.String;
	}
	
	bool IsValid (SerializedProperty property)
	{
		return property.stringValue.Length < passwordAttribute.minLength;
	}
	
	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		if (IsSupported (property)) {
			if (property.stringValue.Length < passwordAttribute.minLength) {
				return base.GetPropertyHeight (property, label) + 30;
			}
		}
		return base.GetPropertyHeight (property, label);
	}

	PasswordAttribute passwordAttribute {
		get {
			return (PasswordAttribute)attribute;
		}
	}
	
}
