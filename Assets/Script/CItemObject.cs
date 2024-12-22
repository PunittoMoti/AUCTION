using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemStatus;

public class CItemObject : MonoBehaviour
{
    [SerializeField] string mName;                  //�A�C�e����
    [SerializeField] int mPrice;                    //�l�i
    [SerializeField] ITEMSTATUS mItemStatus;        //�A�C�e���̎��
    [SerializeField] string mItemText;              //�A�C�e������

/*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
*/

    //�A�C�e�����擾
    public string GetItemName()
    {
        return mName;
    }

    //�l�i�擾
    public int GetItemPrice()
    {
        return mPrice;
    }

    //��ގ擾
    public ITEMSTATUS GetItemStatus()
    {
        return mItemStatus;
    }

    //�A�C�e���e�L�X�g�擾
    public string GetItemText()
    {
        return mName;
    }

}