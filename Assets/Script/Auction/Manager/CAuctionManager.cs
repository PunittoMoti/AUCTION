using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAuctionManager : MonoBehaviour
{
    public class CCardObject
    {
        int mMoney;//金額
        //イラスト

        //金額取得
        public int GetMonye()
        {
            return mMoney;
        }

    }
    int mPhase;
    List<CCardObject> mHandcaeds;//手札　カードオブジェクト配列(可変)
    List<CCardObject> mDeck;//山札　カードオブジェクト配列(可変)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (mPhase)
        {
            case 0://ドローフェーズ
                //枚数が5未満だったら
                    //5枚になるまでデッキからランダムに追加　もしくは　シャッフルは別に任せて上から追加

                //枚数が5以上だったら
                   //1枚追加手札最大数は10枚

                //処理終了後メインフェーズに移行
                break;
            case 1://メインフェーズ
                //紹介開始フラグ送信
                //
                break;
            case 2://内部リザルトフェーズ

                break;
        }
        
    }


    
}
