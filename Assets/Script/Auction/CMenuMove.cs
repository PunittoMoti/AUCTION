using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CMenuMove : MonoBehaviour
{
    bool misMove;
    [SerializeField]
    GameObject mMenuObject;
    // Start is called before the first frame update
    void Start()
    {
        misMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (misMove)
        {
            if(mMenuObject.GetComponent<RectTransform>().anchoredPosition.x >= -60)
            {
                mMenuObject.GetComponent<RectTransform>().anchoredPosition -= new Vector2(2.0f, 0);//毎フレームx座標を0.1ずつプラス
            }
        }
        else
        {
            if (mMenuObject.GetComponent<RectTransform>().anchoredPosition.x <= 440)
            {
                mMenuObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(2.0f, 0);//毎フレームx座標を0.1ずつプラス

            }

        }
    }

    public void ChangeIsMove()
    {
        misMove = !misMove;
    }
}
