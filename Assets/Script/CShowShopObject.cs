using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static ItemStatus;


public class CShowShopObject : MonoBehaviour
{
    CItemObject mShowItemdata;
    GameObject mCheckGameObject;

    string mName;                  //�A�C�e����
    int mPrice;                    //�l�i
    ITEMSTATUS mItemStatus;        //�A�C�e���̎��
    string mItemText;              //�A�C�e������
    Sprite mIcon;                  //�A�C�R��

    // Start is called before the first frame update
    void Start()
    {
        if (CMoneyManager.sMoneyManager == null)
        {
            CMoneyManager.sMoneyManager = new CMoneyManager();

            //�f�o�b�O�����@�����̍s�̂�
            CMoneyManager.sMoneyManager.AddMoney(1000);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�A�C�e���I�u�W�F�N�g�E�f�[�^�̎擾
    public void SetItemObject(CItemObject item,GameObject gameObject)
    {
        mName = item.GetItemName();
        mPrice = item.GetItemPrice();
        mItemStatus = item.GetItemStatus();
        mItemText = item.GetItemText();
        mIcon = item.GetItemIcon();

        //�擾��������K�p
        transform.Find("Canvas/Name").gameObject.GetComponent<TMP_Text>().text = mName;
        transform.Find("Canvas/ItemText").gameObject.GetComponent<TMP_Text>().text = mItemText;
        transform.Find("Icon").gameObject.GetComponent<SpriteRenderer>().sprite = mIcon;

        mCheckGameObject = gameObject;
        mShowItemdata = item;
    }

    //�w�����̔���
    public void BuyItem()
    {
        if (mShowItemdata.GetItemPrice() > CMoneyManager.sMoneyManager.GetMoneyValue()) 
        {
            Debug.Log("�����s��");
            return;
        }

        CMoneyManager.sMoneyManager.PayMoney(mShowItemdata.GetItemPrice());

        Debug.Log("�w���I�I�@�c����z�F"+ CMoneyManager.sMoneyManager.GetMoneyValue());
    }

}
