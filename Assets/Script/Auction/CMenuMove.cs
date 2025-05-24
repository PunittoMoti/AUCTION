using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CMenuMove : MonoBehaviour
{
    bool misMove;
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
            if(this.GetComponent<RectTransform>().anchoredPosition.x >= -60)
            {
                this.GetComponent<RectTransform>().anchoredPosition -= new Vector2(2.0f, 0);//毎フレームx座標を0.1ずつプラス
            }
        }
        else
        {
            if (this.GetComponent<RectTransform>().anchoredPosition.x <= 440)
            {
                Debug.Log("Debug");
                this.GetComponent<RectTransform>().anchoredPosition += new Vector2(2.0f, 0);//毎フレームx座標を0.1ずつプラス

            }

        }
    }

    public void ChangeIsMove()
    {
        misMove = !misMove;
    }
}
