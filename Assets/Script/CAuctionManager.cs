using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAuctionManager : MonoBehaviour
{
    [SerializeField] CItemData mitemData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetItemPrice()
    {
        return mitemData.GetItemPrice();
    } 
}
