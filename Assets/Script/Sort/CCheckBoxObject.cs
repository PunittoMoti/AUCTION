using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCheckBoxObject : MonoBehaviour
{
    bool mIsCheck;

    // Start is called before the first frame update
    void Start()
    {
        //強調初期化
        this.transform.Find("PickImage").gameObject.GetComponent<Image>().enabled = false;

        //check状態初期化
        mIsCheck = false;
        this.transform.Find("Back/Check").gameObject.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //強調カーソル表示
    public void ActivePickupCursor()
    {
        this.transform.Find("PickImage").gameObject.GetComponent<Image>().enabled = true;
    }

    //強調カーソル非表示
    public void NoActivePickupCursor()
    {
        this.transform.Find("PickImage").gameObject.GetComponent<Image>().enabled = false;
    }

    //チェックボックス変更
    public void ChangeActiveCheck()
    {
        //フラグ反転
        mIsCheck = !mIsCheck;
        this.transform.Find("Back/Check").gameObject.GetComponent<Image>().enabled = mIsCheck;
    }

    public bool GetIsCheck()
    {
        return mIsCheck;
    }

    public void SetIsCheck(bool check)
    {
        mIsCheck = check;
    }

}
