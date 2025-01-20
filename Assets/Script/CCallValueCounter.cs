using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CCallValueCounter : MonoBehaviour
{
    float mCallUpValue;
    GameObject mManagerObject;
    TMP_Text mCallUpText;


    // Start is called before the first frame update
    void Start()
    {
        //GameManager�I�u�W�F�N�g���擾
        mManagerObject = GameObject.Find("GameManager");
        //�e�L�X�g�̃R���|�[�l���g���擾
        mCallUpText = this.GetComponent<TMP_Text>();
        //�\�����l������
        mCallUpValue = 2.0f;
        mCallUpText.SetText("�~" + "{0:00}", mCallUpValue);

    }

    // Update is called once per frame
    void Update()
    {
        SetCallUpValue();
    }

    //�錾�{���X�V
    public void SetCallUpValue()
    {
        mCallUpValue = (float)mManagerObject.GetComponent<CAuctionManager>().GetCallUpValue();
        mCallUpText.SetText("�~"+"{0:00}", mCallUpValue);
    }
}


