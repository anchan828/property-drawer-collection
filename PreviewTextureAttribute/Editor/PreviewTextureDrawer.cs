using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(PreviewTextureAttribute))]
public class PreviewTextureDrawer : PropertyDrawer
{
	
	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{
	
		SerializedProperty serializedProperty = GetSerializedProperty (property);
		
		if (serializedProperty != null) {
			property.objectReferenceValue = (Texture)EditorGUI.ObjectField (position, label, serializedProperty.objectReferenceValue, typeof(Texture), false);
			position.y += 16;
			position.x = position.width * 0.15f;
			position.width *= 0.7f;
			position.height = position.width;
			previewTextureAttribute.lastPosition = position;
		} 
		
		if (property.objectReferenceValue != null) {
			EditorGUI.DrawPreviewTexture (position, (Texture)property.objectReferenceValue);
		} else {
			previewTextureAttribute.lastPosition = new Rect (0, 0, 0, 0);
		}
	}
	
	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		
		float height = 0;
		
		if (previewTextureAttribute.lastPosition != new Rect (0, 0, 0, 0)) {
			height = previewTextureAttribute.lastPosition.width;
		}
		
		return base.GetPropertyHeight (property, label) + height;
	}
	
	SerializedProperty GetSerializedProperty (SerializedProperty property)
	{
		return property.serializedObject.FindProperty (property.propertyPath);
	}
	
	PreviewTextureAttribute previewTextureAttribute {
		get {
			return (PreviewTextureAttribute)attribute;
		}
	}
}
