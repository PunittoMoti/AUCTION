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

    // Start is called before the first frame update
    void Start()
    {
        
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


    }

    //全NPCの参加申請
    public void CheckJoinNPCs(CItemData selectitem)
    {
        //全NPCの参加申請
        for (int i = 0; i < mNpcs.Count; i++)//NPCの要素数分繰り返す
        {
            for (int j = 0; j < selectitem.GetNormalAccessNPCs().Count; j++)
            {

                //アイテムの条件とキャラの番号確認
                if (mNpcs[i].GetNPCNumber() == selectitem.GetNormalAccessNPCs()[j])
                {

                    //通常参加
                    mNpcs[i].SetActionpattern(1);
                    break;
                }
                //アイテムの条件とキャラの番号確認 執着　
                //執着の配列は通常より少ないためオーバーフロー防止のためiが配列数より多くないか確認してから執着判定
                else if (i <= selectitem.GetSpecialAccessNPCs().Count - 1)
                {
                    if (mNpcs[i].GetNPCNumber() == selectitem.GetSpecialAccessNPCs()[j])
                    {
                        //執着参加
                        mNpcs[i].SetActionpattern(2);
                        break;
                    }

                }
                else
                {
                    //不参加
                    mNpcs[i].SetActionpattern(0);
                }
            }


        }


        //全NPC参加演出
        for (int i = 0; i < mNpcs.Count; i++)
        {
            mNpcs[i].ActiveAnimationNPC();
        }
    }

    //全NPCの終了判定
    public void ActionEndNPCs()
    {
        for (int i = 0; i < mNpcs.Count; i++)
        {
            mNpcs[i].ActionEndNPC();
        }
    }


    //全NPCの初期化を行う
    public void ResultNPCs()
    {
        for(int i=0;i< mNpcs.Count; i++)
        {
            mNpcs[i].ResultNPC();
        }
    }
}
