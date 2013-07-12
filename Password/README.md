Password
==========================

パスワードをマスク('*')表示します。

Attributeは必ずstringにつけてください。

###使い方

```
using UnityEngine;
using System.Collections;

public class PasswordExample : MonoBehaviour
{
	[Password]
	public string pass;
	[Password( 3, 6 )]
	public string pass2;
	[Password( 3, false )]
	public string pass3;
	[Password( 5, 6, false )]
	public string pass4;
}

```