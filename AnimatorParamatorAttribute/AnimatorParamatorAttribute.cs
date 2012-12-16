using UnityEngine;
using System.Collections;

/// <summary>
/// Animator paramator attribute.
/// </summary>
public class AnimatorParamatorAttribute : PropertyAttribute
{
    /// <summary>
    /// パラメータの型。デフォルトでは型を考慮しない
    /// </summary>
    public ParamatorType paramatorType = ParamatorType.None;

    /// <summary>
    /// 現在選択中のindex
    /// </summary>
    public int selectedValue = 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="AnimatorParamatorAttribute"/> class.
    /// </summary>
    public AnimatorParamatorAttribute ()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AnimatorParamatorAttribute"/> class.
    /// </summary>
    /// <param name='paramatorType'>
    /// 型を指定して選択肢たい場合に設定する
    /// </param>
    public AnimatorParamatorAttribute (ParamatorType paramatorType)
    {
        this.paramatorType = paramatorType;
    }

    /// <summary>
    /// 型のタイプ。型指定をしたい時に使用する
    /// </summary>
    public enum ParamatorType
    {
        Vector = 0,
        Float = 1,
        Int = 3,
        Bool = 4,
        None = 9999
    }
}