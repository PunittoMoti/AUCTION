using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static ItemStatus;

public class CItemObject : MonoBehaviour
{
    string mName;                  //アイテム名
    int mPrice;                    //値段
    ITEMSTATUS mItemStatus;        //アイテムの種類
    string mItemText;              //アイテム説明
    Sprite mIcon;                  //アイコン

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


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

    //アイテムアイコン取得
    public Sprite GetItemIcon()
    {
        return mIcon;
    }


    //アイテムデータの取得
    public void SetItemData(CItemData item)
    {
        mName = item.GetItemName();
        mPrice = item.GetItemPrice();
        mItemStatus = item.GetItemStatus();
        mItemText = item.GetItemText();
        mIcon = item.GetItemIcon();

        //取得した物を適用
        transform.Find("Canvas/Name").gameObject.GetComponent<TMP_Text>().text = mName;
        transform.Find("Icon").gameObject.GetComponent<SpriteRenderer>().sprite = mIcon;

    }

    //アイテムオブジェクトデータの取得
    public void SetItemObject(CItemObject item)
    {
        mName = item.GetItemName();
        mPrice = item.GetItemPrice();
        mItemStatus = item.GetItemStatus();
        mItemText = item.GetItemText();
        mIcon = item.GetItemIcon();

        //取得した物を適用
        transform.Find("Canvas/Name").gameObject.GetComponent<TMP_Text>().text = mName;
        transform.Find("Icon").gameObject.GetComponent<SpriteRenderer>().sprite = mIcon;

    }

    //アイテムオブジェクトデータの削除
    public void RemoveItemObject()
    {
        mName = "----";
        mPrice = 0;
        mItemStatus = ITEMSTATUS.EMPTY;
        mItemText = "----";
        mIcon = null ;

        //取得した物を適用
        transform.Find("Canvas/Name").gameObject.GetComponent<TMP_Text>().text = mName;
        transform.Find("Icon").gameObject.GetComponent<SpriteRenderer>().sprite = mIcon;

    }



}