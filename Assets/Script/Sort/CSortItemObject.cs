using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CSortItemObject : MonoBehaviour
{
    /*
    enum SORTITEMSEWQUENCE
    {
        ITEMSELECT,
        RESULT,
        ADDPARTS,
        END
    }
    */

    public enum SORTITEMSTATUS
    {
        DEFAULT,
        GET,
        BUY,
        ADDPARTS
    }


    CItemData mdate;                //アイテムデータ
    string mName;                   //アイテム名
    List<CCheckBoxObject> mCheckboxs;    //チェックボックスオブジェクト 
    List<bool> mIsCheckstatus;            //チェックStatus
    SORTITEMSTATUS mSortItemStatus;       //

    // Start is called before the first frame update
    void Start()
    {
        //チェックボックス取得
        mCheckboxs = new List<CCheckBoxObject>();
        mCheckboxs.Add(this.transform.Find("Get").GetComponent<CCheckBoxObject>());
        mCheckboxs.Add(this.transform.Find("Buy").GetComponent<CCheckBoxObject>());
        mCheckboxs.Add(this.transform.Find("AddParts").GetComponent<CCheckBoxObject>());

        //mCheckboxs[0] = this.transform.Find("Get").GetComponent<CCheckBoxObject>();
        //mCheckboxs[1] = this.transform.Find("Buy").GetComponent<CCheckBoxObject>();
        //mCheckboxs[2] = this.transform.Find("AddParts").GetComponent<CCheckBoxObject>();

        //チェックボックス状態取得
        mIsCheckstatus = new List<bool>();
        mIsCheckstatus.Add(mCheckboxs[0].GetIsCheck());
        mIsCheckstatus.Add(mCheckboxs[1].GetIsCheck());
        mIsCheckstatus.Add(mCheckboxs[2].GetIsCheck());

        //mIsCheckstatus[0] = mCheckboxs[0].GetIsCheck();
        //mIsCheckstatus[1] = mCheckboxs[1].GetIsCheck();
        //mIsCheckstatus[2] = mCheckboxs[2].GetIsCheck();

        mSortItemStatus = SORTITEMSTATUS.DEFAULT;

        //取得した物を適用
        transform.Find("NameBack/Name").gameObject.GetComponent<TMP_Text>().text = mName;


    }

    // Update is called once per frame
    void Update()
    {
        //状態初期化
        mSortItemStatus = SORTITEMSTATUS.DEFAULT;

        for (int cnt = 0; cnt < 3; cnt++)
        {
            //Debug.Log("個数　" + mIsCheckstatus.Count);
            mIsCheckstatus[cnt] = mCheckboxs[cnt].GetIsCheck();

            if (mIsCheckstatus[cnt])
            {
                switch (cnt)
                {
                    case 0:
                        mSortItemStatus = SORTITEMSTATUS.GET;
                        break;
                    case 1:
                        mSortItemStatus = SORTITEMSTATUS.BUY;
                        break;
                    case 2:
                        mSortItemStatus = SORTITEMSTATUS.ADDPARTS;
                        break;

                }
            }
        }


    }

    //ステータスゲット
    public int GetSortItemStatus()
    {
        return (int)mSortItemStatus;
    }

    //アイテムデータの取得
    public void SetItemData(CItemData item)
    {
        mdate = item;
        mName = item.GetItemName();
        /*
        //カタログだった場合Prefab取得
        if (mItemStatus == ITEMSTATUS.CATALOG)
        {
            mCatalogPrefab = item.GetCatalogPrefab();
        }
        */

        //取得した物を適用
        transform.Find("NameBack/Name").gameObject.GetComponent<TMP_Text>().text = mName;
    }

    //売却価格取得
    public int GetItemBuyPrice()
    {
        return mdate.GetItemPrice();
    }
}
