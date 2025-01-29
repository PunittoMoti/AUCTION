using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CShopItemObject : MonoBehaviour
{
    CItemData mdate;                //�A�C�e���f�[�^
    Sprite mIcon;                    //�A�C�e���摜
    string mName;                   //�A�C�e����
    GameObject mShowitemobject;   //�I�����̃A�C�e���\���I�u�W�F�N�g
    bool IsSoldout;                //����؂�t���O


    CShopManager mShopmanager;     //�V���b�v�}�l�[�W���[


    //�J�^���O�p�̃A�C�e�����X�g�K�v

    // Start is called before the first frame update
    void Start()
    {
        mShowitemobject = GameObject.Find("ShowShopObject");
        mShopmanager = GameObject.Find("ShopManager").GetComponent<CShopManager>();
        IsSoldout = false;
        this.transform.Find("PickImage").gameObject.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //(GameObject)Resources.Load("AuctiontalkObject");
    }


    //�A�C�e���f�[�^�̎擾
    public void SetItemData(CItemData item)
    {
        if (IsSoldout) return;
        mdate = item;
        mName = item.GetItemName();
        mIcon = item.GetItemIcon();

        /*
        //�J�^���O�������ꍇPrefab�擾
        if (mItemStatus == ITEMSTATUS.CATALOG)
        {
            mCatalogPrefab = item.GetCatalogPrefab();
        }
        */

        //�擾��������K�p
        transform.Find("Name").gameObject.GetComponent<TMP_Text>().text = mName;
        transform.Find("Icon").gameObject.GetComponent<Image>().sprite = mIcon;

    }

    //����؂�
    public void NullItem()
    {
        //�擾��������K�p
        transform.Find("Name").gameObject.GetComponent<TMP_Text>().text = "sold out";
        transform.Find("Icon").gameObject.GetComponent<Image>().sprite = mShopmanager.GetSoldoutIcon();
        IsSoldout = true;
    }

    //�m�F���A�C�e���փf�[�^�킽��
    public void SetShowItemObject()
    {
        if (IsSoldout) return;
        mShowitemobject.GetComponent<CShowShopObject>().SetItemObject(mdate, this.gameObject);
    }

    //�����J�[�\���\��
    public void ActivePickupCursor()
    {
        if (IsSoldout) return;
        this.transform.Find("PickImage").gameObject.GetComponent<Image>().enabled = true;
    }

    //�����J�[�\����\��
    public void NoActivePickupCursor()
    {
        this.transform.Find("PickImage").gameObject.GetComponent<Image>().enabled = false;

    }
}
