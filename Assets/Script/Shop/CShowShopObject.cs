using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static ItemStatus;
using UnityEngine.UI;


public class CShowShopObject : MonoBehaviour
{
    CItemData mShowItemdata;
    GameObject mCheckGameObject;

    string mName;                  //�A�C�e����
    int mPrice;                    //�l�i
    //ITEMSTATUS mItemStatus;        //�A�C�e���̎��
    string mItemText;              //�A�C�e������
    Sprite mIcon;                  //�A�C�R��

    CShopManager mShopmanager;     //�V���b�v�}�l�[�W���[


    // Start is called before the first frame update
    void Start()
    {
        if (CMoneyManager.sMoneyManager == null)
        {
            CMoneyManager.sMoneyManager = new CMoneyManager();

            //�f�o�b�O�����@�����̍s�̂�
            CMoneyManager.sMoneyManager.AddMoney(100000);
        }

        mShopmanager = GameObject.Find("ShopManager").GetComponent<CShopManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�A�C�e���I�u�W�F�N�g�E�f�[�^�̎擾
    public void SetItemObject(CItemData item,GameObject gameObject)
    {
        mName = item.GetItemName();
        mPrice = item.GetItemPrice();
        //mItemStatus = item.GetItemStatus();
        mItemText = item.GetItemText();
        mIcon = item.GetItemIcon();

        //�擾��������K�p
        transform.Find("Name").gameObject.GetComponent<TMP_Text>().text = mName;
        transform.Find("ItemText").gameObject.GetComponent<TMP_Text>().text = mItemText;
        transform.Find("Icon").gameObject.GetComponent<Image>().sprite = mIcon;

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

        //�A�C�e�����X�g����������Ă��Ȃ���ΐ���
        if (SItemList.Items == null) SItemList.Items = new List<CItemData>();
        //�A�C�e�����X�g�ɒǉ�
        SItemList.AddItemList(mShowItemdata);

        //�x��
        CMoneyManager.sMoneyManager.PayMoney(mShowItemdata.GetItemPrice());
        
        //���i�I�̃A�C�e���𔄂�؂�ɕύX
        mCheckGameObject.GetComponent<CShopItemObject>().NullItem();


        //�ڍׂ�\�����Ă���A�C�e���𔄂�؂�ɕύX
        transform.Find("Name").gameObject.GetComponent<TMP_Text>().text = "sold out";
        transform.Find("ItemText").gameObject.GetComponent<TMP_Text>().text = "sold out";
        transform.Find("Icon").gameObject.GetComponent<Image>().sprite = mShopmanager.GetSoldoutIcon();


        Debug.Log("�w���I�I�@�c����z�F"+ CMoneyManager.sMoneyManager.GetMoneyValue());
    }

}
