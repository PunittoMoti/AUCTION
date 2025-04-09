using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCalendarManager : MonoBehaviour
{
    private float mTime;
    private bool isPause;

    // Start is called before the first frame update
    void Start()
    {
        mTime = 0.0f;
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Pause中でなければ時間を進める
        if(!isPause) mTime += Time.deltaTime;

        //６秒後　もしくは　なにかポーズ以外の操作があれば
        if (mTime >= 6.0f)
        {
            this.GetComponent<CSceneMoveObject>().MoveScene();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            if(!isPause) this.GetComponent<CSceneMoveObject>().MoveScene();
        }

    }
}
