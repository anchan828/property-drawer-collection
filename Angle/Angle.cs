using UnityEngine;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// Angle attribute.
/// see: http://forum.unity3d.com/threads/angle-property-drawer.236359/
/// </summary>
public class AngleAttribute : PropertyAttribute
{
	public float min = -1, max = -1;

	public AngleAttribute ()
	{
	}

	public AngleAttribute (float min, float max)
	{
		this.min = min;
		this.max = max;
	}
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(AngleAttribute))]
public class AngleDrawer : PropertyDrawer
{
	private AngleAttribute angleAttribute{get{return (AngleAttribute)attribute;}}

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.indentLevel++;
		if(property.propertyType == SerializedPropertyType.Float)
			property.floatValue = FloatAngle (position,label, property.floatValue,-1,angleAttribute.min,angleAttribute.max);
		else
			EditorGUI.PropertyField(position,property);
	}

	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		float height = base.GetPropertyHeight (property, label);
		return property.propertyType != SerializedPropertyType.Float ? height:height * 2 + 4;
	}

	private static Texture2D GetTexture (string path)
	{
		return AssetDatabase.LoadAssetAtPath (path, typeof(Texture2D)) as Texture2D;
	}

	#region FloatAngle

	private static Texture2D _Knob, _KnobBack;
	private static Vector2 mousePosition;
	
	private static Texture2D Knob { 
		get {
			if (_Knob == null)
				_Knob = GetTexture (Path.Combine(currentFolderPath, "Knob.png"));
			return _Knob;
		} 
	}
	
	private static Texture2D KnobBack { 
		get {
			if (_KnobBack == null) 
				_KnobBack = GetTexture (Path.Combine(currentFolderPath , "KnobBack.png"));
			return _KnobBack;
		} 
	}

	static string currentFolderPath
    {
        get
        {
            var currentFilePath = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            return "Assets" + currentFilePath.Substring(0, currentFilePath.LastIndexOf(Path.DirectorySeparatorChar) + 1).Replace(Application.dataPath.Replace("/", Path.DirectorySeparatorChar.ToString()), string.Empty).Replace("\\", "/");
        }
    }

	private static float FloatAngle (Rect rect,GUIContent label, float value)
	{
		return FloatAngle (rect,label, value, 1, -1, -1);
	}
	
	private static float FloatAngle (Rect rect,GUIContent label, float value, float snap)
	{
		return FloatAngle (rect,label, value, snap, -1, -1);
	}
	
	private static float FloatAngle (Rect rect,GUIContent label, float value, float snap, float min, float max)
	{
		int id = GUIUtility.GetControlID (FocusType.Native, rect);
		
		Rect knobRect = new Rect (rect.x + rect.height * 3, rect.y, rect.height, rect.height);
		
		float delta;
		if (min != max)
			delta = ((max - min) / 360);
		else
			delta = 1;
		
		if (Event.current != null) {
			if (Event.current.type == EventType.MouseDown && knobRect.Contains (Event.current.mousePosition)) {
				GUIUtility.hotControl = id;
				mousePosition = Event.current.mousePosition;
			} else if (Event.current.type == EventType.MouseUp && GUIUtility.hotControl == id)
				GUIUtility.hotControl = 0;
			else if (Event.current.type == EventType.MouseDrag && GUIUtility.hotControl == id) {
				Vector2 move = mousePosition - Event.current.mousePosition;
				value += delta * (-move.x - move.y);
				
				if (snap > 0) {
					float mod = value % snap;
					
					if (mod < (delta * 3) || Mathf.Abs (mod - snap) < (delta * 3))
						value = Mathf.Round (value / snap) * snap;
				}
				
				mousePosition = Event.current.mousePosition;
				GUI.changed = true;
			}
		}
		Matrix4x4 matrix = GUI.matrix;
		
		if (min != max)
			GUIUtility.RotateAroundPivot (value * (360 / (max - min)), knobRect.center);
		else
			GUIUtility.RotateAroundPivot (value, knobRect.center);

		if (Event.current.type == EventType.Repaint) {
			GUI.DrawTexture (knobRect, KnobBack);
			GUI.DrawTexture (knobRect, Knob);
		}

		GUI.matrix = matrix;

		Rect labeltRect = new Rect (0, rect.y + (rect.height / 2) - 9, rect.width, EditorGUIUtility.singleLineHeight + 2);
		EditorGUI.LabelField(labeltRect,label);
		Rect floatRect = new Rect (rect.x + (rect.height * 4) + 4, rect.y + (rect.height / 2) - 9, 50,  EditorGUIUtility.singleLineHeight + 2);
		value = EditorGUI.FloatField (floatRect, value);
		
		if (min != max)
			value = Mathf.Clamp (value, min, max);
		
		return value;
	}
	#endregion FloatAngle
}
#endif