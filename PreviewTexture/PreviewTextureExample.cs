using UnityEngine;
using System.Collections;

public class PreviewTextureExample : MonoBehaviour
{
    [PreviewTexture(60)]
    public string
        textureURL = "http://placekitten.com/200/150";

    [PreviewTexture]
    public Texture hoge;
}
