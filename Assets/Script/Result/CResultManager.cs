using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CResultManager : MonoBehaviour
{
    [SerializeField]int mMoney;      //������
    [SerializeField] int mPayMoney;   //�x���z
    int mSequence;  //�A�j���[�V�����̃V�[�P���X�Ǘ��ԍ�
    float mTime;    //�o�ߎ���

    // Start is called before the first frame update
    void Start()
    {
        //mMoney = CMoneyManager.sMoneyManager.GetMoneyValue();
        mTime = 0.0f;

        GameObject.Find("MyMoney").GetComponent<TMP_Text>().SetText("�������F" + "{0:0000000000}", mMoney);
        GameObject.Find("PayMoney").GetComponent<TMP_Text>().SetText("�x���z�F" + "{0:0000000000}", mPayMoney);
        GameObject.Find("ResultMoney").GetComponent<TMP_Text>().SetText("�c���@�F" + "{0:0000000000}", (mMoney - mPayMoney));
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
