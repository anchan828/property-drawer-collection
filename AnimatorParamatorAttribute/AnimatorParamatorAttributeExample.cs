using UnityEngine;
using System.Collections;

public class AnimatorParamatorAttributeExample : MonoBehaviour
{
	[AnimatorParamator]
	public string param;
	[AnimatorParamator(AnimatorParamatorAttribute.ParamatorType.Vector)]
	public string vectortParam;
	[AnimatorParamator(AnimatorParamatorAttribute.ParamatorType.Float)]
	public string floatParam;
	[AnimatorParamator(AnimatorParamatorAttribute.ParamatorType.Int)]
	public string intParam;
	[AnimatorParamator(AnimatorParamatorAttribute.ParamatorType.Bool)]
	public string boolParam;
}
