using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShopManager : MonoBehaviour
{
    [SerializeField]Sprite mSoldouticon;
    // Start is called before the first frame update
    void Start()
    {
        //SGameStatus.AddMoney(100000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite GetSoldoutIcon()
    {
        return mSoldouticon;
    }
}
