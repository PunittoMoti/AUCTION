using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CItemList : MonoBehaviour
{
     List<CItemObject> mItemObjects = new List<CItemObject>();
    List<GameObject> mItems;

    // Start is called before the first frame update
    void Start()
    {
        //�q�I�u�W�F�N�g�擾
        Transform transform = this.transform;
        mItems = new GameObject[transform.childCount];
    }

    // Update is called once per frame
    void Update()
    {
        //mItemObjects��ǂ݂���Ŏq�I�u�W�F�N�g�̃��X�g�Ɉ��ɑ��
    }

    //�A�C�e���ǉ�
    void AddItem(CItemObject item)
    {
        mItemObjects.Add(item);
    }
}
