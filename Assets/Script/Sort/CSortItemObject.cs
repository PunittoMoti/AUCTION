using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CSortItemObject : MonoBehaviour
{
    /*
    enum SORTITEMSEWQUENCE
    {
        ITEMSELECT,
        RESULT,
        ADDPARTS,
        END
    }
    */

    public enum SORTITEMSTATUS
    {
        DEFAULT,
        GET,
        BUY,
        ADDPARTS
    }


    CItemData mdate;                //�A�C�e���f�[�^
    string mName;                   //�A�C�e����
    List<CCheckBoxObject> mCheckboxs;    //�`�F�b�N�{�b�N�X�I�u�W�F�N�g 
    List<bool> mIsCheckstatus;            //�`�F�b�NStatus
    SORTITEMSTATUS mSortItemStatus;       //

    // Start is called before the first frame update
    void Start()
    {
        //�`�F�b�N�{�b�N�X�擾
        mCheckboxs = new List<CCheckBoxObject>();
        mCheckboxs.Add(this.transform.Find("Get").GetComponent<CCheckBoxObject>());
        mCheckboxs.Add(this.transform.Find("Buy").GetComponent<CCheckBoxObject>());
        mCheckboxs.Add(this.transform.Find("AddParts").GetComponent<CCheckBoxObject>());

        //mCheckboxs[0] = this.transform.Find("Get").GetComponent<CCheckBoxObject>();
        //mCheckboxs[1] = this.transform.Find("Buy").GetComponent<CCheckBoxObject>();
        //mCheckboxs[2] = this.transform.Find("AddParts").GetComponent<CCheckBoxObject>();

        //�`�F�b�N�{�b�N�X��Ԏ擾
        mIsCheckstatus = new List<bool>();
        mIsCheckstatus.Add(mCheckboxs[0].GetIsCheck());
        mIsCheckstatus.Add(mCheckboxs[1].GetIsCheck());
        mIsCheckstatus.Add(mCheckboxs[2].GetIsCheck());

        //mIsCheckstatus[0] = mCheckboxs[0].GetIsCheck();
        //mIsCheckstatus[1] = mCheckboxs[1].GetIsCheck();
        //mIsCheckstatus[2] = mCheckboxs[2].GetIsCheck();

        mSortItemStatus = SORTITEMSTATUS.DEFAULT;

        //�擾��������K�p
        transform.Find("NameBack/Name").gameObject.GetComponent<TMP_Text>().text = mName;


    }

    // Update is called once per frame
    void Update()
    {
        //��ԏ�����
        mSortItemStatus = SORTITEMSTATUS.DEFAULT;

        for (int cnt = 0; cnt < 3; cnt++)
        {
            //Debug.Log("���@" + mIsCheckstatus.Count);
            mIsCheckstatus[cnt] = mCheckboxs[cnt].GetIsCheck();

            if (mIsCheckstatus[cnt])
            {
                switch (cnt)
                {
                    case 0:
                        mSortItemStatus = SORTITEMSTATUS.GET;
                        break;
                    case 1:
                        mSortItemStatus = SORTITEMSTATUS.BUY;
                        break;
                    case 2:
                        mSortItemStatus = SORTITEMSTATUS.ADDPARTS;
                        break;

                }
            }
        }


    }

    //�X�e�[�^�X�Q�b�g
    public int GetSortItemStatus()
    {
        return (int)mSortItemStatus;
    }

    //�A�C�e���f�[�^�̎擾
    public void SetItemData(CItemData item)
    {
        mdate = item;
        mName = item.GetItemName();
        /*
        //�J�^���O�������ꍇPrefab�擾
        if (mItemStatus == ITEMSTATUS.CATALOG)
        {
            mCatalogPrefab = item.GetCatalogPrefab();
        }
        */

        //�擾��������K�p
        transform.Find("NameBack/Name").gameObject.GetComponent<TMP_Text>().text = mName;
    }

    //���p���i�擾
    public int GetItemBuyPrice()
    {
        return mdate.GetItemPrice();
    }
}
