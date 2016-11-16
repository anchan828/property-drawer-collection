Popup
==========================


![](https://raw.github.com/anchan828/file-place/master/property-drawer-collection/%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B7%E3%83%A7%E3%83%83%E3%83%88%202013-04-06%202.12.05.png)


###使い方

```
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
```
