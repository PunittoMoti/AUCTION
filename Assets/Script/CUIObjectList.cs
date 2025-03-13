using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIObjectList : MonoBehaviour
{
    List<CUIObject> mUIobjects = new List<CUIObject>();
    List<GameObject> mObjects = new List<GameObject>();
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
            mObjects.Add(this.transform.GetChild(count).gameObject);
        }

        Debug.Log("リスト項目：" + mObjects.Count);

        //アイテムデータベースから番号配列の内容でデータを取得しリストに取得
        for (int count = 0; count < mItemNumber.Count; count++)
        {
            if (this.transform.childCount - 1 < count)
            {
                Debug.Log("ブレイク");
                break;
            }


            CItemData itemData = mItemDateBase.GetItemData(mItemNumber[count]);
            mObjects[count].GetComponent<CUIObject>().SetItemData(itemData);

            //アイテムリストに取得
            AddItem(mObjects[count].GetComponent<CUIObject>());

        }
    }

    // Update is called once per frame
    void Update()
    {
        //リスト更新処理
    }

    //アイテム追加
    void AddItem(CUIObject item)
    {
        mUIobjects.Add(item);
        Debug.Log("オブジェクト名" + this.name);
        Debug.Log("追加：" + mUIobjects.Count);

    }


    //未使用
    //アイテム情報取得
    public CUIObject GetItem(int itemNumber)
    {
        if (mUIobjects.Count - 1 < itemNumber)
        {
            Debug.Log("要素数オーバー(GetItem)" + mUIobjects.Count);
        }

        return mUIobjects[itemNumber];
    }

    //未使用
    //ゲームオブジェクトリスト取得
    public List<GameObject> GetGameObjectList()
    {
        return mObjects;
    }

    //未使用

    //アイテムList取得
    public List<CUIObject> GetItemList()
    {
        Debug.Log("オブジェクト名" + this.name);
        Debug.Log("要素数(ListGet)" + mUIobjects.Count);

        return mUIobjects;
    }
}
