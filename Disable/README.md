Disable
==========================

編集不可にします

![](https://dl.dropboxusercontent.com/u/153254465/screenshot/JBQBIC-LURHER-OAVDFV-TKMOGD-GTAKLD-FXFDYA-HZRHFP-EHXGNY-NLWBMA-LHLBGA-CWMMOB-JVECUS-XPMJUS-XRCFZS-2013-11-07_at_2.47.29.png)



```
using UnityEngine;

public class DisableExample : MonoBehaviour
{
    [Disable]
    public string hoge = "hoge";

    [Disable]
    public int fuga = 1;

    [Disable]
    public AudioType audioType = AudioType.ACC;
}
```