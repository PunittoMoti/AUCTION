using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CAuctionNPCManager : MonoBehaviour
{
    [SerializeField]List<GameObject> mNPCs;
    GameObject mNPC;
    CAuctionManager mAuctionManager;    //�I�[�N�V�����V�[����GameManager
    int mNumber;

    bool mIsStart;  //�J�n
    bool mSideflag; //���E

    float mPositionY;   //�c��
    float mTime;        //�T�C�N������
    float mSetTime;        //�T�C�N������

    Image mNPCicon;                    //�L�����摜


    // Start is called before the first frame update
    void Start()
    {
        //�I�[�N�V�����V�[����GameManager�擾
        mAuctionManager = GameObject.Find("GameManager").GetComponent<CAuctionManager>();
        mIsStart = false;
        mSetTime = Random.Range(2.0f, 3.0f);

    }

    // Update is called once per frame
    void Update()
    {        //�I�[�N�V�������łȂ���΍X�V�Ȃ�
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
            //�����I��
            mIsStart = false;
            //���ԏ�����
            mTime = 0f;
            //�������ԍĐݒ�
            mSetTime = Random.Range(5.0f, 10.0f);


            //���E�����_��
            if (Random.value > 0.5f) mSideflag = true;
            else mSideflag = false;

            //Y���W����
            mPositionY = Random.Range(-20.0f, 20.0f);

            float PositionX;

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

            mNumber = Random.Range(0, 100) % 2;

            switch (mNumber)
            {
                case 0:
                    mNPC = mNPCs[0];
                    break;
                case 1:
                    mNPC = mNPCs[1];
                    break;
            }

            // TalkObject�v���n�u�����ɁA�C���X�^���X�𐶐��A
            GameObject obj = Instantiate(mNPC, GameObject.Find("NPCCanvas").transform.position, Quaternion.identity, GameObject.Find("NPCCanvas").transform);
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector3(PositionX, mPositionY, 0);
        }

    }
}
