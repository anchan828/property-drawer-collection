using UnityEngine;

public class AngleExample : MonoBehaviour
{
    [Angle(0, 360)]
    public float angle;

    [Angle(0, 360, knobSize = 64f)]
    public float angle2;
}
