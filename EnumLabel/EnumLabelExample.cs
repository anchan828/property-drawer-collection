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
