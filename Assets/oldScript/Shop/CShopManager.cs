using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShopManager : MonoBehaviour
{
    [SerializeField]Sprite mSoldouticon;
    GameObject mShowitemobject;   //選択時のアイテム表示オブジェクト

    // Start is called before the first frame update
    void Start()
    {
        //SGameStatus.AddMoney(100000);
        mShowitemobject = GameObject.Find("ShowShopObject");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite GetSoldoutIcon()
    {
        return mSoldouticon;
    }

    //確認中アイテムへのデータ渡し
    public void SetShowItemObject(CItemData item,GameObject gameObject)
    {
        mShowitemobject.GetComponent<CShowShopObject>().SetItemObject(item, gameObject);
    }

}
