SelectableLabel
==========================

![](https://raw.github.com/anchan828/file-place/master/property-drawer-collection/Screen%20Shot%202013-07-28%20at%2022.45.03.png)

Enumの表示名を変更する

###引数

|変数|説明|
|---|---|
|text|追加する文字列|

###使い方

```
using UnityEngine;


public class SelectableLabelExample : MonoBehaviour
{
    [SelectableLabel("ラベルを選択できるようになります\n" +
                     "\thttps://github.com/anchan828/property-drawer-collection\n" +
                     "\t\tこのようにURLをコピペするときに便利")]
    public string hoge;
}
```