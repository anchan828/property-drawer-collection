using UnityEngine;
using System.Collections;

/// <summary>
/// Label attribute example.
/// </summary>
public class LabelSearchExample : MonoBehaviour
{


    /// <summary>
    /// <para>ラベル名TestがついたMaterial型の検索</para>
    /// <para>該当するもの全て取得</para>
    /// </summary>
    [LabelSearch("Sky", LabelSearchAttribute.Direction.DESC)]
    public Material materials;

    [LabelSearch("Test")]
    public Material materials2;

    [LabelSearch("Test", 3 )]
    public GameObject[] prefab;
	
	[LabelSearch("Test", 3 )]
    public Texture2D[] textures;
	
    [LabelSearch("Test", 3, LabelSearchAttribute.Direction.DESC)]
    public GameObject prefab2;
	

}
