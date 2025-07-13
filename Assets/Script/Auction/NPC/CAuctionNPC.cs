using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CAuctionNPC : MonoBehaviour
{
    /*
    どのキャラか
    なにに執着しているか
    参加条件　アイテムに持たせる　アイテムに申請を送ってその戻り値で判断
    降伏条件　キャラごとに持たせる インスペクターで設定　
    執着条件　アイテムに持たせる　アイテムに申請を送ってその戻り値で判断できるので参加条件の判定に執着の戻り値を用意
    執着終了条件　キャラごとに持たせる インスペクターで設定
    基本いくらまで出せるか
    思考時間

    採用の流れ
    NPC全員で金額を計算
    一番高いものが採用される
    採用されたものは8秒のリキャスト
    採用されなかったものは5秒のリキャスト
    PLが宣言したら全NPCは5秒のリキャスト
    
     */


    [SerializeField]int mNpcnumber;//NPC識別番号
    int mActionpattern;//行動パターン(0:不参加、1:参加、2:執着)
    int mNormalendpattern;//通常終了パターン
    int mCriticalendpattern;//執着終了パターン
    float mReactiontime;//反応までの待機時間


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //終了条件の判定(各キャラパターン別)
    void NormalEnd()
    {
        Debug.Log("終了条件");
        switch (mNormalendpattern)
        {
            case 0://
                break;
            case 1://
                break;
            case 2://
                break;
            case 3://
                break;
            case 4://
                break;
            case 5://
                break;
            case 6://
                break;
        }
    }
    //執着終了条件の判定(各キャラパターン別)
    void CriticalEnd()
    {
        Debug.Log("執着終了条件");
        switch (mCriticalendpattern)
        {
            case 0://
                break;
            case 1://
                break;
            case 2://
                break;
            case 3://
                break;
            case 4://
                break;
            case 5://
                break;
            case 6://
                break;
        }
    }


    //NPCの識別番号の取得
    public int GetNPCNumber()
    {
        return mNpcnumber;
    }

    //パターン設定
    public void SetActionpattern(int pattern)
    {
        mActionpattern = pattern;
    }

    //終了条件
    public void ActionEndNPC()
    {
        switch (mActionpattern)
        {
            case 1://参加
                   //終了条件の判定(パターン別)
                NormalEnd();
                break;
            case 2://執着
                   //執着終了条件の判定(パターン別)
                CriticalEnd();
                break;
        }
    }

    //NPCの初期化
    public void ResultNPC()
    {
        mActionpattern = 0;
        mReactiontime = 0.0f;
    }

    //参加・不参加・執着時のアイコン演出 動きは仮作成
    public void ActiveAnimationNPC()
    {
        if (mActionpattern == 1)
        {
            Debug.Log("NPC" + mNpcnumber + "が参加しました");
            this.gameObject.GetComponent<Image>().color = Color.white;
            this.GetComponent<RectTransform>().anchoredPosition = new Vector2(-500.0f, this.GetComponent<RectTransform>().anchoredPosition.y);//毎フレームx座標を0.1ずつプラス
        }
        else if (mActionpattern == 2)
        {
            Debug.Log("NPC" + mNpcnumber + "が参加しました");
            this.gameObject.GetComponent<Image>().color = Color.red;
            this.GetComponent<RectTransform>().anchoredPosition = new Vector2(-470.0f, this.GetComponent<RectTransform>().anchoredPosition.y);//毎フレームx座標を0.1ずつプラス
        }
        else
        {
            this.gameObject.GetComponent<Image>().color = Color.gray;
            this.GetComponent<RectTransform>().anchoredPosition = new Vector2(-530.0f, this.GetComponent<RectTransform>().anchoredPosition.y);//毎フレームx座標を0.1ずつプラス
        }
    }

}
