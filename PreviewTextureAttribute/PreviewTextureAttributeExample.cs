using UnityEngine;
using System.Collections;

public class PreviewTextureAttributeExample : MonoBehaviour
{

	[PreviewTexture]
	public Texture2D texture;
	[PreviewTexture]
	public Texture2D texture2;
}
