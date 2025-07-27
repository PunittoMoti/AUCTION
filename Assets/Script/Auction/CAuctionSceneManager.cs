using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CAuctionSceneManager : MonoBehaviour
{
    int mPhase;
    List<CCardObject> mHandcaeds;//手札　カードオブジェクト配列(可変)
    List<CCardObject> mDeck;//デッキ　カードオブジェクト配列(可変)
    List<CCardObject> mUeshandcaeds;//使用待機カードオブジェクトを持っておく配列 (可変)

    GameObject mMoneycounterObj;//金額表示

    List<CItemData> mItemList;//オークションシーンで紹介されるアイテムリスト
    CItemData mSelectitem;//現在紹介されているアイテム

    bool mIsaction;//カード使用時のアクションが起きたときのフラグ

    // Start is called before the first frame update
    void Start()
    {
        //手札配列生成
        mHandcaeds = new List<CCardObject>();
        //デッキ配列生成
        mDeck = new List<CCardObject>();
        //使用待機カード配列生成
        mUeshandcaeds = new List<CCardObject>();
        //金額表示オブジェクト取得
        mMoneycounterObj = GameObject.Find("NowPrice");

        //デッキにカードを設定（テスト用）
        //→今後をデッキ配列取得に置き換え
        int i = 0;
        for (i = 0; i < 10; i++)
        {
            CCardObject card = new();
            if (i < 4) card.SetMonye(100);
            else if (i < 8) card.SetMonye(1000);
            else if (i < 10) card.SetMonye(10000);

            mDeck.Add(card);
        }

        mIsaction = false;

        mPhase = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (mPhase)
        {
            case 0://ドローフェーズ・NPC参加判定
                //枚数が5未満だったら
                if (mHandcaeds.Count < 5)
                {
                    //5枚になるまでデッキからランダムに追加し、デッキから1つデータを削除

                    //手札が5枚になるまでデータを追加
                    for (int i = mHandcaeds.Count; i < 5; i++)
                    {
                        DrawAction();
                    }
                }
                //枚数が5以上だったら
                else
                {
                    //1枚追加手札最大数は10枚
                    DrawAction();
                }

                //紹介開始フラグ送信

                //カードオブジェクト生成
                //カードオブジェクトのｘ座標を既定の長さ÷手札配列の最大数で設定
                GameObject.Find("HandCards").GetComponent<CHandcaedObject>().SetHandcaeds(mHandcaeds);
                GameObject.Find("HandCards").GetComponent<CHandcaedObject>().CreateCard();

                //処理終了後メインフェーズに移行
                //mPhase = 1;

                break;
            case 1://メインフェーズ
                   //カード選択
                   //選択されたカードを集約



                //アイテムメニュー
                //カタログメニュー

                //カード使用
                if (mIsaction)
                {
                    //ボタンで仮代用

                    //金額プラス
                    //NPCメインフェーズに移行
                    //mPhase = 2;
                }
                

                break;
            case 2://NPCメインフェーズ
                
                //NPCの行動
                //アイテムメニュー
                //カタログメニュー
                //内部リザルトフェーズに移行
                mPhase = 3;
                break;
            case 3://内部リザルトフェーズ

                //購入判定
                //買えなかったらカードを手札に返却
                //次の商品データ準備
                

                //でバッグ処理
                for (int i = 0; i < mHandcaeds.Count; i++)
                {
                    Debug.Log("手札データ" + i + ": " + mHandcaeds[i].GetMonye());
                }


                //ドローフェーズに移行
                mPhase = 0;
                break;
        }

    }

    //フェーズの値を取得
    public int GetPhase()
    {
        return mPhase;
    }


    //ドロー処理
    private void DrawAction()
    {
        
        int DeckNo = 0;//デッキ

        if (mDeck.Count < 1) return;
        //デッキのランダムな配列番号決定
        DeckNo = Random.Range(0, mDeck.Count - 1);
        //手札に追加
        mHandcaeds.Add(mDeck[DeckNo]);

        //使用したデータをデッキから削除
        mDeck.RemoveAt(DeckNo);
    }

    //パス使用時に呼び出す処理
    public void PassAction()
    {
        mPhase = 0;
        //必要であればそのターン使用したカードが返ってくるように修正
    }

    //使用カード登録・金額計算
    public void SetUesCard(List<CCardObject> cards)
    {
        //mUeshandcaeds.Add(card);
        float count = 0;

        for(int i=0;i< cards.Count; i++)
        {
            count += cards[i].GetMonye();
        }

        //もし合計金額が表示金額より少なければ
        //if (float.Parse(mMoneycounterObj.GetComponent<TMP_Text>().text) > count) return;

        //表示金額更新
        mMoneycounterObj.GetComponent<TMP_Text>().SetText("{0:0000000000}", count);

    }

    public void CardUes()
    {
        //Debug.Log("Debug");
        mPhase = 2;
    }


    //デバッグ用処理　ボタンなどできっかけとなる動作を行うよう
    public void DebugAction()
    {
        //Debug.Log("Debug");
        mPhase = 1;
    }

}
