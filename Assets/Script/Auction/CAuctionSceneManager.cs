using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CAuctionSceneManager : MonoBehaviour
{
    int mPhase;
    List<CCardObject> mAddhandcaeds;//手札　カードオブジェクト配列(可変)
    List<CCardObject> mDeck;//デッキ　カードオブジェクト配列(可変)
    List<CCardObject> mUeshandcaeds;//使用待機カードオブジェクトを持っておく配列 (可変)

    GameObject mMoneycounterObj;//金額表示

    List<CItemData> mItemList;//オークションシーンで紹介されるアイテムリスト
    [SerializeField] CItemData mSelectitem;//現在紹介されているアイテム(Debug用にシリアライズ化している)

    bool mIsaction;//カード使用時のアクションが起きたときのフラグ


    CAuctionNPCManager mNpcmanager;//NPCマネージャー
    CHandcaedObject mHandcaedobject;//手札Object

    // Start is called before the first frame update
    void Start()
    {
        //デッキ配列生成
        mDeck = new List<CCardObject>();
        //使用待機カード配列生成
        mUeshandcaeds = new List<CCardObject>();
        //金額表示オブジェクト取得
        mMoneycounterObj = GameObject.Find("NowPrice");
        //NPCマネージャー取得
        mNpcmanager = this.GetComponent<CAuctionNPCManager>();
        //手札オブジェクト取得
        mHandcaedobject = GameObject.Find("HandCards").GetComponent<CHandcaedObject>();
        ////手札配列生成
        //mHandcaeds = mHandcaedobject.mHandcaeds;


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
                mAddhandcaeds = new List<CCardObject>();

                //枚数が5未満だったら
                if (mHandcaedobject.GetCardObjects().Count < 5)
                {
                    //5枚になるまでデッキからランダムに追加し、デッキから1つデータを削除

                    //手札が5枚になるまでデータを追加
                    for (int i = mHandcaedobject.GetCardObjects().Count; i < 5; i++)
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
                for (int i = 0; i < mHandcaedobject.GetCardObjects().Count; i++)
                {
                    //Debug.Log("カード金額" + i + ":" + mAddhandcaeds[i].GetMonye());
                }
                //カードオブジェクト生成
                //カードオブジェクトのｘ座標を既定の長さ÷手札配列の最大数で設定
                //mHandcaedobject.SetHandcaeds(mHandcaeds);
                mHandcaedobject.CreateCard(mAddhandcaeds);

                //処理終了後メインフェーズに移行
                mPhase = 1;

                break;
            case 1://メインフェーズ

                //選択されたカードの状態を反映
                SetUesCard(mHandcaedobject.GetCardObjects());


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
                //NPCの参加申請チェック
                mNpcmanager.CheckJoinNPCs(mSelectitem);

                //全NPCの終了判定
                mNpcmanager.ActionEndNPCs();

                //内部リザルトフェーズに移行
                mPhase = 3;
                break;
            case 3://内部リザルトフェーズ

                //購入判定
                //買えなかったらカードを手札に返却
                //次の商品データ準備
                

                //でバッグ処理
                //for (int i = 0; i < mHandcaeds.Count; i++)
                //{
                //    Debug.Log("手札データ" + i + ": " + mHandcaeds[i].GetMonye());
                //}

                //全NPCの初期化を行う
                mNpcmanager.ActionEndNPCs();

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
        mAddhandcaeds.Add(mDeck[DeckNo]);

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
    public void SetUesCard(List<GameObject> cards)
    {
        //Debug.Log("読み出し:"+ cards.Count);
        
        //mUeshandcaeds.Add(card);
        float count = 0;

        for(int i=0;i< cards.Count; i++)
        {
            if (cards[i] != null)
            {
                if (cards[i].GetComponent<CCardObject>().GetisSelect())
                {
                    count += cards[i].GetComponent<CCardObject>().GetMonye();
                }
            }
            
        }

        for (int i = 0; i < mUeshandcaeds.Count; i++)
        {
            count += mUeshandcaeds[i].GetMonye();
        }

        //もし合計金額が表示金額より少なければ
        //if (float.Parse(mMoneycounterObj.GetComponent<TMP_Text>().text) > count) return;

        //表示金額更新
        mMoneycounterObj.GetComponent<TMP_Text>().SetText("{0:0000000000}", count);

    }

    public void CardUes()
    {
        //Debug.Log("Debug");
        //フェーズ変更
        mPhase = 2;

        //使用済みカード登録
        for(int i=0;i< mHandcaedobject.GetCardObjects().Count; i++)
        {
            if (mHandcaedobject.GetCardObjects()[i].GetComponent<CCardObject>().GetisSelect())
            {
                mUeshandcaeds.Add(mHandcaedobject.GetCardObjects()[i].GetComponent<CCardObject>());
            }
           
        }
       
        //削除処理
        mHandcaedobject.PayUesCards();
    }


    //デバッグ用処理　ボタンなどできっかけとなる動作を行うよう
    public void DebugAction()
    {
        //Debug.Log("Debug");
        mPhase = 1;
    }

}
