using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDayManager
{
    int mDay;//Š‹à

    public static CDayManager sDayManager;

    //Œ»İ‚Ì“ú”‚ğæ“¾
    public int GetDay()
    {
        return sDayManager.mDay;
    }

    //“ú”‰ÁZˆ—
    public void AddDay(int add)
    {
        sDayManager.mDay += add;
    }

    //“ú”w’èˆ—
    public void SetDay(int day)
    {
        sDayManager.mDay = day;
    }

}
