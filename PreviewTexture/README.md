PreviewTexture
==========================

テクスチャのプレビューを表示します。

###引数

|変数|説明|
|---|---|
|expire|有効期限。URLから取得してきた画像をキャッシュする時間。デフォルトは10分|

###使い方

```
using UnityEngine;

public class PreviewTextureAttributeExample : MonoBehaviour
{
    //60秒キャッシュする
    [PreviewTexture(60)]
    public string textureURL = "https://www.hogehoge.com/image.png";

    [PreviewTexture]
    public Texture hoge;
}
```