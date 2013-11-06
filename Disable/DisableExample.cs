using UnityEngine;

public class DisableExample : MonoBehaviour
{
    [Disable] public string hoge = "hoge";

    [Disable] public int fuga = 1;

    [Disable] public AudioType audioType = AudioType.ACC;
}
