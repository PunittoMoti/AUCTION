using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCardObject : MonoBehaviour
{
    int mMoney;//金額
               //イラスト
    int mHandNumber;//配列番号
    Vector2 mHandCardPos; //手札時の座標
    bool misSelect;
    CHandcaedObject cHandcaedobject;



    // Start is called before the first frame update
    void Start()
    {
        misSelect = false;
        //手札オブジェクト取得
        cHandcaedobject = GameObject.Find("HandCards").GetComponent<CHandcaedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    //金額取得
    public void SetMonye(int value)
    {
        mMoney = value;
    }

    public int GetMonye()
    {
        return mMoney;
    }

    //番号取得
    public void SetHandNumber(int value)
    {
        mHandNumber = value;
    }

    public int GetHandNumber()
    {
        return mHandNumber;
    }

    public bool GetisSelect()
    {
        return misSelect;
    }

    //クリック時の関数
    public void ClickCard()
    {
        if (!misSelect) 
        {
            misSelect = true;
            //cHandcaedobject.SelectCard(this.GetComponent< CCardObject>());
            this.GetComponent<Image>().color = Color.green;
        }
        else if (misSelect)
        {
            misSelect = false;
            //cHandcaedobject.ReleaseCard(this.GetComponent<CCardObject>());
            this.GetComponent<Image>().color = Color.white;
        }
    }

    //使用確定した際の時の関数
    public void ReleaseCard()
    {
        //オブジェクト削除
        Destroy(gameObject);
    }

    //手札時の座標設定・更新
    public void SetHandCardPos(Vector2 pos)
    {
        mHandCardPos = pos;
    }

    public void Test()
    {
    }


}
