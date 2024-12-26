using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CItemList : MonoBehaviour
{
    List<CItemObject> mItemObjects = new List<CItemObject>();
    List<GameObject> mItems;
    List<int> mItemNumber = new List<int>() { 0,2,1,2};

    CItemDataBase mItemDateBase;

    // Start is called before the first frame update
    void Start()
    {
        //�q�I�u�W�F�N�g�擾
        mItems = new List<GameObject>();

        //�f�[�^�x�[�X�擾
        mItemDateBase = Resources.Load<CItemDataBase>("Items/ItemDataBase");

        //�I�u�W�F�N�g�v�f���m��
        for(int count = 0; count < this.transform.childCount; count++)
        {
            mItems.Add(this.transform.GetChild(count).gameObject);
        }

        Debug.Log("���X�g���ځF" + mItems.Count);

        //�A�C�e���f�[�^�x�[�X����ԍ��z��̓��e�Ńf�[�^���擾�����X�g�Ɏ擾
        for (int count = 0;count < mItemNumber.Count; count++)
        {
            if (this.transform.childCount-1 < count)
            {
                Debug.Log("�u���C�N");
                break;
            }


            CItemData itemData = mItemDateBase.GetItemData(mItemNumber[count]);
            mItems[count].GetComponent<CItemObject>().SetItemData(itemData);
            
            //�A�C�e�����X�g�Ɏ擾
            AddItem(mItems[count].GetComponent<CItemObject>());

            Debug.Log("���F" + mItemNumber.Count);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //���X�g�X�V����
    }

    //�A�C�e���ǉ�
    void AddItem(CItemObject item)
    {
        mItemObjects.Add(item);
    }
}


/*
 �q�I�u�W�F�N�g�擾
��
�ԍ��z��ǂݍ��݃e�L�X�g�t�@�C���ǂݍ���
��
���X�g�ɃA�C�e���f�[�^�𗘗p���Ĕz��̔ԍ��ɍ��������̂����ɓ���Ă���
��

 
 */
