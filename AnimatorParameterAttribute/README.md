AnimatorParameterAttribute
==========================

Animatorウィンドウにあるパラメータ **名** をタイプセーフにフィールドにアタッチすることができます。

![](http://d3j5vwomefv46c.cloudfront.net/photos/large/702796338.png?key=48097&Expires=1355649945&Key-Pair-Id=APKAIYVGSUJFNRFZBBTA&Signature=PNhnGUw8pATXYatWFqWED1fyNiNPmPb~DxnuCM5AetStU4HpzE14PmUnAxtwStiVsW~hZnwYvQ6kJ-EG-lEsVgleY7FxL7LKSL5-UqmRwVhxXCIIPHXX~Z657blExzsRRtU--vOceYCjOHf7moUKxTuLUhgFiw1L0EJ~9~JLR5M_)

###引数

|変数|説明|
|---|---|
|parameterType|型を指定して選択したい場合に設定する|

###使い方

```
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class AnimatorParameterAttributeExample : MonoBehaviour
{
    [AnimatorParameter]
    public string param;
    [AnimatorParameter(AnimatorParameterAttribute.ParameterType.Vector)]
    public string vectortParam;
    [AnimatorParameter(AnimatorParameterAttribute.ParameterType.Float)]
    public string floatParam;
    [AnimatorParameter(AnimatorParameterAttribute.ParameterType.Int)]
    public string intParam;
    [AnimatorParameter(AnimatorParameterAttribute.ParameterType.Bool)]
    public string boolParam;
}
```
