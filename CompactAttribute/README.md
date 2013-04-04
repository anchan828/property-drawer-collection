CompactAttribute
==========================

プロパティをコンパクトにして表示します。

![](https://raw.github.com/anchan828/file-place/master/property-drawer-collection/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202013-04-04%2021.00.25.png)

↓↓↓

![](https://raw.github.com/anchan828/file-place/master/property-drawer-collection/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202013-04-04%2020.59.46.png)

対応しているのは以下の通り

```
using UnityEngine;
using System.Collections;

public class CompactAttributeExample : MonoBehaviour
{
	[Compact]
	public Vector2 vector2;
	[Compact]
	public Vector3 vector3;
	[Compact]
	public Vector4 vector4;
	[Compact]
	public Rect rect;
	[Compact]
	public Quaternion quaternion;
	[Compact]
	public Bounds bounds;
}
```