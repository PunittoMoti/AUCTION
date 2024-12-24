using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CItemList : MonoBehaviour
{
     List<CItemObject> mItemObjects = new List<CItemObject>();
    List<GameObject> mItems;

    // Start is called before the first frame update
    void Start()
    {
        //子オブジェクト取得
        Transform transform = this.transform;
        mItems = new GameObject[transform.childCount];
    }

    // Update is called once per frame
    void Update()
    {
        //mItemObjectsを読みこんで子オブジェクトのリストに一つ一つに代入
    }

    //アイテム追加
    void AddItem(CItemObject item)
    {
        mItemObjects.Add(item);
    }
}
