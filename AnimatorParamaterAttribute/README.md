AnimatorParamaterAttribute
==========================

Animatorウィンドウにあるパラメータ **名** をタイプセーフにフィールドにアタッチすることができます。

![](http://d3j5vwomefv46c.cloudfront.net/photos/large/702796338.png?key=48097&Expires=1355649945&Key-Pair-Id=APKAIYVGSUJFNRFZBBTA&Signature=PNhnGUw8pATXYatWFqWED1fyNiNPmPb~DxnuCM5AetStU4HpzE14PmUnAxtwStiVsW~hZnwYvQ6kJ-EG-lEsVgleY7FxL7LKSL5-UqmRwVhxXCIIPHXX~Z657blExzsRRtU--vOceYCjOHf7moUKxTuLUhgFiw1L0EJ~9~JLR5M_)

###引数

|変数|説明|
|---|---|
|paramaterType|型を指定して選択したい場合に設定する|

###使い方

```
using UnityEngine;
using System.Collections;

public class AnimatorParamaterAttributeExample : MonoBehaviour
{
	//型指定なし
	[AnimatorParamater]
	public string param;
	
	//Vectorのみ
	[AnimatorParamater(AnimatorParamaterAttribute.ParamaterType.Vector)]
	public string vectortParam;
	
	//Floatのみ
	[AnimatorParamater(AnimatorParamaterAttribute.ParamaterType.Float)]
	public string floatParam;
	
	//Intのみ
	[AnimatorParamater(AnimatorParamaterAttribute.ParamaterType.Int)]
	public string intParam;
	
	//Boolのみ
	[AnimatorParamater(AnimatorParamaterAttribute.ParamaterType.Bool)]
	public string boolParam;
}

```
