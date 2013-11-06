using UnityEngine;

public class SceneNameExample : MonoBehaviour
{
	[SceneName]
	public string sceneName;

    [SceneName(false)]
    public string sceneName2;
}
