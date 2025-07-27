using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHandcaedObject : MonoBehaviour
{
    GameObject mAuctionscenemanager;//オークションSceneマネジャー

    public List<CCardObject> mHandcaeds;//手札　カードオブジェクト配列(可変)
    public List<CCardObject> mUeshandcaeds;//使用中の手札　カードオブジェクト配列(可変)
    List<GameObject> mCardObjects;//カードオブジェクトを持っておく配列 (可変)


    [SerializeField]
    GameObject mOriginCardObject;
    // Start is called before the first frame update
    void Start()
    {
        mCardObjects = new List<GameObject>();
        //AuctionSceneマネジャー取得
        mAuctionscenemanager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        mAuctionscenemanager.GetComponent<CAuctionSceneManager>().SetUesCard(mUeshandcaeds);
    }

    //手札受け渡し
    public void SetHandcaeds(List<CCardObject> Handcaeds)
    {
        mHandcaeds = Handcaeds;
    }

    public void SortHandocaeds()
    {
        for (int i = 0; i < mCardObjects.Count; i++)
        {
            //位置を計算して設定
            mCardObjects[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(276.5f + (400 / mCardObjects.Count * (i + 1)), 75f);
            //位置記録
            mCardObjects[i].GetComponent<CCardObject>().SetHandCardPos(mCardObjects[i].GetComponent<RectTransform>().anchoredPosition);
        }

    }

    //手札ドロー時にオブジェクト生成処理
    public void CreateCard()
    {
        //配列数が子オブジェクトの数より多ければ
        if(mHandcaeds.Count > this.gameObject.transform.childCount)
        {
            //手札が5枚になるまでデータを追加
            for (int i = this.gameObject.transform.childCount; i < mHandcaeds.Count; i++)
            {
                //生成
                GameObject obj = Instantiate(mOriginCardObject, GameObject.Find("HandCards").transform.position, Quaternion.identity, GameObject.Find("HandCards").transform);
                //生成したカードに番号振り分け
                obj.GetComponent<CCardObject>().SetHandNumber(i);
                //生成したものをカードオブジェクトのリストに追加
                mCardObjects.Add(obj);

                //生成時に対応する配列のデータをカードオブジェクトに受け渡し

            }
            //位置調整
            SortHandocaeds();
        }
        //配列数が子オブジェクトの数より少なければ
        else if(mHandcaeds.Count < this.gameObject.transform.childCount)
        {
            //削除
        }

    }

    //手札使用時の処理
    public void UseCard()
    {
        for(int i=0;i< mUeshandcaeds.Count; i++)
        {
            //使用待機カード登録
            mAuctionscenemanager.GetComponent<CAuctionSceneManager>().SetUesCard(mUeshandcaeds);
        }
    }

    //手札使用時の処理
    public void SelectCard(CCardObject Card)
    {
        mUeshandcaeds.Add(Card);
    }

    //手札使用時の処理
    public void ReleaseCard(CCardObject Card)
    {
        for (int i = 0; i < mUeshandcaeds.Count; i++)
        {
            if(mUeshandcaeds[i].GetHandNumber() == Card.GetHandNumber())
            {
                mUeshandcaeds.RemoveAt(i);
            }
        }
    }

}
