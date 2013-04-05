using UnityEngine;
using System.Collections;

/// <summary>
/// Animator Paramater attribute.
/// </summary>
public class AnimatorParamaterAttribute : PropertyAttribute
{
    /// <summary>
    /// パラメータの型。デフォルトでは型を考慮しない
    /// </summary>
    public ParamaterType paramaterType = ParamaterType.None;

    /// <summary>
    /// 現在選択中のindex
    /// </summary>
    public int selectedValue = 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="AnimatorParamaterAttribute"/> class.
    /// </summary>
    public AnimatorParamaterAttribute () : this(ParamaterType.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AnimatorParamaterAttribute"/> class.
    /// </summary>
    /// <param name='ParamaterType'>
    /// 型を指定して選択肢たい場合に設定する
    /// </param>
    public AnimatorParamaterAttribute (ParamaterType ParamaterType)
    {
        this.paramaterType = ParamaterType;
    }
 
    public AnimatorParamaterAttribute (string paramaterName)
    {
       Debug.Log(this.TypeId.GetType());
    }
    
    /// <summary>
    /// 型のタイプ。型指定をしたい時に使用する
    /// </summary>
    public enum ParamaterType
    {
        Vector = 0,
        Float = 1,
        Int = 3,
        Bool = 4,
        None = 9999
    }
}