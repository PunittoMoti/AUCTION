using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAuctionMessageManager : MonoBehaviour
{

    //縦　145　横　110

    bool mSideflag; //左右
    bool mIsStart;  //開始

    float mPositionY;   //縦軸
    float mTime;        //サイクル時間
    float mSetTime;        //サイクル時間

    [SerializeField]List<string> mTalkTexts;    //メッセージリスト

    GameObject mTalkprefab;     //トークオブジェクトのプレハブ
    GameObject mUseObject;      //使用するトークオブジェクト
    // Start is called before the first frame update
    void Start()
    {
        mIsStart = false;
        mSetTime = Random.Range(2.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!mIsStart)
        {
            mTime += Time.deltaTime;
            if (mTime >= mSetTime) mIsStart = true;
        }
        else
        {
            //左右ランダム
            if (Random.value > 0.5f) mSideflag = true;
            else mSideflag = false;

            //Y座標決定
            mPositionY = Random.Range(-145.0f, 145.0f);

            float PositionX;
            //X座標決定
            if (mSideflag)
            {
                //右サイド
                // TalkObjectプレハブをGameObject型で取得
                mUseObject = (GameObject)Resources.Load("TalkObject");
                PositionX = 110.0f;
            }
            else
            {
                //左サイド
                // TalkObjectプレハブをGameObject型で取得
                mUseObject = (GameObject)Resources.Load("TalkObject");
                PositionX = -110.0f;
            }

            // TalkObjectプレハブを元に、インスタンスを生成、
            GameObject obj = Instantiate(mUseObject, GameObject.Find("TalkCanvas").transform.position, Quaternion.identity, GameObject.Find("TalkCanvas").transform);
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector3(PositionX, mPositionY,0);
            //テキストセット
            obj.GetComponent<CTalkObject>().SetTalkText(mTalkTexts[Random.Range(0, mTalkTexts.Count)]);


            //生成終了
            mIsStart = false;
            //時間初期化
            mTime = 0f;
            //生成時間再設定
            mSetTime = Random.Range(1.0f, 2.0f);
        }

    }
}
