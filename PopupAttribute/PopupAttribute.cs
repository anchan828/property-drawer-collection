using UnityEngine;

public class PopupAttribute : PropertyAttribute
{
    public object[] list;
    
    public PopupAttribute (params object[] list)
    {
        this.list = list;
    }
}
