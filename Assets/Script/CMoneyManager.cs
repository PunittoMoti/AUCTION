using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMoneyManager
{
    int mMoney;//������

    public static CMoneyManager sMoneyManager;

    //�����̒l���擾
    public int GetMoneyValue()
    {
        return sMoneyManager.mMoney;
    }

    //�x��������
    public void PayMoney(int pay)
    {
        sMoneyManager.mMoney -= pay;

    }

    //���p���̉��Z����
    public void AddMoney(int add)
    {
        sMoneyManager.mMoney += add;
    }

}
