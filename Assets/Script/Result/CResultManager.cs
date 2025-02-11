using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CResultManager : MonoBehaviour
{
    enum RESULTSEWQUENCE
    {
        RESULTCHECK,
        BUYPARTS,
        END
    }

    [SerializeField]int mMoney;      //������
    [SerializeField] int mPayMoney;   //�x���z
    RESULTSEWQUENCE mSequence;  //�A�j���[�V�����̃V�[�P���X�Ǘ��ԍ�
    float mTime;    //�o�ߎ���
    bool mIsPartsselect;//Select
    [SerializeField] GameObject mPartsbuttons;//�̑I���{�^���̐e�I�u�W�F�N�g

    CSceneMoveObject mScenemoveObject;              //�V�[���J�ڗp


    // Start is called before the first frame update
    void Start()
    {
        //mMoney = CMoneyManager.sMoneyManager.GetMoneyValue();
        mTime = 0.0f;
        mIsPartsselect = false;
        GameObject.Find("MyMoney").GetComponent<TMP_Text>().SetText("�������F" + "{0:0000000000}", mMoney);
        GameObject.Find("PayMoney").GetComponent<TMP_Text>().SetText("�x���z�F" + "{0:0000000000}", mPayMoney);
        GameObject.Find("ResultMoney").GetComponent<TMP_Text>().SetText("�c���@�F" + "{0:0000000000}", (mMoney - mPayMoney));

        //�V�[���I�u�W�F�N�g�擾
        mScenemoveObject = this.GetComponent<CSceneMoveObject>();

    }

    // Update is called once per frame
    void Update()
    {

        switch (mSequence)
        {
            //���Z����
            case RESULTSEWQUENCE.RESULTCHECK:

                //
                if(mMoney>= mPayMoney)
                {
                    mMoney -= mPayMoney;
                    mSequence = RESULTSEWQUENCE.END;
                }
                else
                {
                    //�{�^���I�u�W�F�N�g��L��
                    mPartsbuttons.SetActive(true);
                    mSequence = RESULTSEWQUENCE.BUYPARTS;
                }
                break;
            //�s�����̑̔��p�̑I��
            case RESULTSEWQUENCE.BUYPARTS:

                if (mIsPartsselect)
                {
                    //�{�^���I�u�W�F�N�g�𖳌�
                    mPartsbuttons.SetActive(false);
                    mIsPartsselect = false;
                    //����֑J��
                    mSequence = RESULTSEWQUENCE.RESULTCHECK;
                }

                break;
            //���Z����
            case RESULTSEWQUENCE.END:

                //�J��
                //�V�[���J��
                mScenemoveObject.MoveScene();
                break;
        }

    }

    //�ڂ���Ăэ���
    public void ActiveIsPartsselect(int price)
    {
        mMoney += price;
        mIsPartsselect = true;
    }
}
