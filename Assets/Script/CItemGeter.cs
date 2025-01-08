using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CItemGeter : MonoBehaviour
{
    GameObject mShowItem;          //�A�C�e���W���p
    CItemObject mMyItemObject;     //�f�[�^

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("ItemShowObject") != null)
        {
            Debug.Log("SET�I");

            mShowItem = GameObject.Find("ItemShowObject");
        }

        mMyItemObject = this.GetComponent<CItemObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetData()
    {
        Debug.Log("EVENT�I");
        mShowItem.GetComponent<CShowShopObject>().SetItemObject(mMyItemObject,this.gameObject);
    }
}
