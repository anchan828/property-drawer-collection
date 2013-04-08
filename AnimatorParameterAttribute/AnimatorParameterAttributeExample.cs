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
