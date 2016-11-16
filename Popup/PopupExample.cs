using UnityEngine;
using System.Collections;

public class PopupExample : MonoBehaviour
{
    [Popup("Hoge","Fuga","Foo","Bar")]
    public string popup;
    [Popup(1,2,3,4,5,6)]
    public int popup2;
    [Popup(1.5f,2.3f,3.4f,4.5f,5.6f,6.7f)]
    public float popup3;
}
