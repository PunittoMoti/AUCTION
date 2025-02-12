using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSortItemList : MonoBehaviour
{
    List<CSortItemObject> mItemObjects = new List<CSortItemObject>();
    List<GameObject> mItems = new List<GameObject>();
    [SerializeField] List<int> mItemNumber = new List<int>();

    CItemDataBase mItemDateBase;

    // Start is called before the first frame update
    void Start()
    {
        //�f�[�^�x�[�X�擾
        mItemDateBase = Resources.Load<CItemDataBase>("Items/ItemDataBase");

        //�I�u�W�F�N�g�v�f���m��
        for (int count = 0; count < this.transform.childCount; count++)
        {
            mItems.Add(this.transform.GetChild(count).gameObject);
        }

        Debug.Log("���X�g���ځF" + mItems.Count);

        //�A�C�e���f�[�^�x�[�X����ԍ��z��̓��e�Ńf�[�^���擾�����X�g�Ɏ擾
        for (int count = 0; count < mItemNumber.Count; count++)
        {
            if (this.transform.childCount - 1 < count)
            {
                Debug.Log("�u���C�N");
                break;
            }


            CItemData itemData = mItemDateBase.GetItemData(mItemNumber[count]);
            mItems[count].GetComponent<CSortItemObject>().SetItemData(itemData);

            //�A�C�e�����X�g�Ɏ擾
            AddItem(mItems[count].GetComponent<CSortItemObject>());

            //Debug.Log("���Ɩ��O�F" + mItemObjects.Count+ mItems[count].GetComponent<CItemObject>().GetItemName());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //���X�g�X�V����
    }

    //�A�C�e���ǉ�
    void AddItem(CSortItemObject item)
    {
        mItemObjects.Add(item);
        Debug.Log("�I�u�W�F�N�g��" + this.name);
        Debug.Log("�ǉ��F" + mItemObjects.Count);

    }

    //�A�C�e�����擾
    public CSortItemObject GetItem(int itemNumber)
    {
        if (mItemObjects.Count - 1 < itemNumber)
        {
            Debug.Log("�v�f���I�[�o�[(GetItem)" + mItemObjects.Count);
        }

        return mItemObjects[itemNumber];
    }

    //�Q�[���I�u�W�F�N�g���X�g�擾
    public List<GameObject> GetGameObjectList()
    {
        return mItems;
    }

    //�A�C�e��List�擾
    public List<CSortItemObject> GetItemList()
    {
        Debug.Log("�I�u�W�F�N�g��" + this.name);
        Debug.Log("�v�f��(ListGet)" + mItemObjects.Count);

        return mItemObjects;
    }

    //���p���i�̍��v
    public int GetBuyPrice()
    {
        int price = 0;
        Debug.Log("�f�o�b�O");

        for (int count = 0; count < mItemObjects.Count; count++)
        {
            if (mItemObjects[count].GetSortItemStatus() == 2)
            {
                price += mItemObjects[count].GetItemBuyPrice();
            }
        }
        return price;
    }

    //�ڐA�`�F�b�N
    public bool GetAddPartsFlag()
    {
        for (int count = 0; count < mItemObjects.Count; count++)
        {
            if (mItemObjects[count].GetSortItemStatus() == 3)
            {
                return true;
            }
        }
        return false;
    }


    /*
    //���X�g�Ԃ̃A�C�e���ړ�
    public void MoveItem(CItemList list,int itemNumber)
    {
        //�A�C�e�����X�g�ɒǉ�
        mItemObjects.Add(list.GetItem(itemNumber));
        //Item���Z�b�g
        mItems[mItemObjects.Count-1].GetComponent<CItemObject>().SetItemObject(mItemObjects[mItemObjects.Count - 1]);
        //�ړ��O�̃f�[�^�폜 �Ȃ񂩈�����
        list.GetItem(itemNumber).RemoveItemObject();
        //�Q�Ɛ�̃��X�g�̃A�C�e���I�u�W�F�N�g�f�[�^�폜
        list.GetItemList().RemoveAt(itemNumber);
    }
    */
}
