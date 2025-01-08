using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMoneyManager
{
    int mMoney;//Š‹à

    public static CMoneyManager sMoneyManager;

    //‚¨‹à‚Ì’l‚ğæ“¾
    public int GetMoneyValue()
    {
        return sMoneyManager.mMoney;
    }

    //x•¥‚¢ˆ—
    public void PayMoney(int pay)
    {
        sMoneyManager.mMoney -= pay;

    }

    //”„‹p‚Ì‰ÁZˆ—
    public void AddMoney(int add)
    {
        sMoneyManager.mMoney += add;
    }

}
