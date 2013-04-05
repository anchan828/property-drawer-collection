using UnityEngine;

public class PopupAttribute : PropertyAttribute
{
    public string[] names;
    
    public PopupAttribute (params string[] names)
    {
        this.names = names;
    }
}
