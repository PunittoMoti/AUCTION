using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCheckBoxObject : MonoBehaviour
{
    bool mIsCheck;

    // Start is called before the first frame update
    void Start()
    {
        //����������
        this.transform.Find("PickImage").gameObject.GetComponent<Image>().enabled = false;

        //check��ԏ�����
        mIsCheck = false;
        this.transform.Find("Back/Check").gameObject.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�����J�[�\���\��
    public void ActivePickupCursor()
    {
        this.transform.Find("PickImage").gameObject.GetComponent<Image>().enabled = true;
    }

    //�����J�[�\����\��
    public void NoActivePickupCursor()
    {
        this.transform.Find("PickImage").gameObject.GetComponent<Image>().enabled = false;
    }

    //�`�F�b�N�{�b�N�X�ύX
    public void ChangeActiveCheck()
    {
        //�t���O���]
        mIsCheck = !mIsCheck;
        this.transform.Find("Back/Check").gameObject.GetComponent<Image>().enabled = mIsCheck;
    }

    public bool GetIsCheck()
    {
        return mIsCheck;
    }

    public void SetIsCheck(bool check)
    {
        mIsCheck = check;
    }

}
