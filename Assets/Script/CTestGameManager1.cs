using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CTestGameManager1 : MonoBehaviour
{
    // ���͎�t�ݒ�
    [SerializeField] private InputAction mAction;
    CPriceObject mPriceObject;


    // �L����
    private void OnEnable()
    {
        // InputAction��L����
        // ��������Ȃ��Ɠ��͂��󂯎��Ȃ����Ƃɒ���
        mAction?.Enable();
    }

    // ������
    private void OnDisable()
    {
        // ���g�������������^�C�~���O�Ȃǂ�
        // Action�𖳌�������K�v������
        mAction?.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {
        mPriceObject = GameObject.Find("NowPrice").GetComponent<CPriceObject>();
    }

    // Update is called once per frame
    void Update()
    {
        var value = mAction.ReadValue<float>();

        if (mAction.WasPressedThisFrame())
        {
            mPriceObject.AddPoint(100);

        }
    }
}
