using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCardObject : MonoBehaviour
{
    int mMoney;//金額
               //イラスト
    int mHandNumber;//配列番号
    Vector2 mHandCardPos; //手札時の座標
    bool misHit;
    CHandcaedObject cHandcaedobject;



    // Start is called before the first frame update
    void Start()
    {
        misHit = false;
        //手札オブジェクト取得
        cHandcaedobject = GameObject.Find("HandCards").GetComponent<CHandcaedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.name == "UesArea")
        {
            misHit = true;
            //Debug.Log("あたった：" + misHit + "  " + mHandNumber);

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {


        if (collision.gameObject.name == "UesArea")
        {
            misHit = false;
            //Debug.Log("外れた：" + misHit + "  " + mHandNumber);
        }
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

    //クリック時の関数
    public void ClickCard()
    {
        //マウスカーソルと一緒に移動する 
        Vector2 mousePos = Input.mousePosition;

        this.GetComponent<RectTransform>().anchoredPosition = mousePos;
        //Debug.Log("クリック位置："+ mousePos);

        //見た目をかえる？
    }

    //クリックを放した時の関数
    public void ReleaseCard()
    {
        //使用範囲に当たっていれば　使用　
        if (misHit)
        {
            //使用して、配列から削除要求
            cHandcaedobject.UseCard(mHandNumber);

            //オブジェクト削除
            Destroy(this.gameObject);

        }

        //それ以外れあれば手札に戻る

        this.GetComponent<RectTransform>().anchoredPosition = mHandCardPos;
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
