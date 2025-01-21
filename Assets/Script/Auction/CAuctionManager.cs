using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CAuctionManager : MonoBehaviour
{
    [SerializeField] List<CItemData> mItemdatas;    //アイテムリスト
    CItemData mItemdata;                            //アイテムデータ
    TMP_Text mPricetext;                            //金額テキスト
    Sequence mSequence;                             //文字アニメーション
    bool mIsCountUp = false;                        //文字アニメーション実行中か否か
    int mPricevalue;                                //金額の値
    int mNextpricevalue;                            //更新中の金額の値(アニメーション用)

    [SerializeField] int mAddValue;

    // Start is called before the first frame update
    void Start()
    {
        //アイテムリストの先頭を最初のアイテムとして格納
        mItemdata = mItemdatas[0];

        //テキストのコンポーネントを取得
        mPricetext = GameObject.Find("NowPrice").GetComponent<TMP_Text>();
        mPricevalue = GetItemPrice();

        //開始金額をテキストに反映
        mPricetext.SetText("{0:0000000000}", mPricevalue);
    }

    // Update is called once per frame
    void Update()
    {
        if (mIsCountUp)
        {
            mPricetext.SetText("{0:0000000000}", mPricevalue);
        }

    }

    //掲示中のアイテムデータ取得
    public CItemData GetNowItemdate()
    {
        return mItemdata;
    }

    public int GetItemPrice()
    {
        return mItemdata.GetItemPrice();
    }

    //挙手加算処理
    public void AddPricevalue()
    {
        //金額変更前の値
        mNextpricevalue = mPricevalue;
        //金額を更新
        mNextpricevalue += mAddValue;

        //アニメーションが再生中であればスキップする
        if (mIsCountUp)
        {
            mSequence.Kill(true);
        }

        //アニメーション実行
        CountUpAnim();
    }

    //宣言加算処理
    public void CallupPricevalue(int value)
    {
        //金額変更前の値
        mNextpricevalue = mPricevalue;
        //金額を更新
        mNextpricevalue = mNextpricevalue * value;

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
                () => mPricevalue,           //更新対象
                num => mPricevalue = num,    //値の更新
                mNextpricevalue,              //最終的な値
                0.5f))                  //アニメーション時間
                                        //終了後0.1f待機
            .AppendInterval(0.1f)
            //金額表示更新を停止
            .AppendCallback(() => mIsCountUp = false);
    }





}
