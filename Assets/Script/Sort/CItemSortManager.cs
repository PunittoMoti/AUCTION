using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CItemSortManager : MonoBehaviour
{
    enum ITEMSORTSEWQUENCE
    {
        CHECK,
        BUYRESULT,
        SETPARTS,
        END
    }

    [SerializeField] int mMoney;      //������
    int mBuyMoney;                     //���p���z
    ITEMSORTSEWQUENCE mSequence;  //�A�j���[�V�����̃V�[�P���X�Ǘ��ԍ�
    float mTime;    //�o�ߎ���
    bool mIsEnd;//End
    [SerializeField] GameObject mPartSet;//�ڐA���o
    [SerializeField] GameObject mAllPrice;
    CSortItemList mSortItemList;//

    CSceneMoveObject mScenemoveObject;              //�V�[���J�ڗp


    // Start is called before the first frame update
    void Start()
    {
        //mMoney = CMoneyManager.sMoneyManager.GetMoneyValue();
        mTime = 0.0f;
        mIsEnd = false;
        GameObject.Find("MyMoney").GetComponent<TMP_Text>().SetText("�������F" + "{0:0000000000}", mMoney);
        GameObject.Find("BuyMoney").GetComponent<TMP_Text>().SetText("���p�z�F" + "{0:0000000000}", mBuyMoney);

        //�V�[���I�u�W�F�N�g�擾
        mScenemoveObject = this.GetComponent<CSceneMoveObject>();
        mSortItemList = GameObject.Find("ItemList").GetComponent<CSortItemList>();

    }

    // Update is called once per frame
    void Update()
    {

        switch (mSequence)
        {
            //���Z����
            case ITEMSORTSEWQUENCE.CHECK:
                mBuyMoney = mSortItemList.GetBuyPrice();
                GameObject.Find("BuyMoney").GetComponent<TMP_Text>().SetText("���p�z�F" + "{0:0000000000}", mBuyMoney);

                if (mIsEnd)
                {
                    mMoney += mBuyMoney;
                    mAllPrice.SetActive(true);
                    mSequence = ITEMSORTSEWQUENCE.BUYRESULT;
                }
                break;
            //�s�����̑̔��p�̑I��
            case ITEMSORTSEWQUENCE.BUYRESULT:

                mAllPrice.GetComponent<TMP_Text>().SetText("���Z���ʁF" + "{0:0000000000}", mMoney);

                mTime += Time.deltaTime;
                if (mTime >= 2.0)
                {
                    mTime = 0.0f;
                    if (mSortItemList.GetAddPartsFlag())
                    {
                        mSequence = ITEMSORTSEWQUENCE.SETPARTS;
                    }
                    else
                    {
                        mSequence = ITEMSORTSEWQUENCE.END;
                    }
                }
                break;
            //�s�����̑̔��p�̑I��
            case ITEMSORTSEWQUENCE.SETPARTS:
                mPartSet.SetActive(true);
                mTime += Time.deltaTime;
                if (mTime >= 2.0)
                {
                    mTime = 0.0f;
                    mSequence = ITEMSORTSEWQUENCE.END;
                }
                break;
            //���Z����
            case ITEMSORTSEWQUENCE.END:

                //�J��
                //�V�[���J��
                mScenemoveObject.MoveScene();
                break;
        }

    }

    //�ڂ���Ăэ���
    public void ActivemIsEnd()
    {
        mIsEnd = true;
    }
}
