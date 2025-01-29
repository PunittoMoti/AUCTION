using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CResultManager : MonoBehaviour
{
    [SerializeField]int mMoney;      //所持金
    [SerializeField] int mPayMoney;   //支払額
    int mSequence;  //アニメーションのシーケンス管理番号
    float mTime;    //経過時間

    // Start is called before the first frame update
    void Start()
    {
        //mMoney = CMoneyManager.sMoneyManager.GetMoneyValue();
        mTime = 0.0f;

        GameObject.Find("MyMoney").GetComponent<TMP_Text>().SetText("所持金：" + "{0:0000000000}", mMoney);
        GameObject.Find("PayMoney").GetComponent<TMP_Text>().SetText("支払額：" + "{0:0000000000}", mPayMoney);
        GameObject.Find("ResultMoney").GetComponent<TMP_Text>().SetText("残金　：" + "{0:0000000000}", (mMoney - mPayMoney));
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
