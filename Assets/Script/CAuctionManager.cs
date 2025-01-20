using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAuctionManager : MonoBehaviour
{
    [SerializeField] CItemData mitemData;
    CPriceObject mPriceObject;

    [SerializeField] int mAddValue;
    int mCallValue;

    // Start is called before the first frame update
    void Start()
    {
        mPriceObject = GameObject.Find("NowPrice").GetComponent<CPriceObject>();
        mCallValue = 2;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetItemPrice()
    {
        return mitemData.GetItemPrice();
    }

    public int GetCallUpValue()
    {
        return mCallValue;
    }


    //����̉��Z����
    public void PriceUp()
    {
        mPriceObject.AddPoint(mAddValue);
    }

    //�錾�̉��Z����
    public void PriceCallUp()
    {
        mPriceObject.CallUpPoint(mCallValue);
        mCallValue = 2;
    }

    //�錾�̔{���㏸����
    public void CallValueUp()
    {
        mCallValue += 1;
        
        //����ݒ�
        if (mCallValue > 5)
        {
            mCallValue = 5;
        }
    }

    //�錾�̔{�����~����
    public void CallValueDown()
    {
        mCallValue -= 1;

        //�����ݒ�
        if (mCallValue < 2)
        {
            mCallValue = 2;
        }
    }




}
