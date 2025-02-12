using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSortItemList : MonoBehaviour
{
    List<CSortItemObject> mItemObjects = new List<CSortItemObject>();
    List<GameObject> mItems = new List<GameObject>();
    [SerializeField] List<int> mItemNumber = new List<int>();

    CItemDataBase mItemDateBase;

    // Start is called before the first frame update
    void Start()
    {
        //データベース取得
        mItemDateBase = Resources.Load<CItemDataBase>("Items/ItemDataBase");

        //オブジェクト要素分確保
        for (int count = 0; count < this.transform.childCount; count++)
        {
            mItems.Add(this.transform.GetChild(count).gameObject);
        }

        Debug.Log("リスト項目：" + mItems.Count);

        //アイテムデータベースから番号配列の内容でデータを取得しリストに取得
        for (int count = 0; count < mItemNumber.Count; count++)
        {
            if (this.transform.childCount - 1 < count)
            {
                Debug.Log("ブレイク");
                break;
            }


            CItemData itemData = mItemDateBase.GetItemData(mItemNumber[count]);
            mItems[count].GetComponent<CSortItemObject>().SetItemData(itemData);

            //アイテムリストに取得
            AddItem(mItems[count].GetComponent<CSortItemObject>());

            //Debug.Log("数と名前：" + mItemObjects.Count+ mItems[count].GetComponent<CItemObject>().GetItemName());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //リスト更新処理
    }

    //アイテム追加
    void AddItem(CSortItemObject item)
    {
        mItemObjects.Add(item);
        Debug.Log("オブジェクト名" + this.name);
        Debug.Log("追加：" + mItemObjects.Count);

    }

    //アイテム情報取得
    public CSortItemObject GetItem(int itemNumber)
    {
        if (mItemObjects.Count - 1 < itemNumber)
        {
            Debug.Log("要素数オーバー(GetItem)" + mItemObjects.Count);
        }

        return mItemObjects[itemNumber];
    }

    //ゲームオブジェクトリスト取得
    public List<GameObject> GetGameObjectList()
    {
        return mItems;
    }

    //アイテムList取得
    public List<CSortItemObject> GetItemList()
    {
        Debug.Log("オブジェクト名" + this.name);
        Debug.Log("要素数(ListGet)" + mItemObjects.Count);

        return mItemObjects;
    }

    //売却価格の合計
    public int GetBuyPrice()
    {
        int price = 0;
        Debug.Log("デバッグ");

        for (int count = 0; count < mItemObjects.Count; count++)
        {
            if (mItemObjects[count].GetSortItemStatus() == 2)
            {
                price += mItemObjects[count].GetItemBuyPrice();
            }
        }
        return price;
    }

    //移植チェック
    public bool GetAddPartsFlag()
    {
        for (int count = 0; count < mItemObjects.Count; count++)
        {
            if (mItemObjects[count].GetSortItemStatus() == 3)
            {
                return true;
            }
        }
        return false;
    }


    /*
    //リスト間のアイテム移動
    public void MoveItem(CItemList list,int itemNumber)
    {
        //アイテムリストに追加
        mItemObjects.Add(list.GetItem(itemNumber));
        //Item情報セット
        mItems[mItemObjects.Count-1].GetComponent<CItemObject>().SetItemObject(mItemObjects[mItemObjects.Count - 1]);
        //移動前のデータ削除 なんか一個ずれる
        list.GetItem(itemNumber).RemoveItemObject();
        //参照先のリストのアイテムオブジェクトデータ削除
        list.GetItemList().RemoveAt(itemNumber);
    }
    */
}
