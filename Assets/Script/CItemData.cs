using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemStatus;

[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class CItemData : ScriptableObject
{
    [SerializeField] string mName;                  //�A�C�e����
    [SerializeField] int mPrice;                    //���i
    [SerializeField] int mPriceupvalue;             //�㏸���i
    [SerializeField] int mSellvalue;                //���p���i
    [SerializeField] ITEMSTATUS mItemStatus;        //�A�C�e���̎��
    [SerializeField] string mItemtext;              //�A�C�e�������i�T�v�j
    [SerializeField] string mItemsecrettext;        //�A�C�e�������i�ڍׁj
    [SerializeField] string mReadtext;              //�A�C�e���Љ�
    [SerializeField] Sprite mIcon;                  //�A�C�R��
    [SerializeField] GameObject mCatalogPrefab;     //�J�^���O��Prefab�@��ITEMSTATUS���J�^���O�̂ݎg�p

    //�A�C�e�����擾
    public string GetItemName()
    {
        return mName;
    }

    //���i�擾
    public int GetItemPrice()
    {
        return mPrice;
    }

    //�㏸���i�擾
    public int GetPriceUpValue()
    {
        return mPriceupvalue;
    }

    //���p���i�擾
    public int GetSellvalue()
    {
        return mSellvalue;
    }


    //��ގ擾
    public ITEMSTATUS GetItemStatus()
    {
        return mItemStatus;
    }

    //�A�C�e���e�L�X�g�i�T�v�j�擾
    public string GetItemText()
    {
        return mItemtext;
    }

    //�A�C�e���e�L�X�g(�ڍ�)�擾
    public string GetItemSecretText()
    {
        return mItemsecrettext;
    }



    //�A�C�e���Љ�e�L�X�g�擾
    public string GetReadText()
    {
        return mReadtext;
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
}
