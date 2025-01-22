using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CAuctioncatalogObject : MonoBehaviour
{
    CAuctionManager mAuctionManager;    //�I�[�N�V�����V�[����GameManager
    List<CItemData> mItemdates;         //�A�C�e�����X�g
    Image mItemicon;                    //�A�C�e���摜
    TMP_Text mItemname;                 //�A�C�e����
    TMP_Text mItemprice;                //�J�n���i
    TMP_Text mItempriceup;              //�㏸���i
    TMP_Text mItemsell;                 //���p���i
    TMP_Text mItemtext;                 //�A�C�e���e�L�X�g�i�T�v�j
    TMP_Text mItemsecrettest;           //�A�C�e���e�L�X�g�i�ڍׁj
    int mItemnumber;                    //�\���A�C�e���ԍ�

    bool IsUpdata;                      //�X�V�t���O

    // Start is called before the first frame update
    void Start()
    {
        //�I�[�N�V�����V�[����GameManager�擾
        mAuctionManager = GameObject.Find("GameManager").GetComponent<CAuctionManager>();
        mItemdates = mAuctionManager.GetItemdateList();

        mItemicon = GameObject.Find("CatalogItemIcon").GetComponent<Image>();
        mItemname = GameObject.Find("CatalogItemName").GetComponent<TMP_Text>();
        mItemprice = GameObject.Find("CatalogItemPrice").GetComponent<TMP_Text>();
        mItempriceup = GameObject.Find("CatalogItemAddPrice").GetComponent<TMP_Text>();
        mItemsell = GameObject.Find("CatalogItemSellPrice").GetComponent<TMP_Text>();
        mItemtext = GameObject.Find("CatalogItemText").GetComponent<TMP_Text>();
        mItemsecrettest = GameObject.Find("CatalogItemSecretText").GetComponent<TMP_Text>();

        //�z��̐擪�ɂȂ�悤������
        mItemnumber = 0;
        SetCatalogData();


    }

    // Update is called once per frame
    void Update()
    {
        if (IsUpdata)
        {
            SetCatalogData();
            IsUpdata = false;
        }
    }

    //�J�^���O�f�[�^�X�V
    void SetCatalogData()
    {
        mItemicon.sprite = mItemdates[mItemnumber].GetItemIcon();
        mItemname.text = mItemdates[mItemnumber].GetItemName();
        mItemprice.SetText("�J�n���i�F" + "{0:0000000000}", mItemdates[mItemnumber].GetItemPrice());
        mItempriceup.SetText("�㏸���i�F"+"{0:0000000000}", mItemdates[mItemnumber].GetPriceUpValue());
        mItemsell.SetText("���p���i�F" + "{0:0000000000}", mItemdates[mItemnumber].GetSellvalue());
        mItemtext.text = mItemdates[mItemnumber].GetItemText();
        mItemsecrettest.text = mItemdates[mItemnumber].GetItemSecretText();
    }

    //�\���A�C�e���ԍ�����
    public void ItemNumberUp()
    {
        IsUpdata = true;

        mItemnumber += 1;

        //����ݒ�
        if (mItemnumber >= mItemdates.Count)
        {
            mItemnumber = mItemdates.Count-1;
        }
    }

    //�\���A�C�e���ԍ�����
    public void ItemNumberDown()
    {
        IsUpdata = true;

        mItemnumber -= 1;

        //�����ݒ�
        if (mItemnumber < 0)
        {
            mItemnumber = 0;
        }
    }

}
