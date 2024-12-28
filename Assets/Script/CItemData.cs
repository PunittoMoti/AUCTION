using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemStatus;

[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class CItemData : ScriptableObject
{
    [SerializeField] string mName;                  //�A�C�e����
    [SerializeField] int mPrice;                    //�l�i
    [SerializeField] ITEMSTATUS mItemStatus;        //�A�C�e���̎��
    [SerializeField] string mItemText;              //�A�C�e������
    [SerializeField] Sprite mIcon;                  //�A�C�R��
    [SerializeField] GameObject mCatalogPrefab;     //�J�^���O��Prefab�@��ITEMSTATUS���J�^���O�̂ݎg�p

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
        return mItemText;
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
