using UnityEngine;
using System.Collections;

public class AnimatorParamaterAttributeExample : MonoBehaviour
{
	[AnimatorParamater]
	public string param;
	[AnimatorParamater(AnimatorParamaterAttribute.ParamaterType.Vector)]
	public string vectortParam;
	[AnimatorParamater(AnimatorParamaterAttribute.ParamaterType.Float)]
	public string floatParam;
	[AnimatorParamater(AnimatorParamaterAttribute.ParamaterType.Int)]
	public string intParam;
	[AnimatorParamater(AnimatorParamaterAttribute.ParamaterType.Bool)]
	public string boolParam;
}
