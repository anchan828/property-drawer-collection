LabelSearch
==========================

ラベル名からアセットを検索しフィールドにアタッチすることができます。

###引数

|変数|説明|
|---|---|
|labelName|検索したいラベル名|
|limit|最大検索数 ( 配列で使用 )|
|direction|アセット名で降順か昇順か ( デフォルトは昇順 ) |

###一応使えるもの

|変数|説明|
|---|---|
|init|falseで検索が完了していなくても、とりあえずインスペクターを表示するようになる。trueだと検索が終わるまでインスペクターが表示されない。デフォルトはfalse|
|canPrintLabelName|trueでインスペクターにラベル名を表示する。デフォルトはfalse|
|foldout|インスペクターを表示した時、最初から配列のフィールドを描画したい場合trueにする。デフォルトはfalse|

###使い方

```
using UnityEngine;
using System.Collections;

/// <summary>
/// Label attribute example.
/// </summary>
public class LabelSearchExample : MonoBehaviour
{

    //ラベル名TestがついたMaterial型の検索
    //昇順で最初にヒットしたアセットをアタッチする
    [LabelSearch( "Test" )]
    public Material materials2;

    
    //ラベル名TestがついたMaterial型の検索
    //降順で最初にヒットしたアセットをアタッチする
    [LabelSearch( "Test", LabelSearchAttribute.Direction.DESC )]
    public Material materials;

    //ラベル名TestがついたGameObject型の配列検索
    //昇順でヒットした全てのアセットをアタッチする
    [LabelSearch( "Test"  )]
    public GameObject[] prefab;

    //ラベル名TestがついたTexture2D型の配列検索
    //昇順で最大3件のアセットをアタッチする
    [LabelSearch( "Test", 3 )]
    public Texture2D[] textures;
    
    //ラベル名TestがついたTexture2D型の配列検索
    //降順で最大3件のアセットをアタッチする
    [LabelSearch( "Test", 3, LabelSearchAttribute.Direction.DESC )]
    public Texture2D[] textures2;
	

}

```

###問題点

AngryBotsくらいのアセットの量になるとUnity起動後(またはコンパイル後)の初回検索に1.5s位かかってしまう
初回以外は0.005sとかなり高速