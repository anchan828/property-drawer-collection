using UnityEngine;
using System.Collections;

public class PreviewTextureExample : MonoBehaviour
{
    [PreviewTexture(60)]
    public string
        textureURL = "https://www.hogehoge.com/image.png";

    [PreviewTexture]
    public Texture hoge;
}
