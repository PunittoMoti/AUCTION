using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDayManager
{
    int mDay;//������

    public static CDayManager sDayManager;

    //���݂̓������擾
    public int GetDay()
    {
        return sDayManager.mDay;
    }

    //�������Z����
    public void AddDay(int add)
    {
        sDayManager.mDay += add;
    }

    //�����w�菈��
    public void SetDay(int day)
    {
        sDayManager.mDay = day;
    }

}
