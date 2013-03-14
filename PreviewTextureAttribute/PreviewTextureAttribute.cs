using UnityEngine;
using System.Collections;

public class PreviewTextureAttribute : PropertyAttribute
{
    public Rect lastPosition = new Rect (0, 0, 0, 0);
    public long expire = 6000000000; // 10min
    public WWW www;
    public Texture cached;

    public PreviewTextureAttribute ()
    {

    }

    public PreviewTextureAttribute (int expire)
    {
        this.expire = expire * 1000 * 10000;
    }
}
