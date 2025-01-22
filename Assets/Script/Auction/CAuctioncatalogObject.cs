using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CAuctioncatalogObject : MonoBehaviour
{
    CAuctionManager mAuctionManager;    //オークションシーンのGameManager
    List<CItemData> mItemdates;         //アイテムリスト
    Image mItemicon;                    //アイテム画像
    TMP_Text mItemname;                 //アイテム名
    TMP_Text mItemprice;                //開始価格
    TMP_Text mItempriceup;              //上昇価格
    TMP_Text mItemsell;                 //売却価格
    TMP_Text mItemtext;                 //アイテムテキスト（概要）
    TMP_Text mItemsecrettest;           //アイテムテキスト（詳細）
    int mItemnumber;                    //表示アイテム番号

    bool IsUpdata;                      //更新フラグ

    // Start is called before the first frame update
    void Start()
    {
        //オークションシーンのGameManager取得
        mAuctionManager = GameObject.Find("GameManager").GetComponent<CAuctionManager>();
        mItemdates = mAuctionManager.GetItemdateList();

        mItemicon = GameObject.Find("CatalogItemIcon").GetComponent<Image>();
        mItemname = GameObject.Find("CatalogItemName").GetComponent<TMP_Text>();
        mItemprice = GameObject.Find("CatalogItemPrice").GetComponent<TMP_Text>();
        mItempriceup = GameObject.Find("CatalogItemAddPrice").GetComponent<TMP_Text>();
        mItemsell = GameObject.Find("CatalogItemSellPrice").GetComponent<TMP_Text>();
        mItemtext = GameObject.Find("CatalogItemText").GetComponent<TMP_Text>();
        mItemsecrettest = GameObject.Find("CatalogItemSecretText").GetComponent<TMP_Text>();

        //配列の先頭になるよう初期化
        mItemnumber = 0;
        SetCatalogData();


    }

    // Update is called once per frame
    void Update()
    {
        if (IsUpdata)
        {
            SetCatalogData();
            IsUpdata = false;
        }
    }

    //カタログデータ更新
    void SetCatalogData()
    {
        mItemicon.sprite = mItemdates[mItemnumber].GetItemIcon();
        mItemname.text = mItemdates[mItemnumber].GetItemName();
        mItemprice.SetText("開始価格：" + "{0:0000000000}", mItemdates[mItemnumber].GetItemPrice());
        mItempriceup.SetText("上昇価格："+"{0:0000000000}", mItemdates[mItemnumber].GetPriceUpValue());
        mItemsell.SetText("売却価格：" + "{0:0000000000}", mItemdates[mItemnumber].GetSellvalue());
        mItemtext.text = mItemdates[mItemnumber].GetItemText();
        mItemsecrettest.text = mItemdates[mItemnumber].GetItemSecretText();
    }

    //表示アイテム番号増加
    public void ItemNumberUp()
    {
        IsUpdata = true;

        mItemnumber += 1;

        //上限設定
        if (mItemnumber >= mItemdates.Count)
        {
            mItemnumber = mItemdates.Count-1;
        }
    }

    //表示アイテム番号減少
    public void ItemNumberDown()
    {
        IsUpdata = true;

        mItemnumber -= 1;

        //下限設定
        if (mItemnumber < 0)
        {
            mItemnumber = 0;
        }
    }

}
