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
