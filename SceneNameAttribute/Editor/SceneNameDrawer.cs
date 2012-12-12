using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections.Generic;

[CustomPropertyDrawer(typeof(SceneNameAttribute))]
public class SceneNameDrawer : PropertyDrawer
{
	
	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{
		SceneNameAttribute sceneNameAttribute = (SceneNameAttribute)attribute;
		
		string[] sceneNames = GetSceneNames ();
		
		if (sceneNames.Length == 0) {
			return;
		}
		
		int[] sceneNumbers = new int[sceneNames.Length];
		
		SetSceneNambers (sceneNumbers, sceneNames);
		
		sceneNameAttribute.selectedValue = EditorGUI.IntPopup (position, label.text, sceneNameAttribute.selectedValue, sceneNames, sceneNumbers);
		
		property.stringValue = sceneNames [sceneNameAttribute.selectedValue];
	}

	string[] GetSceneNames ()
	{
		List<EditorBuildSettingsScene> scenes = EditorBuildSettings.scenes.Where (scene => scene.enabled).ToList ();
		
		HashSet<string> sceneNames = new HashSet<string> ();
		scenes.ForEach (scene => {
			sceneNames.Add (scene.path.Substring (scene.path.LastIndexOf ("/") + 1).Replace (".unity", string.Empty));
		});
		return sceneNames.ToArray ();
	}

	void SetSceneNambers (int[] sceneNumbers, string[] sceneNames)
	{
		for (int i =0; i<sceneNames.Length; i++) {
			sceneNumbers [i] = i;
		}
	}
}
