HeaderAttribute
==========================

![](https://raw.github.com/anchan828/file-place/master/property-drawer-collection/Screen%20Shot%202013-07-12%20at%2017.55.30.png)

Headerとして機能するPropertyDrawer

###引数

|変数|説明|
|---|---|
|header|ヘッダーとして表示される文字列|
|text|ヘッダーの下に表示される文字列|

###使い方

```
using UnityEngine;

public class HeaderAttributeExample : MonoBehaviour
{
		[Header("初期設定","最初にこんな感じでHeaderをつける")]
		public string hoge;
		
		public string hogehoge;
		public AnimationCurve curve;

		[Header("武器パラメータ","そうすることで見やすくなるね！")]
		public string hoge2;
		[Range(0,10)]
		public int intttt;
		public AnimationCurve curve2;
}
```