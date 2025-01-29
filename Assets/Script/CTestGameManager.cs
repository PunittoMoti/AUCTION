using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CTestGameManager : MonoBehaviour
{
    // 入力受付設定
    [SerializeField] private InputAction mAction;


    // 有効化
    private void OnEnable()
    {
        // InputActionを有効化
        // これをしないと入力を受け取れないことに注意
        mAction?.Enable();
    }

    // 無効化
    private void OnDisable()
    {
        // 自身が無効化されるタイミングなどで
        // Actionを無効化する必要がある
        mAction?.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {
        CMoneyManager.sMoneyManager = new CMoneyManager();
        Debug.Log("初期化");

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
            Debug.Log($"Actionの入力値 : {value}");
            Debug.Log($"お金: {CMoneyManager.sMoneyManager.GetMoneyValue()}");
            */

        }
    }
}
