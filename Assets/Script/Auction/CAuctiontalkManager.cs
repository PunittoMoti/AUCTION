using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CAuctiontalkManager : MonoBehaviour
{
    CAuctionManager mAuctionManager;    //�I�[�N�V�����V�[����GameManager
    CItemData mItemdate;                //�f�����̃A�C�e��


    //�c�@145�@���@110
    bool mIsStart;  //�J�n
    bool mSideflag; //���E

    float mPositionY;   //�c��
    float mTime;        //�T�C�N������
    float mSetTime;        //�T�C�N������

    [SerializeField]List<string> mTalkTexts;    //���b�Z�[�W���X�g
    GameObject mUseObject;      //�g�p����g�[�N�I�u�W�F�N�g
    TMP_Text mReadtext;         //�A�C�e���Љ�e�L�X�g



    // Start is called before the first frame update
    void Start()
    {
        //�I�[�N�V�����V�[����GameManager�擾
        mAuctionManager = GameObject.Find("GameManager").GetComponent<CAuctionManager>();
        //�A�C�e���Љ�p�e�L�X�g���b�V���擾
        mReadtext = GameObject.Find("ReadText").GetComponent<TMP_Text>();

        mSetTime = Random.Range(2.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //�f�����̃A�C�e�����擾
        mItemdate = mAuctionManager.GetNowItemdate();
        //�A�C�e���Љ�e�L�X�g�X�V
        mReadtext.text = mItemdate.GetReadText();

        //�I�[�N�V�������łȂ���΍X�V�Ȃ�
        if (!mAuctionManager.GetIsPlay()) 
        {
            mTime = 0.0f;
            return;
        } 


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
            mPositionY = Random.Range(-20.0f, 20.0f);

            float PositionX;
            // TalkObject�v���n�u��GameObject�^�Ŏ擾
            mUseObject = (GameObject)Resources.Load("AuctiontalkObject");

            //X���W����
            if (mSideflag)
            {
                //�E�T�C�h
                PositionX = 110.0f;
            }
            else
            {
                //���T�C�h
                PositionX = -110.0f;
            }

            // TalkObject�v���n�u�����ɁA�C���X�^���X�𐶐��A
            GameObject obj = Instantiate(mUseObject, GameObject.Find("TalkCanvas").transform.position, Quaternion.identity, GameObject.Find("TalkCanvas").transform);
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector3(PositionX, mPositionY, 0);
            //�e�L�X�g�Z�b�g
            obj.GetComponent<CAuctiontalkObject>().SetTalkText(mTalkTexts[Random.Range(0, mTalkTexts.Count)]);


            //�����I��
            mIsStart = false;
            //���ԏ�����
            mTime = 0f;
            //�������ԍĐݒ�
            mSetTime = Random.Range(1.0f, 2.0f);
        }

    }
}
