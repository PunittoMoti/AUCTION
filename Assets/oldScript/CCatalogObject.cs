using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static ItemStatus;

public class CCatalogObject : MonoBehaviour
{
    [SerializeField] CItemData mItemData;

    string mName;                  //アイテム名
    int mPrice;                    //値段
    ITEMSTATUS mItemStatus;        //アイテムの種類
    string mItemText;              //アイテム説明
    Sprite mIcon;                  //アイコン


    // Start is called before the first frame update
    void Start()
    {
        //アイテムデータから取得
        mName = mItemData.GetItemName();
        mPrice = mItemData.GetItemPrice();
        mItemStatus = mItemData.GetItemStatus();
        mItemText = mItemData.GetItemText();
        mIcon = mItemData.GetItemIcon();

        //取得した物を適用
        transform.Find("Canvas/Name").gameObject.GetComponent<TMP_Text>().text = mName;
        transform.Find("Canvas/ItemText").gameObject.GetComponent<TMP_Text>().text = mItemText;
        transform.Find("Canvas/Price").gameObject.GetComponent<TMP_Text>().text = mPrice.ToString();
        transform.Find("Icon").gameObject.GetComponent<SpriteRenderer>().sprite = mIcon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
