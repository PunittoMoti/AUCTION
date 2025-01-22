using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CAuctionManager : MonoBehaviour
{
    [SerializeField] List<CItemData> mItemdatas;    //�A�C�e�����X�g
    CItemData mItemdata;                            //�A�C�e���f�[�^
    TMP_Text mPricetext;                            //���z�e�L�X�g
    Sequence mSequence;                             //�����A�j���[�V����
    bool mIsCountUp = false;                        //�����A�j���[�V�������s�����ۂ�
    int mPricevalue;                                //���z�̒l
    int mNextpricevalue;                            //�X�V���̋��z�̒l(�A�j���[�V�����p)
    int mItemnumber;                                //�f�����̃A�C�e���ԍ�
    [SerializeField] float mPlaytime;               //���D�܂ł̎���
    float mNowtime;                                 //���ݎ���

    CSceneMoveObject mScenemoveObject;              //�V�[���J�ڗp

    // Start is called before the first frame update
    void Start()
    {
        //�A�C�e���ԍ���擪�ɂȂ�悤�ݒ�
        mItemnumber = 0;
        //�A�C�e�����X�g�̐擪���ŏ��̃A�C�e���Ƃ��Ċi�[
        mItemdata = mItemdatas[mItemnumber];

        //�e�L�X�g�̃R���|�[�l���g���擾
        mPricetext = GameObject.Find("NowPrice").GetComponent<TMP_Text>();
        mPricevalue = GetItemPrice();

        //�J�n���z���e�L�X�g�ɔ��f
        mPricetext.SetText("{0:0000000000}", mPricevalue);

        //�V�[���I�u�W�F�N�g�擾
        mScenemoveObject = this.GetComponent<CSceneMoveObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mIsCountUp)
        {
            mPricetext.SetText("{0:0000000000}", mPricevalue);
        }

        mNowtime += Time.deltaTime;

        //���D���A�C�e�����X�g�̗v�f���𒴂��Ȃ��ꍇ
        if (!GetIsPlay() && mItemdatas.Count > mItemnumber)
        {
            //�I�����o�i�\��j


            //���ԏ�����
            mNowtime = 0.0f;
            //���̃A�C�e����
            mItemnumber++;

            //�A�C�e�����X�V
            mItemdata = mItemdatas[mItemnumber];

            //�\�����i������
            mPricevalue = GetItemPrice();
            //���z�ύX�O�̒l
            mNextpricevalue = mPricevalue;
            //�A�j���[�V�������Đ����ł���΃X�L�b�v����
            if (mIsCountUp)
            {
                mSequence.Kill(true);
            }
            //�A�j���[�V�������s
            CountUpAnim();

        }
        //���D���A�C�e�����X�g�̗v�f���𒴂����ꍇ
        else if (!GetIsPlay() && mItemdatas.Count <= mItemnumber)
        {
            //�I�����o�i�\��j

            //�V�[���J��
            mScenemoveObject.MoveScene();
        }

    }

    //�J�E���g�A�b�v�A�j���[�V����
    void CountUpAnim()
    {
        //�J�E���g�A�b�v�t���O�L����
        mIsCountUp = true;

        mSequence = DOTween.Sequence()
            .Append(DOTween.To(
                () => mPricevalue,           //�X�V�Ώ�
                num => mPricevalue = num,    //�l�̍X�V
                mNextpricevalue,              //�ŏI�I�Ȓl
                0.5f))                  //�A�j���[�V��������
                                        //�I����0.1f�ҋ@
            .AppendInterval(0.1f)
            //���z�\���X�V���~
            .AppendCallback(() => mIsCountUp = false);
    }


    //�f�����̃A�C�e���f�[�^�擾
    public CItemData GetNowItemdate()
    {
        return mItemdata;
    }

    //�A�C�e��List�擾
    public List<CItemData> GetItemdateList()
    {
        return mItemdatas;
    }


    public int GetItemPrice()
    {
        return mItemdata.GetItemPrice();
    }

    //������Z����
    public void AddPricevalue()
    {
        //���z�ύX�O�̒l
        mNextpricevalue = mPricevalue;
        //���z���X�V
        mNextpricevalue += mItemdata.GetPriceUpValue();

        //�A�j���[�V�������Đ����ł���΃X�L�b�v����
        if (mIsCountUp)
        {
            mSequence.Kill(true);
        }

        //�A�j���[�V�������s
        CountUpAnim();
    }

    //�錾���Z����
    public void CallupPricevalue(int value)
    {
        //���z�ύX�O�̒l
        mNextpricevalue = mPricevalue;
        //���z���X�V
        mNextpricevalue = mNextpricevalue * value;

        //�A�j���[�V�������Đ����ł���΃X�L�b�v����
        if (mIsCountUp)
        {
            mSequence.Kill(true);
        }

        //�A�j���[�V�������s
        CountUpAnim();
    }

    //�I�[�N�V����������擾
    public�@bool GetIsPlay()
    {
        if(mPlaytime > mNowtime) return true;

        return false;
    }





}
