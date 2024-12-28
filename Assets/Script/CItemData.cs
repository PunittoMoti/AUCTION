using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemStatus;

[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class CItemData : ScriptableObject
{
    [SerializeField] string mName;                  //アイテム名
    [SerializeField] int mPrice;                    //値段
    [SerializeField] ITEMSTATUS mItemStatus;        //アイテムの種類
    [SerializeField] string mItemText;              //アイテム説明
    [SerializeField] Sprite mIcon;                  //アイコン
    [SerializeField] GameObject mCatalogPrefab;     //カタログのPrefab　※ITEMSTATUSがカタログのみ使用

    //アイテム名取得
    public string GetItemName()
    {
        return mName;
    }

    //値段取得
    public int GetItemPrice()
    {
        return mPrice;
    }

    //種類取得
    public ITEMSTATUS GetItemStatus()
    {
        return mItemStatus;
    }

    //アイテムテキスト取得
    public string GetItemText()
    {
        return mItemText;
    }

    //アイテムアイコン取得
    public Sprite GetItemIcon()
    {
        return mIcon;
    }

    //カタログだった場合Prefab取得
    public GameObject GetCatalogPrefab()
    {
        return mCatalogPrefab;
    }
}
