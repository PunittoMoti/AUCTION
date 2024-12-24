using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemStatus;

public class CItemObject : MonoBehaviour
{
    string mName;                  //アイテム名
    int mPrice;                    //値段
    ITEMSTATUS mItemStatus;        //アイテムの種類
    string mItemText;              //アイテム説明

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
        return mName;
    }

    //アイテムデータの取得
    public void SetItemData(CItemData item)
    {
        mName = item.GetItemName();
        mPrice = item.GetItemPrice();
        mItemStatus = item.GetItemStatus();
        mItemText = item.GetItemText();
    }


}