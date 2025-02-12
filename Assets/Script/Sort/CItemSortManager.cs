using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CItemSortManager : MonoBehaviour
{
    enum ITEMSORTSEWQUENCE
    {
        CHECK,
        BUYRESULT,
        SETPARTS,
        END
    }

    [SerializeField] int mMoney;      //所持金
    int mBuyMoney;                     //売却金額
    ITEMSORTSEWQUENCE mSequence;  //アニメーションのシーケンス管理番号
    float mTime;    //経過時間
    bool mIsEnd;//End
    [SerializeField] GameObject mPartSet;//移植演出
    [SerializeField] GameObject mAllPrice;
    CSortItemList mSortItemList;//

    CSceneMoveObject mScenemoveObject;              //シーン遷移用


    // Start is called before the first frame update
    void Start()
    {
        //mMoney = CMoneyManager.sMoneyManager.GetMoneyValue();
        mTime = 0.0f;
        mIsEnd = false;
        GameObject.Find("MyMoney").GetComponent<TMP_Text>().SetText("所持金：" + "{0:0000000000}", mMoney);
        GameObject.Find("BuyMoney").GetComponent<TMP_Text>().SetText("売却額：" + "{0:0000000000}", mBuyMoney);

        //シーンオブジェクト取得
        mScenemoveObject = this.GetComponent<CSceneMoveObject>();
        mSortItemList = GameObject.Find("ItemList").GetComponent<CSortItemList>();

    }

    // Update is called once per frame
    void Update()
    {

        switch (mSequence)
        {
            //清算判定
            case ITEMSORTSEWQUENCE.CHECK:
                mBuyMoney = mSortItemList.GetBuyPrice();
                GameObject.Find("BuyMoney").GetComponent<TMP_Text>().SetText("売却額：" + "{0:0000000000}", mBuyMoney);

                if (mIsEnd)
                {
                    mMoney += mBuyMoney;
                    mAllPrice.SetActive(true);
                    mSequence = ITEMSORTSEWQUENCE.BUYRESULT;
                }
                break;
            //不足時の体売却の選択
            case ITEMSORTSEWQUENCE.BUYRESULT:

                mAllPrice.GetComponent<TMP_Text>().SetText("清算結果：" + "{0:0000000000}", mMoney);

                mTime += Time.deltaTime;
                if (mTime >= 2.0)
                {
                    mTime = 0.0f;
                    if (mSortItemList.GetAddPartsFlag())
                    {
                        mSequence = ITEMSORTSEWQUENCE.SETPARTS;
                    }
                    else
                    {
                        mSequence = ITEMSORTSEWQUENCE.END;
                    }
                }
                break;
            //不足時の体売却の選択
            case ITEMSORTSEWQUENCE.SETPARTS:
                mPartSet.SetActive(true);
                mTime += Time.deltaTime;
                if (mTime >= 2.0)
                {
                    mTime = 0.0f;
                    mSequence = ITEMSORTSEWQUENCE.END;
                }
                break;
            //清算完了
            case ITEMSORTSEWQUENCE.END:

                //遷移
                //シーン遷移
                mScenemoveObject.MoveScene();
                break;
        }

    }

    //ぼたん呼び込み
    public void ActivemIsEnd()
    {
        mIsEnd = true;
    }
}
