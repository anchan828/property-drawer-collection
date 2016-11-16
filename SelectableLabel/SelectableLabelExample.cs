using UnityEngine;


public class SelectableLabelExample : MonoBehaviour
{
    [SelectableLabel("ラベルを選択できるようになります\n" +
                     "\thttps://github.com/anchan828/property-drawer-collection\n" +
                     "\t\tこのようにURLをコピペすると気に便利")]
    public string hoge;
}
