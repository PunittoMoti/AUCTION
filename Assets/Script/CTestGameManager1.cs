using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CTestGameManager1 : MonoBehaviour
{
    // 入力受付設定
    [SerializeField] private InputAction mAction;
    CPriceObject mPriceObject;


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
