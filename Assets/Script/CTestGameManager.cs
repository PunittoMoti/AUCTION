using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CTestGameManager : MonoBehaviour
{
    // ���͎�t�ݒ�
    [SerializeField] private InputAction mAction;


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
        CMoneyManager.sMoneyManager = new CMoneyManager();
        Debug.Log("������");

    }

    // Update is called once per frame
    void Update()
    {
        var value = mAction.ReadValue<float>();

        if (mAction.WasPressedThisFrame())
        {
            CItemList Bag = GameObject.Find("ItemBagList").GetComponent<CItemList>();
            CItemList Shop = GameObject.Find("ItemShopList").GetComponent<CItemList>();

           // Bag.MoveItem(Shop,2);

            /*
            CMoneyManager.sMoneyManager.AddMoney(10);
            Debug.Log($"Action�̓��͒l : {value}");
            Debug.Log($"����: {CMoneyManager.sMoneyManager.GetMoneyValue()}");
            */

        }
    }
}
