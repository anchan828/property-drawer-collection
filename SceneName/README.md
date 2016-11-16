SceneName
==========================

有効なシーン名をPopupで選択することができます。

Attributeは必ずstringにつけてください。

###使い方

```
using UnityEngine;

public class SceneNameExample : MonoBehaviour
{
	[SceneName]
	public string sceneName;

    [SceneName(false)]
    public string sceneName2;
}

```
