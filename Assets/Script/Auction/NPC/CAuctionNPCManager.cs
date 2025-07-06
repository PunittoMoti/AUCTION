using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAuctionNPCManager : MonoBehaviour
{
    /*
    全NPCからの反応を集約して一番高い額を出しているNPCを特定するManager
    全NPCを取得
     
     */

    List<CAuctionNPC> mNpcs;//全NPC
    GameObject mAuctionscenemanager;//オークションSceneマネジャー

    // Start is called before the first frame update
    void Start()
    {
        //AuctionSceneマネジャー取得
        mAuctionscenemanager = GameObject.Find("GameManager");
        //NPCリスト初期化
        mNpcs = new List<CAuctionNPC>();

        //各NPCの行動処理を取得
        mNpcs.Add(GameObject.Find("NPC_Greed").GetComponent<CAuctionNPC>());
        mNpcs.Add(GameObject.Find("NPC_ Lust").GetComponent<CAuctionNPC>());
        mNpcs.Add(GameObject.Find("NPC_Wrath").GetComponent<CAuctionNPC>());
        mNpcs.Add(GameObject.Find("NPC_Sloth").GetComponent<CAuctionNPC>());
        mNpcs.Add(GameObject.Find("NPC_Pride").GetComponent<CAuctionNPC>());

    }

    // Update is called once per frame
    void Update()
    {
        //使用待機カード登録
        int Phase = mAuctionscenemanager.GetComponent<CAuctionSceneManager>().GetPhase();

        //フェーズごとの行動　マーねーじゃーのフェーズを参照
        switch (Phase)
        {
            case 0://商品取得
                //出ているアイテム情報取得

                //全NPCの参加申請
                for ()//アイテムの参加条件の要素数分繰り返す
                {
                    for (int i = 0; i < mNpcs.Count; i++)
                    {
                        //アイテムの条件とキャラの番号確認
                        if ()//mNpcs[i]
                        {

                        }
                       
                    }
                }



                break;
            case 1://オークション中

                //状況確認　マネージャーに対して


                //終了条件
                ActionEndNPCs();

                break;
            case 2://商品落選直後　初期化を行う
                ResultNPCs();
                break;
        }
    }



    //全NPCの終了判定
    void ActionEndNPCs()
    {
        for (int i = 0; i < mNpcs.Count; i++)
        {
            mNpcs[i].ActionEndNPC();
        }
    }


    //全NPCの初期化を行う
    void ResultNPCs()
    {
        for(int i=0;i< mNpcs.Count; i++)
        {
            mNpcs[i].ResultNPC();
        }
    }
}
