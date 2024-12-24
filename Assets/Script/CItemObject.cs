using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemStatus;

public class CItemObject : MonoBehaviour
{
    string mName;                  //�A�C�e����
    int mPrice;                    //�l�i
    ITEMSTATUS mItemStatus;        //�A�C�e���̎��
    string mItemText;              //�A�C�e������

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

    //�A�C�e���f�[�^�̎擾
    public void SetItemData(CItemData item)
    {
        mName = item.GetItemName();
        mPrice = item.GetItemPrice();
        mItemStatus = item.GetItemStatus();
        mItemText = item.GetItemText();
    }


}