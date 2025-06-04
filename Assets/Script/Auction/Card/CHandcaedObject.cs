using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHandcaedObject : MonoBehaviour
{

    public List<CCardObject> mHandcaeds;//手札　カードオブジェクト配列(可変)
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

    //手札受け渡し
    public void SetHandcaeds(List<CCardObject> Handcaeds)
    {
        mHandcaeds = Handcaeds;
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
                //生成したものをカードオブジェクトのリストに追加
                mCardObjects.Add(obj);
                //生成時に対応する配列のデータをカードオブジェクトに受け渡し

            }
            //位置調整
            for(int i=0; i < mCardObjects.Count; i++)
            {
                //位置を計算して設定
                mCardObjects[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(276.5f + (400/ mCardObjects.Count * (i+1)), 75f);
                //位置記録
                mCardObjects[i].GetComponent<CCardObject>().SetHandCardPos(mCardObjects[i].GetComponent<RectTransform>().anchoredPosition);
            }
        }
        //配列数が子オブジェクトの数より少なければ
        else if(mHandcaeds.Count < this.gameObject.transform.childCount)
        {
            //削除
        }





        // TalkObjectプレハブを元に、インスタンスを生成、
        //obj.GetComponent<RectTransform>().anchoredPosition = new Vector3(PositionX, mPositionY, 0);
    }
    //手札ドロー時に位置調整
}
