using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CUIObject : MonoBehaviour
{
    protected CItemData mItemdate;

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */

    //アイテムデータの取得
    public void SetItemData(CItemData item)
    {
        mItemdate = item;
    }

}
