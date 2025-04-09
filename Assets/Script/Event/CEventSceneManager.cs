using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CEventSceneManager : MonoBehaviour
{
    [SerializeField] List<TalkList> mTalkLists = new List<TalkList>();//会話データ

    [System.Serializable]
    class TalkList
    {
        public List<string> mTalkList = new List<string>();
    }

    TMP_Text mText;
    int mTalklistnumber;

    GameObject[] mEventobject = new GameObject[2];//イベントで操作するObject


    // Start is called before the first frame update
    void Start()
    {
        //オブジェクト取得
        mEventobject[0] = GameObject.Find("EventSelectUI");
        mEventobject[1] = GameObject.Find("EventMainUI");

        mEventobject[1].GetComponent<Canvas>().enabled=false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //どのTalkか選択
    public void SetTalklistnumber(int Number)
    {
        mTalklistnumber = Number;

        mEventobject[0].SetActive(false);
        mEventobject[1].GetComponent<Canvas>().enabled = true;
        //会話内容送信
        mEventobject[1].GetComponent<CTalkUI>().SetTalkList(mTalkLists[mTalklistnumber].mTalkList);
    }
}
/*
初期選択
会話ウインドウ表示
テキスト送り
終了 
 */