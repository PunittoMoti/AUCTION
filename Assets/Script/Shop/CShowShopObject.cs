using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static ItemStatus;
using UnityEngine.UI;


public class CShowShopObject : MonoBehaviour
{
    CItemData mShowItemdata;
    GameObject mCheckGameObject;

    string mName;                  //アイテム名
    int mPrice;                    //値段
    //ITEMSTATUS mItemStatus;        //アイテムの種類
    string mItemText;              //アイテム説明
    Sprite mIcon;                  //アイコン

    CShopManager mShopmanager;     //ショップマネージャー


    // Start is called before the first frame update
    void Start()
    {
        if (CMoneyManager.sMoneyManager == null)
        {
            CMoneyManager.sMoneyManager = new CMoneyManager();

            //デバッグ処理　直下の行のみ
            CMoneyManager.sMoneyManager.AddMoney(100000);
        }

        mShopmanager = GameObject.Find("ShopManager").GetComponent<CShopManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //アイテムオブジェクト・データの取得
    public void SetItemObject(CItemData item,GameObject gameObject)
    {
        mName = item.GetItemName();
        mPrice = item.GetItemPrice();
        //mItemStatus = item.GetItemStatus();
        mItemText = item.GetItemText();
        mIcon = item.GetItemIcon();

        //取得した物を適用
        transform.Find("Name").gameObject.GetComponent<TMP_Text>().text = mName;
        transform.Find("ItemText").gameObject.GetComponent<TMP_Text>().text = mItemText;
        transform.Find("Icon").gameObject.GetComponent<Image>().sprite = mIcon;

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

        //アイテムリストが生成されていなければ生成
        if (SItemList.Items == null) SItemList.Items = new List<CItemData>();
        //アイテムリストに追加
        SItemList.AddItemList(mShowItemdata);

        //支払
        CMoneyManager.sMoneyManager.PayMoney(mShowItemdata.GetItemPrice());
        
        //商品棚のアイテムを売り切れに変更
        mCheckGameObject.GetComponent<CShopItemObject>().NullItem();


        //詳細を表示しているアイテムを売り切れに変更
        transform.Find("Name").gameObject.GetComponent<TMP_Text>().text = "sold out";
        transform.Find("ItemText").gameObject.GetComponent<TMP_Text>().text = "sold out";
        transform.Find("Icon").gameObject.GetComponent<Image>().sprite = mShopmanager.GetSoldoutIcon();


        Debug.Log("購入！！　残り金額："+ CMoneyManager.sMoneyManager.GetMoneyValue());
    }

}
