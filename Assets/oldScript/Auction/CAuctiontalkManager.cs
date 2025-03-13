using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CAuctiontalkManager : MonoBehaviour
{
    CAuctionManager mAuctionManager;    //オークションシーンのGameManager
    CItemData mItemdate;                //掲示中のアイテム


    //縦　145　横　110
    bool mIsStart;  //開始
    bool mSideflag; //左右

    float mPositionY;   //縦軸
    float mTime;        //サイクル時間
    float mSetTime;        //サイクル時間

    [SerializeField]List<string> mTalkTexts;    //メッセージリスト
    GameObject mUseObject;      //使用するトークオブジェクト
    TMP_Text mReadtext;         //アイテム紹介テキスト



    // Start is called before the first frame update
    void Start()
    {
        //オークションシーンのGameManager取得
        mAuctionManager = GameObject.Find("GameManager").GetComponent<CAuctionManager>();
        //アイテム紹介用テキストメッシュ取得
        mReadtext = GameObject.Find("ReadText").GetComponent<TMP_Text>();

        mSetTime = Random.Range(2.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //掲示中のアイテム情報取得
        mItemdate = mAuctionManager.GetNowItemdate();
        //アイテム紹介テキスト更新
        mReadtext.text = mItemdate.GetReadText();

        //オークション中でなければ更新なし
        if (!mAuctionManager.GetIsPlay()) 
        {
            mTime = 0.0f;
            return;
        } 


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
            mPositionY = Random.Range(-20.0f, 20.0f);

            float PositionX;
            // TalkObjectプレハブをGameObject型で取得
            mUseObject = (GameObject)Resources.Load("AuctiontalkObject");

            //X座標決定
            if (mSideflag)
            {
                //右サイド
                PositionX = 110.0f;
            }
            else
            {
                //左サイド
                PositionX = -110.0f;
            }

            // TalkObjectプレハブを元に、インスタンスを生成、
            GameObject obj = Instantiate(mUseObject, GameObject.Find("TalkCanvas").transform.position, Quaternion.identity, GameObject.Find("TalkCanvas").transform);
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector3(PositionX, mPositionY, 0);
            //テキストセット
            obj.GetComponent<CAuctiontalkObject>().SetTalkText(mTalkTexts[Random.Range(0, mTalkTexts.Count)]);


            //生成終了
            mIsStart = false;
            //時間初期化
            mTime = 0f;
            //生成時間再設定
            mSetTime = Random.Range(1.0f, 2.0f);
        }

    }
}
