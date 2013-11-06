AnimatorParameter
==========================

Animatorウィンドウにあるパラメータ名をタイプセーフにフィールドにアタッチすることができます。


![](https://dl.dropboxusercontent.com/u/153254465/screenshot/JPUWSF-KDAAXR-WYWUOZ-RRNJKS-VIHIIR-UABGAM-XROUNH-OXWCVT-DWUJND-NJFUPS-KVMSXL-YNPGLA-WSMIUE-OVSNRG-XZVILP-XOXYJH-QZFYRX-OPKORW-OINPCM-YZSBNP-ZZVAZL-EQPWCN-KYPNCD-OYUUTE-NDEWFH-ZIPULW-ZEINFI-IICHRK-KYXTVL-QGNAFO-WMRBCU-RXMZTE-2013-11-07_at_2.32.21.png)

###引数

|変数|説明|
|---|---|
|parameterType|型を指定して選択したい場合に設定する|

###使い方

```
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorParameterExample : MonoBehaviour
{
    [AnimatorParameter]
    public string param;
    [AnimatorParameter(AnimatorParameterAttribute.ParameterType.Float)]
    public string floatParam;
    [AnimatorParameter(AnimatorParameterAttribute.ParameterType.Int)]
    public string intParam;
    [AnimatorParameter(AnimatorParameterAttribute.ParameterType.Bool)]
    public string boolParam;
    [AnimatorParameter(AnimatorParameterAttribute.ParameterType.Trigger)]
    public string triggerParam;


    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float f = animator.GetFloat(floatParam);

        int i = animator.GetInteger(intParam);

        bool b = animator.GetBool(boolParam);

        animator.SetTrigger(triggerParam);
    }
}
```
