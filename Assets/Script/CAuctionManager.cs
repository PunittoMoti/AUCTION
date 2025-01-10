using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAuctionManager : MonoBehaviour
{
    [SerializeField] CItemData mitemData;
    CPriceObject mPriceObject;

    [SerializeField] int mAddValue;

    // Start is called before the first frame update
    void Start()
    {
        mPriceObject = GameObject.Find("NowPrice").GetComponent<CPriceObject>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetItemPrice()
    {
        return mitemData.GetItemPrice();
    }

    //ãìéËÇÃâ¡éZèàóù
    public void PriceUp()
    {
        mPriceObject.AddPoint(mAddValue);
    }

}
