using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAuctionMessageManager : MonoBehaviour
{

    //�c�@145�@���@110

    bool mSideflag; //���E
    bool mIsStart;  //�J�n

    float mPositionY;   //�c��
    float mTime;        //�T�C�N������
    float mSetTime;        //�T�C�N������

    [SerializeField]List<string> mTalkTexts;    //���b�Z�[�W���X�g

    GameObject mTalkprefab;     //�g�[�N�I�u�W�F�N�g�̃v���n�u
    GameObject mUseObject;      //�g�p����g�[�N�I�u�W�F�N�g
    // Start is called before the first frame update
    void Start()
    {
        mIsStart = false;
        mSetTime = Random.Range(2.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!mIsStart)
        {
            mTime += Time.deltaTime;
            if (mTime >= mSetTime) mIsStart = true;
        }
        else
        {
            //���E�����_��
            if (Random.value > 0.5f) mSideflag = true;
            else mSideflag = false;

            //Y���W����
            mPositionY = Random.Range(-145.0f, 145.0f);

            float PositionX;
            //X���W����
            if (mSideflag)
            {
                //�E�T�C�h
                // TalkObject�v���n�u��GameObject�^�Ŏ擾
                mUseObject = (GameObject)Resources.Load("TalkObject");
                PositionX = 110.0f;
            }
            else
            {
                //���T�C�h
                // TalkObject�v���n�u��GameObject�^�Ŏ擾
                mUseObject = (GameObject)Resources.Load("TalkObject");
                PositionX = -110.0f;
            }

            // TalkObject�v���n�u�����ɁA�C���X�^���X�𐶐��A
            GameObject obj = Instantiate(mUseObject, GameObject.Find("TalkCanvas").transform.position, Quaternion.identity, GameObject.Find("TalkCanvas").transform);
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector3(PositionX, mPositionY,0);
            //�e�L�X�g�Z�b�g
            obj.GetComponent<CTalkObject>().SetTalkText(mTalkTexts[Random.Range(0, mTalkTexts.Count)]);


            //�����I��
            mIsStart = false;
            //���ԏ�����
            mTime = 0f;
            //�������ԍĐݒ�
            mSetTime = Random.Range(1.0f, 2.0f);
        }

    }
}
