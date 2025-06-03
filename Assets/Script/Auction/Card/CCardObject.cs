using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCardObject : MonoBehaviour
{
    int mMoney;//金額
               //イラスト

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
    /*
        マウスカーソルと一緒に移動する 
    　　見た目をかえる？
    */

    //クリックを話した時の関数
    /*
        使用範囲に当たっていれば　使用　それ以外れあれば手札に戻る
    */

    public void Test()
    {
        Debug.Log("クリック");
    }
}
