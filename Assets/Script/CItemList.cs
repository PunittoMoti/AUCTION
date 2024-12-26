using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CItemList : MonoBehaviour
{
    List<CItemObject> mItemObjects = new List<CItemObject>();
    List<GameObject> mItems;
    List<int> mItemNumber = new List<int>() { 0,2,1,2};

    CItemDataBase mItemDateBase;

    // Start is called before the first frame update
    void Start()
    {
        //子オブジェクト取得
        mItems = new List<GameObject>();

        //データベース取得
        mItemDateBase = Resources.Load<CItemDataBase>("Items/ItemDataBase");

        //オブジェクト要素分確保
        for(int count = 0; count < this.transform.childCount; count++)
        {
            mItems.Add(this.transform.GetChild(count).gameObject);
        }

        Debug.Log("リスト項目：" + mItems.Count);

        //アイテムデータベースから番号配列の内容でデータを取得しリストに取得
        for (int count = 0;count < mItemNumber.Count; count++)
        {
            if (this.transform.childCount-1 < count)
            {
                Debug.Log("ブレイク");
                break;
            }


            CItemData itemData = mItemDateBase.GetItemData(mItemNumber[count]);
            mItems[count].GetComponent<CItemObject>().SetItemData(itemData);
            
            //アイテムリストに取得
            AddItem(mItems[count].GetComponent<CItemObject>());

            Debug.Log("数：" + mItemNumber.Count);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //リスト更新処理
    }

    //アイテム追加
    void AddItem(CItemObject item)
    {
        mItemObjects.Add(item);
    }
}


/*
 子オブジェクト取得
↓
番号配列読み込みテキストファイル読み込み
↓
リストにアイテムデータを利用して配列の番号に合ったものを順に入れていく
↓

 
 */
