using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CResultManager : MonoBehaviour
{
    enum RESULTSEWQUENCE
    {
        RESULTCHECK,
        BUYPARTS,
        END
    }

    [SerializeField]int mMoney;      //所持金
    [SerializeField] int mPayMoney;   //支払額
    RESULTSEWQUENCE mSequence;  //アニメーションのシーケンス管理番号
    float mTime;    //経過時間
    bool mIsPartsselect;//Select
    [SerializeField] GameObject mPartsbuttons;//体選択ボタンの親オブジェクト

    CSceneMoveObject mScenemoveObject;              //シーン遷移用


    // Start is called before the first frame update
    void Start()
    {
        //mMoney = CMoneyManager.sMoneyManager.GetMoneyValue();
        mTime = 0.0f;
        mIsPartsselect = false;
        GameObject.Find("MyMoney").GetComponent<TMP_Text>().SetText("所持金：" + "{0:0000000000}", mMoney);
        GameObject.Find("PayMoney").GetComponent<TMP_Text>().SetText("支払額：" + "{0:0000000000}", mPayMoney);
        GameObject.Find("ResultMoney").GetComponent<TMP_Text>().SetText("残金　：" + "{0:0000000000}", (mMoney - mPayMoney));

        //シーンオブジェクト取得
        mScenemoveObject = this.GetComponent<CSceneMoveObject>();

    }

    // Update is called once per frame
    void Update()
    {

        switch (mSequence)
        {
            //清算判定
            case RESULTSEWQUENCE.RESULTCHECK:

                //
                if(mMoney>= mPayMoney)
                {
                    mMoney -= mPayMoney;
                    mSequence = RESULTSEWQUENCE.END;
                }
                else
                {
                    //ボタンオブジェクトを有効
                    mPartsbuttons.SetActive(true);
                    mSequence = RESULTSEWQUENCE.BUYPARTS;
                }
                break;
            //不足時の体売却の選択
            case RESULTSEWQUENCE.BUYPARTS:

                if (mIsPartsselect)
                {
                    //ボタンオブジェクトを無効
                    mPartsbuttons.SetActive(false);
                    mIsPartsselect = false;
                    //判定へ遷移
                    mSequence = RESULTSEWQUENCE.RESULTCHECK;
                }

                break;
            //清算完了
            case RESULTSEWQUENCE.END:

                //遷移
                //シーン遷移
                mScenemoveObject.MoveScene();
                break;
        }

    }

    //ぼたん呼び込み
    public void ActiveIsPartsselect(int price)
    {
        mMoney += price;
        mIsPartsselect = true;
    }
}
