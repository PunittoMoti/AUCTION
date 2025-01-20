using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CCallValueCounter : MonoBehaviour
{
    float mCallUpValue;
    GameObject mManagerObject;
    TMP_Text mCallUpText;


    // Start is called before the first frame update
    void Start()
    {
        //GameManagerオブジェクトを取得
        mManagerObject = GameObject.Find("GameManager");
        //テキストのコンポーネントを取得
        mCallUpText = this.GetComponent<TMP_Text>();
        //表示数値初期化
        mCallUpValue = 2.0f;
        mCallUpText.SetText("×" + "{0:00}", mCallUpValue);

    }

    // Update is called once per frame
    void Update()
    {
        SetCallUpValue();
    }

    //宣言倍率更新
    public void SetCallUpValue()
    {
        mCallUpValue = (float)mManagerObject.GetComponent<CAuctionManager>().GetCallUpValue();
        mCallUpText.SetText("×"+"{0:00}", mCallUpValue);
    }
}


