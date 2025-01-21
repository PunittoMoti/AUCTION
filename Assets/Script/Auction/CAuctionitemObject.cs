using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CAuctionitemObject : MonoBehaviour
{
    CAuctionManager mAuctionManager;    //�I�[�N�V�����V�[����GameManager
    CItemData mItemdate;                //�f�����̃A�C�e��
    Image mItemicon;                    //�A�C�e���摜

    // Start is called before the first frame update
    void Start()
    {
        //�I�[�N�V�����V�[����GameManager�擾
        mAuctionManager = GameObject.Find("GameManager").GetComponent<CAuctionManager>();

        //�e�L�X�g�̃R���|�[�l���g���擾
        mItemicon = this.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        mItemdate = mAuctionManager.GetNowItemdate();
        mItemicon.sprite = mItemdate.GetItemIcon();
    }
}
