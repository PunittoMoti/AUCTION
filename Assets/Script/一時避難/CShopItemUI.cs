using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CShopItemUI : CUIObject,IUI
{
    CShopManager mShopmanager;     //ショップマネージャー
    bool IsBegin;
    bool IsSoldout;                //売り切れフラグ

    // Start is called before the first frame update
    void Start()
    {
        mShopmanager = GameObject.Find("ShopManager").GetComponent<CShopManager>();
        this.transform.Find("PickImage").gameObject.GetComponent<Image>().enabled = false;
        IsSoldout = false;
        IsBegin = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsBegin)
        {
            transform.Find("Name").gameObject.GetComponent<TMP_Text>().text = mItemdate.GetItemName();
            transform.Find("Icon").gameObject.GetComponent<Image>().sprite = mItemdate.GetItemIcon();
            IsBegin = true;
        }

    }

    //UI実行時の処理内容
    public void UIAction()
    {
        mShopmanager.SetShowItemObject(mItemdate, this.gameObject);
    }

    //売り切れ
    public void NullItem()
    {
        //取得した物を適用
        transform.Find("Name").gameObject.GetComponent<TMP_Text>().text = "sold out";
        transform.Find("Icon").gameObject.GetComponent<Image>().sprite = mShopmanager.GetSoldoutIcon();
        IsSoldout = true;
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
