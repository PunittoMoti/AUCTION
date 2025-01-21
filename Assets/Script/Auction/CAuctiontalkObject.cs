using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CAuctiontalkObject : MonoBehaviour
{
    float mTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mTime += Time.deltaTime;

        if (mTime >= 2.0f)
        {
            Destroy(this.gameObject);
        }
    }

    //会話文セット
    public void SetTalkText(string text)
    {
        this.gameObject.transform.Find("TalkText").GetComponent<TMP_Text>().text = text;
    }
}
