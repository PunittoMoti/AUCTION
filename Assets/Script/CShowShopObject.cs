using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static ItemStatus;


public class CShowShopObject : MonoBehaviour
{
    CItemObject mShowItemdata;
    GameObject mCheckGameObject;

    string mName;                  //アイテム名
    int mPrice;                    //値段
    ITEMSTATUS mItemStatus;        //アイテムの種類
    string mItemText;              //アイテム説明
    Sprite mIcon;                  //アイコン

    // Start is called before the first frame update
    void Start()
    {
        if (CMoneyManager.sMoneyManager == null)
        {
            CMoneyManager.sMoneyManager = new CMoneyManager();

            //デバッグ処理　直下の行のみ
            CMoneyManager.sMoneyManager.AddMoney(1000);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //アイテムオブジェクト・データの取得
    public void SetItemObject(CItemObject item,GameObject gameObject)
    {
        mName = item.GetItemName();
        mPrice = item.GetItemPrice();
        mItemStatus = item.GetItemStatus();
        mItemText = item.GetItemText();
        mIcon = item.GetItemIcon();

        //取得した物を適用
        transform.Find("Canvas/Name").gameObject.GetComponent<TMP_Text>().text = mName;
        transform.Find("Canvas/ItemText").gameObject.GetComponent<TMP_Text>().text = mItemText;
        transform.Find("Icon").gameObject.GetComponent<SpriteRenderer>().sprite = mIcon;

        mCheckGameObject = gameObject;
        mShowItemdata = item;
    }

    //購入時の判定
    public void BuyItem()
    {
        if (mShowItemdata.GetItemPrice() > CMoneyManager.sMoneyManager.GetMoneyValue()) 
        {
            Debug.Log("資金不足");
            return;
        }

        CMoneyManager.sMoneyManager.PayMoney(mShowItemdata.GetItemPrice());

        Debug.Log("購入！！　残り金額："+ CMoneyManager.sMoneyManager.GetMoneyValue());
    }

}
