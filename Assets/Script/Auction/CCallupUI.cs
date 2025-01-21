using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CCallupUI : MonoBehaviour
{
    CAuctionManager mAuctionManager;    //オークションシーンのGameManager
    TMP_Text mCalluptext;               //倍率テキスト
    float mCallupvalue;                 //倍率数値

    // Start is called before the first frame update
    void Start()
    {
        //オークションシーンのGameManager取得
        mAuctionManager = GameObject.Find("GameManager").GetComponent<CAuctionManager>();

        //テキストのコンポーネントを取得
        mCalluptext = this.GetComponent<TMP_Text>();

        //表示数値初期化
        mCallupvalue = 2.0f;
        mCalluptext.SetText("×" + "{0:1}", mCallupvalue);

    }

    // Update is called once per frame
    void Update()
    {
        //倍率更新
        mCalluptext.SetText("×" + "{0:1}", mCallupvalue);
    }

    //宣言の加算処理
    public void CallupPricevalue()
    {
        mAuctionManager.CallupPricevalue((int)mCallupvalue);
        mCallupvalue = 2.0f;
    }

    //宣言の倍率上昇処理
    public void Callvalueup()
    {
        mCallupvalue += 1.0f;

        //上限設定
        if (mCallupvalue > 5.0f)
        {
            mCallupvalue = 5.0f;
        }
    }

    //宣言の倍率下降処理
    public void Callvaluedown()
    {
        mCallupvalue -= 1.0f;

        //下限設定
        if (mCallupvalue < 2.0f)
        {
            mCallupvalue = 2.0f;
        }
    }

}
