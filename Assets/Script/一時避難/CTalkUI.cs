using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CTalkUI : MonoBehaviour,IUI
{
    List<string> mTalkList = new List<string>();//会話内容データ

    TMP_Text mText;
    int mTalknumber;

    bool[] mIsstopper= new bool[2]; //更新止めの変数

    GameObject[] mTalkobject = new GameObject[3];//会話で操作するObject

    [SerializeField] List<Sprite> mTestsprites;

    // Start is called before the first frame update
    void Start()
    {

        //オブジェクト取得
        mTalkobject[0] = GameObject.Find("charaImage02");//中央
        mTalkobject[1] = GameObject.Find("charaImage00");//左
        mTalkobject[2] = GameObject.Find("charaImage01");//右

        mText = transform.Find("TalkUI/TalkText").gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!mIsstopper[0]) return;

        if (Input.GetMouseButtonDown(0)&& mIsstopper[1])
        {
            //テキスト送り
            UIAction();
        }
        else if(Input.GetMouseButtonDown(0))
        {
            mIsstopper[1] = true;
        }
    }

    //UI実行時の処理内容
    public void UIAction()
    {
        //テキスト送りor次の会話
        //配列より多くなったらイベント終了 遷移する
        if (mTalkList.Count - 2 < mTalknumber) 
        {
            GameObject.Find("GameManager").GetComponent<CSceneMoveObject>().MoveScene();
        }

        mTalknumber++;
        CheckTalkCommand();
        mText.text = mTalkList[mTalknumber].Substring(2);
    }

    //トークリスト取得
    public void SetTalkList(List<string> talks)
    {
        mTalkList = talks;
        //会話番号初期化
        mTalknumber = 0;
        CheckTalkCommand();
        mText.text = mTalkList[mTalknumber].Substring(2);
        mIsstopper[0] = true;
    }

    //コマンド確認
    void CheckTalkCommand()
    {
        //
        Debug.Log(mTalkList[mTalknumber]);
        string t = mTalkList[mTalknumber].Substring(0,1);
        Debug.Log(t);
        int character = int.Parse(t);
        t = mTalkList[mTalknumber].Substring(1, 1);
        int Textmode = int.Parse(t);
        //発言中のキャラクタ取得
        switch (character)
        {
            case 0:
                mTalkobject[0].GetComponent<Image>().sprite = mTestsprites[0];
                break;
            case 1:
                mTalkobject[0].GetComponent<Image>().sprite = mTestsprites[1];
                break;
            case 2:
                mTalkobject[0].GetComponent<Image>().sprite = mTestsprites[2];
                break;
        }



        //テキスト種類取得
    }
}
