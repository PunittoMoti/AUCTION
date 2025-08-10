using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHandcaedObject : MonoBehaviour
{
    //GameObject mAuctionscenemanager;//オークションSceneマネジャー

    //public List<CCardObject> mHandcaeds;//手札　カードオブジェクト配列(可変)
    public List<CCardObject> mUeshandcaeds;//使用中の手札　カードオブジェクト配列(可変)
    List<GameObject> mCardObjects;//カードオブジェクトを持っておく配列 (可変)


    [SerializeField]
    GameObject mOriginCardObject;
    // Start is called before the first frame update
    void Start()
    {
        mCardObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //カードオブジェクト配列取得
    public List<GameObject> GetCardObjects()
    {
        return mCardObjects;
    }

    //カードの位置調整
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
    public void CreateCard(List<CCardObject> Handcaeds)
    {
        //手札が5枚になるまでデータを追加
        for (int i = 0; i < Handcaeds.Count; i++)
        {
            //生成
            GameObject obj = Instantiate(mOriginCardObject, GameObject.Find("HandCards").transform.position, Quaternion.identity, GameObject.Find("HandCards").transform);

            //生成したカードに金額を設定
            obj.GetComponent<CCardObject>().SetMonye(Handcaeds[i].GetMonye());
            //生成したものをカードオブジェクトのリストに追加
            mCardObjects.Add(obj);

            //生成時に対応する配列のデータをカードオブジェクトに受け渡し

        }
        //位置調整
        SortHandocaeds();
    }

    //手札使用確定
    public void PayUesCards()
    {
        List<GameObject> insCardObjs = new List<GameObject>();
        for (int i = 0; i < mCardObjects.Count; i++)
        {
            if (mCardObjects[i].GetComponent<CCardObject>().GetisSelect())
            {
                mCardObjects[i].GetComponent<CCardObject>().ReleaseCard();
            }
            else
            {
                //使ったオブジェクトを除いた配列を作成
                insCardObjs.Add(mCardObjects[i]);
            }

        }

        //使ったオブジェクトを除いた配列で更新
        mCardObjects = insCardObjs;
    }

    ////手札受け渡し
    //public void SetHandcaeds(List<CCardObject> Handcaeds)
    //{
    //    mHandcaeds = Handcaeds;
    //}





    ////手札ドロー時にオブジェクト生成処理
    //public void CreateCard()
    //{
    //    //配列数が子オブジェクトの数より多ければ
    //    if(mHandcaeds.Count > this.gameObject.transform.childCount)
    //    {
    //        //手札が5枚になるまでデータを追加
    //        for (int i = this.gameObject.transform.childCount; i < mHandcaeds.Count; i++)
    //        {
    //            //生成
    //            GameObject obj = Instantiate(mOriginCardObject, GameObject.Find("HandCards").transform.position, Quaternion.identity, GameObject.Find("HandCards").transform);

    //            //生成したカードに番号振り分け
    //            obj.GetComponent<CCardObject>().SetHandNumber(i);
    //            //生成したカードに金額を設定
    //            obj.GetComponent<CCardObject>().SetMonye(mHandcaeds[i].GetMonye());
    //            //生成したものをカードオブジェクトのリストに追加
    //            mCardObjects.Add(obj);

    //            //生成時に対応する配列のデータをカードオブジェクトに受け渡し

    //        }
    //        //位置調整
    //        SortHandocaeds();
    //    }
    //    //配列数が子オブジェクトの数より少なければ
    //    else if(mHandcaeds.Count < this.gameObject.transform.childCount)
    //    {
    //        //削除
    //    }

    //}

    ////使用中の手札取得
    //public List<CCardObject> GetUseCards()
    //{
    //    return mUeshandcaeds;
    //}

    ////手札使用時の処理
    //public void SelectCard(CCardObject Card)
    //{
    //    mUeshandcaeds.Add(Card);
    //}

    ////手札使用時の処理
    //public void ReleaseCard(CCardObject Card)
    //{
    //    for (int i = 0; i < mUeshandcaeds.Count; i++)
    //    {
    //        if(mUeshandcaeds[i].GetHandNumber() == Card.GetHandNumber())
    //        {
    //            mUeshandcaeds.RemoveAt(i);
    //        }
    //    }
    //}

    //public void DeleteCard(int Cardnumber)
    //{
    //    for (int i = 0; i < mHandcaeds.Count; i++)
    //    {
    //        if (mHandcaeds[i].GetHandNumber() == Cardnumber)
    //        {
    //            mHandcaeds.RemoveAt(i);
    //        }
    //    }
    //}

    ////手札使用確定
    //public void PayUesCards()
    //{

    //    for (int i = 0; i < mCardObjects.Count; i++)
    //    {


    //        if (mCardObjects[i].GetComponent<CCardObject>().GetisSelect())
    //        {
    //            //Debug.Log("オブジェクト名：");
    //            mHandcaeds.RemoveAt(i);
    //            mCardObjects[i].GetComponent<CCardObject>().ReleaseCard();

    //        }

    //    }
    //    Debug.Log("オブジェクト数："+ mHandcaeds.Count) ;
    //    //mUeshandcaeds = new List<CCardObject>();
    //}

}
