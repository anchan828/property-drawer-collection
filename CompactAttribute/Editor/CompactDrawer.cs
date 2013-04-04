using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

[CustomPropertyDrawer(typeof(CompactAttribute))]
public class CompactDrawer : PropertyDrawer
{
	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUIUtility.LookLikeControls ();
		EditorGUI.BeginChangeCheck ();
		switch (property.type) {
		case "Vector2f":
			{
				Vector2 v2 = EditorGUI.Vector2Field (position, label.text, property.vector2Value);
				if (EditorGUI.EndChangeCheck ()) {
					property.vector2Value = v2;
				}
				break;
			}
		case "Vector3f":
			{
				Vector3 v3 = EditorGUI.Vector3Field (position, label.text, property.vector3Value);
				if (EditorGUI.EndChangeCheck ()) {
					property.vector3Value = v3;
				}
				break;
			}
		case "Vector4f":
			{
				float x = GetProperty (property, "x").floatValue;
				float y = GetProperty (property, "y").floatValue;
				float z = GetProperty (property, "z").floatValue;
				float w = GetProperty (property, "w").floatValue;
				Vector4 v4 = EditorGUI.Vector4Field (position, label.text, new Vector4 (x, y, z, w));
				if (EditorGUI.EndChangeCheck ()) {
					GetProperty (property, "x").floatValue = v4.x;
					GetProperty (property, "y").floatValue = v4.y;
					GetProperty (property, "z").floatValue = v4.z;
					GetProperty (property, "w").floatValue = v4.w;
				}
				break;
			}
		case "Rectf":
			{
				Rect r = property.rectValue = EditorGUI.RectField (position, label, property.rectValue);
				if (EditorGUI.EndChangeCheck ()) {
					property.rectValue = r;
				}
				break;
			}
		case "Quaternionf":
			{
				Quaternion q = property.quaternionValue;
				Vector4 v4 = EditorGUI.Vector4Field (position, label.text, new Vector4 (q.x, q.y, q.z, q.w));
				if (EditorGUI.EndChangeCheck ()) {
					property.quaternionValue = new Quaternion (v4.x, v4.y, v4.z, v4.w);
				}
				break;
			}
		case "AABB":
			{
				Bounds b = EditorGUI.BoundsField (position, label, property.boundsValue);
				if (EditorGUI.EndChangeCheck ()) {
					property.boundsValue = b;
				}
				break;
			}
		default:
			{
				EditorGUI.LabelField (position, label.text, "Not Implemented");
				EditorGUI.EndChangeCheck ();
				break;
			}
		}
		
	}

	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		return base.GetPropertyHeight (property, label) + GetHeight (property);
	}
	
	private const float SingleLineHeight = 16f;
	
	private static float GetHeight (SerializedProperty property)
	{
		float height = 0;
		switch (property.type) {
		case "Vector2f":
		case "Vector3f":
		case "Vector4f":
		case "Quaternionf":
			height = SingleLineHeight;
			break;
		case "Rectf":
		case "AABB":
			height = SingleLineHeight * 2;
			break;
		default:
			break;
		}
		return height;
	}
	
	private static SerializedProperty GetProperty (SerializedProperty property, string name)
	{
		return property.FindPropertyRelative (name);
	}
}
