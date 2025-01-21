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

    [SerializeField] int mAddValue;

    // Start is called before the first frame update
    void Start()
    {
        //�A�C�e�����X�g�̐擪���ŏ��̃A�C�e���Ƃ��Ċi�[
        mItemdata = mItemdatas[0];

        //�e�L�X�g�̃R���|�[�l���g���擾
        mPricetext = GameObject.Find("NowPrice").GetComponent<TMP_Text>();
        mPricevalue = GetItemPrice();

        //�J�n���z���e�L�X�g�ɔ��f
        mPricetext.SetText("{0:0000000000}", mPricevalue);
    }

    // Update is called once per frame
    void Update()
    {
        if (mIsCountUp)
        {
            mPricetext.SetText("{0:0000000000}", mPricevalue);
        }

    }

    //�f�����̃A�C�e���f�[�^�擾
    public CItemData GetNowItemdate()
    {
        return mItemdata;
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
        mNextpricevalue += mAddValue;

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





}
