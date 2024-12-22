using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemStatus;

public class CItemObject : MonoBehaviour
{
    [SerializeField] string mName;                  //アイテム名
    [SerializeField] int mPrice;                    //値段
    [SerializeField] ITEMSTATUS mItemStatus;        //アイテムの種類
    [SerializeField] string mItemText;              //アイテム説明

/*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
*/

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

}