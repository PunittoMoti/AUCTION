using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMoneyManager
{
    int mMoney;//所持金

    public static CMoneyManager sMoneyManager;

    //お金の値を取得
    public int GetMoneyValue()
    {
        return sMoneyManager.mMoney;
    }

    //支払い処理
    public void PayMoney(int pay)
    {
        sMoneyManager.mMoney -= pay;

    }

    //売却時の加算処理
    public void AddMoney(int add)
    {
        sMoneyManager.mMoney += add;
    }

}
