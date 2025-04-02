using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CTextUI : MonoBehaviour,IUI
{
   [SerializeField] List<TalkList> mTalkLists = new List<TalkList>();

    [System.Serializable]
    class TalkList
    {
        public List<string> mTalkList = new List<string>();
    }

    TMP_Text mText;
    int mTalknumber;
    int mTalklistnumber;

    // Start is called before the first frame update
    void Start()
    {
        mText = transform.Find("TalkText").gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //テキスト送り
            UIAction();
        }
    }

    //UI実行時の処理内容
    public void UIAction()
    {
        //テキスト送りor次の会話
        //配列より多くなったらイベント終了（仮でリターンしている）
        if (mTalkLists[mTalklistnumber].mTalkList.Count-2 < mTalknumber) return;
        mTalknumber++;
        mText.text = mTalkLists[mTalklistnumber].mTalkList[mTalknumber];
    }

    //どのTalkか選択
    public void SetTalklistnumber(int Number)
    {
        mTalklistnumber = Number;

        GameObject.Find("charaImage00").GetComponent<Image>().enabled = true;
        GameObject.Find("charaImage01").GetComponent<Image>().enabled = true;
        GameObject.Find("charaImage02").GetComponent<Image>().enabled = true;
    }
    //モジオクイリシラベテ
}
