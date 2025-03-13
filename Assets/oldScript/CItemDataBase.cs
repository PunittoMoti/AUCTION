using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "CreateItemDataBase")]
public class CItemDataBase : ScriptableObject
{
    //アイテムデータのリスト
    [SerializeField] List<CItemData> items = new List<CItemData>();

    //アイテムデータ参照
    public CItemData GetItemData(int Number)
    {
        return items[Number];
    }

}
