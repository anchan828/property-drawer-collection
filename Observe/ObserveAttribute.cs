using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif 
public class ObserveAttribute : PropertyAttribute
{
    public string[] callbackNames;

    public ObserveAttribute(params string[] callbackNames)
    {
        this.callbackNames = callbackNames;
    }
}


#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ObserveAttribute))]
public class ObserveDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginChangeCheck();
        EditorGUI.PropertyField(position, property, label);
        if (EditorGUI.EndChangeCheck())
        {
            if (IsMonoBehaviour(property))
            {

                MonoBehaviour mono = (MonoBehaviour)property.serializedObject.targetObject;

                foreach (var callbackName in observeAttribute.callbackNames)
                {
                    mono.Invoke(callbackName, 0);
                }

            }
        }
    }

    bool IsMonoBehaviour(SerializedProperty property)
    {
        return property.serializedObject.targetObject.GetType().IsSubclassOf(typeof(MonoBehaviour));
    }

    ObserveAttribute observeAttribute
    {
        get
        {
            return (ObserveAttribute)attribute;
        }
    }
}
#endif