EnumLabel
==========================

![](https://raw.github.com/anchan828/file-place/master/property-drawer-collection/Screen%20Shot%202013-07-28%20at%2022.32.21.png)

Enumの表示名を変更する

###引数

|変数|説明|
|---|---|
|text|変更する文字列|

###使い方

```
using UnityEngine;

public class EnumLabelExample : MonoBehaviour
{
    public enum Example
    {
        [EnumLabel("テスト")]
        HIGH,
        [EnumLabel("その２")]
        LOW
    }

    [EnumLabel("例")]
    public Example test = Example.HIGH;
}

```