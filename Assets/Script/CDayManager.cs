using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDayManager
{
    int mDay;//所持金

    public static CDayManager sDayManager;

    //現在の日数を取得
    public int GetDay()
    {
        return sDayManager.mDay;
    }

    //日数加算処理
    public void AddDay(int add)
    {
        sDayManager.mDay += add;
    }

    //日数指定処理
    public void SetDay(int day)
    {
        sDayManager.mDay = day;
    }

}
