using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static ItemStatus;

public class CCatalogObject : MonoBehaviour
{
    [SerializeField] CItemData mItemData;

    string mName;                  //�A�C�e����
    int mPrice;                    //�l�i
    ITEMSTATUS mItemStatus;        //�A�C�e���̎��
    string mItemText;              //�A�C�e������
    Sprite mIcon;                  //�A�C�R��


    // Start is called before the first frame update
    void Start()
    {
        //�A�C�e���f�[�^����擾
        mName = mItemData.GetItemName();
        mPrice = mItemData.GetItemPrice();
        mItemStatus = mItemData.GetItemStatus();
        mItemText = mItemData.GetItemText();
        mIcon = mItemData.GetItemIcon();

        //�擾��������K�p
        transform.Find("Canvas/Name").gameObject.GetComponent<TMP_Text>().text = mName;
        transform.Find("Canvas/ItemText").gameObject.GetComponent<TMP_Text>().text = mItemText;
        transform.Find("Canvas/Price").gameObject.GetComponent<TMP_Text>().text = mPrice.ToString();
        transform.Find("Icon").gameObject.GetComponent<SpriteRenderer>().sprite = mIcon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
