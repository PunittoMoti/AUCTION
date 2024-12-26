using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static ItemStatus;

public class CItemObject : MonoBehaviour
{
    string mName;                  //�A�C�e����
    int mPrice;                    //�l�i
    ITEMSTATUS mItemStatus;        //�A�C�e���̎��
    string mItemText;              //�A�C�e������
    Sprite mIcon;                  //�A�C�R��

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


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
        mIcon = item.GetItemIcon();

        //�擾��������K�p
        transform.Find("Canvas/Name").gameObject.GetComponent<TMP_Text>().text = mName;
        transform.Find("Icon").gameObject.GetComponent<SpriteRenderer>().sprite = mIcon;

    }


}