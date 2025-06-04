using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCardObject : MonoBehaviour
{
    int mMoney;//金額
               //イラスト
    Vector2 mHandCardPos; //手札時の座標

    // Start is called before the first frame update
    void Start()
    {
        
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

    //クリック時の関数
    public void ClickCard()
    {
        //マウスカーソルと一緒に移動する 
        Vector2 mousePos = Input.mousePosition;

        this.GetComponent<RectTransform>().anchoredPosition = mousePos;
        Debug.Log("クリック位置："+ mousePos);

        //見た目をかえる？
    }

    //クリックを放した時の関数
    public void ReleaseCard()
    {
        //使用範囲に当たっていれば　使用　
            //Cardを配列からデリート要求
                //配列ナンバー取得
                //配列から削除
                //金額に追加

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
