using UnityEngine;

public class ObserveExample : MonoBehaviour
{
    [Observe("Callback")] 
    public string
        hoge;

    [Observe("Callback", "Callback2")] 
    public Test
        test;

    public enum Test
    {
        Hoge,
        Fuga
    }

    public void Callback ()
    {
        Debug.Log ("call");
    }

    private void Callback2 ()
    {
        Debug.Log ("call2");
    }
}
