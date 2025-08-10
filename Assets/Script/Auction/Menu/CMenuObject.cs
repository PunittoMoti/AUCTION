using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMenuObject : MonoBehaviour
{
    List<GameObject> mChilds;
    [SerializeField] List<CItemData> mItemdatas;

    CItemButton mSelectitembutton;

    bool misSelectItem;
    // Start is called before the first frame update
    void Start()
    {
        mChilds = new List<GameObject>();
        mSelectitembutton = new CItemButton();
        // 子オブジェクトを順に取得する
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            mChilds.Add(transform.GetChild(i).gameObject);
        }

        UpdateItemData();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < mChilds.Count; i++)
        {
            if (mChilds[i].GetComponent<CItemButton>().GetIsSelect())
            {
                misSelectItem = true;
                mSelectitembutton = mChilds[i].GetComponent<CItemButton>();
                break;
            }

            misSelectItem = false;
        }

        if (!misSelectItem)
        {
            mSelectitembutton = new CItemButton();
        }
        else
        {
           
            
        }

    }

    //子オブジェクトのCItembuttonが持つアイテムデータを更新
    void UpdateItemData()
    {
        for(int i=0;i< mItemdatas.Count; i++)
        {
            mChilds[i].GetComponent<CItemButton>().SetItemdata(mItemdatas[i]);
        }
    }

    //選択フラグ返す
    public bool GetIsSelectItem()
    {
        return misSelectItem;
    }
    //選択Itemデータを返す
    public CItemData GetSelectItemData()
    {
        return mSelectitembutton.GetItemData();
    }

    //フラグ開放
    public void ReleaseItemButton()
    {
        mSelectitembutton.ReleaseIsSelect();
    }

}
