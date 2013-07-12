using UnityEngine;
using System.Collections;

public class HeaderAttributeExample : MonoBehaviour
{
		[Header("Header","text text text text... ")]
		public string
				hoge;

		public string hogehoge;
		public AnimationCurve curve;

		[Header("Header2","text text text text... ")]
		public string
				hoge2;
	
		public string hogehoge2;
		public AnimationCurve curve2;
}
