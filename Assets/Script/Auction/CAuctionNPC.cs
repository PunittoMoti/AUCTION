using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CAuctionNPC : MonoBehaviour
{
    CAuctionManager mAuctionManager;    //オークションシーンのGameManager
    [SerializeField] Image mNPCicon;                    //キャラ画像
    TMP_Text mActionText;               //アクションテキスト
    int mActionvalue;
    float mTime;
    [SerializeField] int[] mAdd;
    [SerializeField] int[] mCallup;

    // Start is called before the first frame update
    void Start()
    {
        //オークションシーンのGameManager取得
        mAuctionManager = GameObject.Find("GameManager").GetComponent<CAuctionManager>();
        mActionText = this.gameObject.transform.Find("ActionText").GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        mTime += Time.deltaTime;

        if (mTime >= 1.0f)
        {
            Destroy(this.gameObject);
        }

    }

    public void NPCAction()
    {

        if(mActionvalue >= mAdd[0] && mActionvalue <= mAdd[1])
        {
            AddMove();
        }
        else if (mActionvalue >= mCallup[0] && mActionvalue <= mCallup[1])
        {

            CallupMove();
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    //挙手行動処理
    void AddMove()
    {
        mAuctionManager.AddPricevalue();
        mActionText.text = "挙手";
    }

    //宣言行動処理
    void CallupMove()
    {
        int count= Random.Range(2, 5);
        mAuctionManager.CallupPricevalue(count);
        mActionText.SetText("宣言　×" + "{0:1}", (float)count);

    }

    public int[] GetAdd()
    {
        return mAdd;
    }

    public int[] GetCallup()
    {
        return mCallup;
    }

}
