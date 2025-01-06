using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CPriceObject : MonoBehaviour
{
    int mPrice;
    int mNextPrice;

    bool mIsCountUp = false;

    GameObject mManagerObject;
    TMP_Text mPriceText;

    Sequence mSequence;
    

    // Start is called before the first frame update
    void Start()
    {
        //GameManager�I�u�W�F�N�g���擾
        mManagerObject = GameObject.Find("GameManager");
        //�e�L�X�g�̃R���|�[�l���g���擾
        mPriceText = this.GetComponent<TMP_Text>();
        mPrice = mManagerObject.GetComponent<CAuctionManager>().GetItemPrice();


        mPriceText.SetText("{0:0000000000}", mPrice);

    }

    // Update is called once per frame
    void Update()
    {
        if (mIsCountUp)
        {
            mPriceText.SetText("{0:0000000000}", mPrice);
        }
    }

    //���Z����
    public void AddPoint(int point)
    {
        //���z�ύX�O�̒l
        mPrice = mNextPrice;
        //���z���X�V
        mNextPrice += point;

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
                () => mPrice,           //�X�V�Ώ�
                num => mPrice = num,    //�l�̍X�V
                mNextPrice,              //�ŏI�I�Ȓl
                0.5f))                  //�A�j���[�V��������
            //�I����0.1f�ҋ@
            .AppendInterval(0.1f)
            //���z�\���X�V���~
            .AppendCallback(() => mIsCountUp = false);
    }
}
