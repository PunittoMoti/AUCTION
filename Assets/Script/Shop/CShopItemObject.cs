using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CShopItemObject : MonoBehaviour
{
    CItemData mdate;                //アイテムデータ
    Sprite mIcon;                    //アイテム画像
    string mName;                   //アイテム名
    GameObject mShowitemobject;   //選択時のアイテム表示オブジェクト
    bool IsSoldout;                //売り切れフラグ


    CShopManager mShopmanager;     //ショップマネージャー


    //カタログ用のアイテムリスト必要

    // Start is called before the first frame update
    void Start()
    {
        mShowitemobject = GameObject.Find("ShowShopObject");
        mShopmanager = GameObject.Find("ShopManager").GetComponent<CShopManager>();
        IsSoldout = false;
        this.transform.Find("PickImage").gameObject.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //(GameObject)Resources.Load("AuctiontalkObject");
    }


    //アイテムデータの取得
    public void SetItemData(CItemData item)
    {
        if (IsSoldout) return;
        mdate = item;
        mName = item.GetItemName();
        mIcon = item.GetItemIcon();

        /*
        //カタログだった場合Prefab取得
        if (mItemStatus == ITEMSTATUS.CATALOG)
        {
            mCatalogPrefab = item.GetCatalogPrefab();
        }
        */

        //取得した物を適用
        transform.Find("Name").gameObject.GetComponent<TMP_Text>().text = mName;
        transform.Find("Icon").gameObject.GetComponent<Image>().sprite = mIcon;

    }

    //売り切れ
    public void NullItem()
    {
        //取得した物を適用
        transform.Find("Name").gameObject.GetComponent<TMP_Text>().text = "sold out";
        transform.Find("Icon").gameObject.GetComponent<Image>().sprite = mShopmanager.GetSoldoutIcon();
        IsSoldout = true;
    }

    //確認中アイテムへデータわたし
    public void SetShowItemObject()
    {
        if (IsSoldout) return;
        mShowitemobject.GetComponent<CShowShopObject>().SetItemObject(mdate, this.gameObject);
    }

    //強調カーソル表示
    public void ActivePickupCursor()
    {
        if (IsSoldout) return;
        this.transform.Find("PickImage").gameObject.GetComponent<Image>().enabled = true;
    }

    //強調カーソル非表示
    public void NoActivePickupCursor()
    {
        this.transform.Find("PickImage").gameObject.GetComponent<Image>().enabled = false;

    }
}
