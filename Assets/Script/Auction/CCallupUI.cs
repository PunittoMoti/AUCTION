using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CCallupUI : MonoBehaviour
{
    CAuctionManager mAuctionManager;    //�I�[�N�V�����V�[����GameManager
    TMP_Text mCalluptext;               //�{���e�L�X�g
    float mCallupvalue;                 //�{�����l

    // Start is called before the first frame update
    void Start()
    {
        //�I�[�N�V�����V�[����GameManager�擾
        mAuctionManager = GameObject.Find("GameManager").GetComponent<CAuctionManager>();

        //�e�L�X�g�̃R���|�[�l���g���擾
        mCalluptext = this.GetComponent<TMP_Text>();

        //�\�����l������
        mCallupvalue = 2.0f;
        mCalluptext.SetText("�~" + "{0:1}", mCallupvalue);

    }

    // Update is called once per frame
    void Update()
    {
        //�{���X�V
        mCalluptext.SetText("�~" + "{0:1}", mCallupvalue);
    }

    //�錾�̉��Z����
    public void CallupPricevalue()
    {
        mAuctionManager.CallupPricevalue((int)mCallupvalue);
        mCallupvalue = 2.0f;
    }

    //�錾�̔{���㏸����
    public void Callvalueup()
    {
        mCallupvalue += 1.0f;

        //����ݒ�
        if (mCallupvalue > 5.0f)
        {
            mCallupvalue = 5.0f;
        }
    }

    //�錾�̔{�����~����
    public void Callvaluedown()
    {
        mCallupvalue -= 1.0f;

        //�����ݒ�
        if (mCallupvalue < 2.0f)
        {
            mCallupvalue = 2.0f;
        }
    }

}
