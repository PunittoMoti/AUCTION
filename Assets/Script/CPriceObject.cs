using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CPriceObject : MonoBehaviour
{
    int mPrice;
    int mNextPrice;

    bool mIsCountUp = false;

    GameObject mManagerObject;
    TMP_Text mPriceText;

    Sequence mSequence;
    

    // Start is called before the first frame update
    void Start()
    {
        //GameManagerオブジェクトを取得
        mManagerObject = GameObject.Find("GameManager");
        //テキストのコンポーネントを取得
        mPriceText = this.GetComponent<TMP_Text>();
        mPrice = mManagerObject.GetComponent<CAuctionManager>().GetItemPrice();


        mPriceText.SetText("{0:0000000000}", mPrice);

    }

    // Update is called once per frame
    void Update()
    {
        if (mIsCountUp)
        {
            mPriceText.SetText("{0:0000000000}", mPrice);
        }
    }

    //加算処理
    public void AddPoint(int point)
    {
        //金額変更前の値
        mPrice = mNextPrice;
        //金額を更新
        mNextPrice += point;

        //アニメーションが再生中であればスキップする
        if (mIsCountUp)
        {
            mSequence.Kill(true);
        }

        //アニメーション実行
        CountUpAnim();
    }

    //カウントアップアニメーション
    void CountUpAnim()
    {
        //カウントアップフラグ有効化
        mIsCountUp = true;

        mSequence = DOTween.Sequence()
            .Append(DOTween.To(
                () => mPrice,           //更新対象
                num => mPrice = num,    //値の更新
                mNextPrice,              //最終的な値
                0.5f))                  //アニメーション時間
            //終了後0.1f待機
            .AppendInterval(0.1f)
            //金額表示更新を停止
            .AppendCallback(() => mIsCountUp = false);
    }
}
