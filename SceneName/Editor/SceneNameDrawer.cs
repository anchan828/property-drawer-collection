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
    
        string[] sceneNames = GetEnabledSceneNames ();
    
        if (sceneNames.Length == 0) {
            EditorGUI.LabelField (position, ObjectNames.NicifyVariableName (property.name), "Scene is Empty");
            return;
        }
    
        int[] sceneNumbers = new int[sceneNames.Length];
    
        SetSceneNambers (sceneNumbers, sceneNames);
    
        if (!string.IsNullOrEmpty (property.stringValue))
            sceneNameAttribute.selectedValue = GetIndex (sceneNames, property.stringValue);
   
        sceneNameAttribute.selectedValue = EditorGUI.IntPopup (position, label.text, sceneNameAttribute.selectedValue, sceneNames, sceneNumbers);
    
        property.stringValue = sceneNames [sceneNameAttribute.selectedValue];
    }

    string[] GetEnabledSceneNames ()
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

    int GetIndex (string[] sceneNames, string sceneName)
    {
        int result = 0;
        for (int i = 0; i < sceneNames.Length; i++) {
            if (sceneName == sceneNames [i]) {
                result = i;
                break;
            }
        }
        return result;
    }
}
