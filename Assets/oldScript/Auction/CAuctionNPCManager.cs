using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CAuctionNPCManager : MonoBehaviour
{
    [SerializeField]List<GameObject> mNPCs;
    GameObject mNPC;
    CAuctionManager mAuctionManager;    //オークションシーンのGameManager
    int mNumber;

    bool mIsStart;  //開始
    bool mSideflag; //左右

    float mPositionY;   //縦軸
    float mTime;        //サイクル時間
    float mSetTime;        //サイクル時間

    Image mNPCicon;                    //キャラ画像


    // Start is called before the first frame update
    void Start()
    {
        //オークションシーンのGameManager取得
        mAuctionManager = GameObject.Find("GameManager").GetComponent<CAuctionManager>();
        mIsStart = false;
        mSetTime = Random.Range(2.0f, 3.0f);

    }

    // Update is called once per frame
    void Update()
    {        //オークション中でなければ更新なし
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
            //生成終了
            mIsStart = false;
            //時間初期化
            mTime = 0f;
            //生成時間再設定
            mSetTime = Random.Range(5.0f, 10.0f);


            //左右ランダム
            if (Random.value > 0.5f) mSideflag = true;
            else mSideflag = false;

            //Y座標決定
            mPositionY = Random.Range(-20.0f, 20.0f);

            float PositionX;

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

            mNumber = Random.Range(0, 100) % 2;

            switch (mNumber)
            {
                case 0:
                    mNPC = mNPCs[0];
                    break;
                case 1:
                    mNPC = mNPCs[1];
                    break;
            }

            // TalkObjectプレハブを元に、インスタンスを生成、
            GameObject obj = Instantiate(mNPC, GameObject.Find("NPCCanvas").transform.position, Quaternion.identity, GameObject.Find("NPCCanvas").transform);
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector3(PositionX, mPositionY, 0);
        }

    }
}
