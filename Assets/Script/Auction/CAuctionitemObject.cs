using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CAuctionitemObject : MonoBehaviour
{
    CAuctionManager mAuctionManager;    //オークションシーンのGameManager
    CItemData mItemdate;                //掲示中のアイテム
    Image mItemicon;                    //アイテム画像

    // Start is called before the first frame update
    void Start()
    {
        //オークションシーンのGameManager取得
        mAuctionManager = GameObject.Find("GameManager").GetComponent<CAuctionManager>();

        //テキストのコンポーネントを取得
        mItemicon = this.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        mItemdate = mAuctionManager.GetNowItemdate();
        mItemicon.sprite = mItemdate.GetItemIcon();
    }
}
