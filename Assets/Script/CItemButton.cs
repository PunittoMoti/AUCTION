using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CItemButton : MonoBehaviour
{
    CItemData mItemdata;
    bool misSelect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //アイテムデータ設定
    public void SetItemdata(CItemData data)
    {
        mItemdata = data;
    }

    //アイテムデータ取得
    public CItemData GetItemData()
    {
        return mItemdata;
    }

    //選択フラグ取得
    public bool GetIsSelect()
    {
        return misSelect;
    }

    //アイテム使用時のフラグ開放
    public void ReleaseIsSelect()
    {
        misSelect = false;
        this.GetComponent<Image>().color = Color.gray;
    }

    //クリック時の反応
    public void ClickItem()
    {
        if (!misSelect)
        {
            misSelect = true;
            this.GetComponent<Image>().color = Color.green;
        }
        else if (misSelect)
        {
            misSelect = false;
            this.GetComponent<Image>().color = Color.gray;
        }
    }

}
