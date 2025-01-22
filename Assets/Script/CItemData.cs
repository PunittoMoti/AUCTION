using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemStatus;

[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class CItemData : ScriptableObject
{
    [SerializeField] string mName;                  //アイテム名
    [SerializeField] int mPrice;                    //価格
    [SerializeField] int mPriceupvalue;             //上昇価格
    [SerializeField] int mSellvalue;                //売却価格
    [SerializeField] ITEMSTATUS mItemStatus;        //アイテムの種類
    [SerializeField] string mItemtext;              //アイテム説明（概要）
    [SerializeField] string mItemsecrettext;        //アイテム説明（詳細）
    [SerializeField] string mReadtext;              //アイテム紹介
    [SerializeField] Sprite mIcon;                  //アイコン
    [SerializeField] GameObject mCatalogPrefab;     //カタログのPrefab　※ITEMSTATUSがカタログのみ使用

    //アイテム名取得
    public string GetItemName()
    {
        return mName;
    }

    //価格取得
    public int GetItemPrice()
    {
        return mPrice;
    }

    //上昇価格取得
    public int GetPriceUpValue()
    {
        return mPriceupvalue;
    }

    //売却価格取得
    public int GetSellvalue()
    {
        return mSellvalue;
    }


    //種類取得
    public ITEMSTATUS GetItemStatus()
    {
        return mItemStatus;
    }

    //アイテムテキスト（概要）取得
    public string GetItemText()
    {
        return mItemtext;
    }

    //アイテムテキスト(詳細)取得
    public string GetItemSecretText()
    {
        return mItemsecrettext;
    }



    //アイテム紹介テキスト取得
    public string GetReadText()
    {
        return mReadtext;
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
