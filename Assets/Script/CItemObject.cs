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
    GameObject mCatalogPrefab;     //�J�^���O��Prefab�@��ITEMSTATUS���J�^���O�̂ݎg�p


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

    //�A�C�e���A�C�R���擾
    public Sprite GetItemIcon()
    {
        return mIcon;
    }

    //�J�^���O�������ꍇPrefab�擾
    public GameObject GetCatalogPrefab()
    {
        return mCatalogPrefab;
    }



    //�A�C�e���f�[�^�̎擾
    public void SetItemData(CItemData item)
    {
        mName = item.GetItemName();
        mPrice = item.GetItemPrice();
        mItemStatus = item.GetItemStatus();
        mItemText = item.GetItemText();
        mIcon = item.GetItemIcon();

        //�J�^���O�������ꍇPrefab�擾
        if(mItemStatus == ITEMSTATUS.CATALOG)
        {
            mCatalogPrefab = item.GetCatalogPrefab();
        }

        //�擾��������K�p
        transform.Find("Canvas/Name").gameObject.GetComponent<TMP_Text>().text = mName;
        transform.Find("Icon").gameObject.GetComponent<SpriteRenderer>().sprite = mIcon;

    }

    //�A�C�e���I�u�W�F�N�g�f�[�^�̎擾
    public void SetItemObject(CItemObject item)
    {
        mName = item.GetItemName();
        mPrice = item.GetItemPrice();
        mItemStatus = item.GetItemStatus();
        mItemText = item.GetItemText();
        mIcon = item.GetItemIcon();

        //�J�^���O�������ꍇPrefab�擾
        if (mItemStatus == ITEMSTATUS.CATALOG)
        {
            mCatalogPrefab = item.GetCatalogPrefab();
        }


        //�擾��������K�p
        transform.Find("Canvas/Name").gameObject.GetComponent<TMP_Text>().text = mName;
        transform.Find("Icon").gameObject.GetComponent<SpriteRenderer>().sprite = mIcon;

    }

    //�A�C�e���I�u�W�F�N�g�f�[�^�̍폜
    public void RemoveItemObject()
    {
        //�J�^���O�������ꍇPrefab�Q�ƍ폜
        if (mItemStatus == ITEMSTATUS.CATALOG)
        {
            mCatalogPrefab =null;
        }

        mName = "----";
        mPrice = 0;
        mItemStatus = ITEMSTATUS.EMPTY;
        mItemText = "----";
        mIcon = null ;

        //�擾��������K�p
        transform.Find("Canvas/Name").gameObject.GetComponent<TMP_Text>().text = mName;
        transform.Find("Icon").gameObject.GetComponent<SpriteRenderer>().sprite = mIcon;

    }



}