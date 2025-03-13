using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGameStatus
{
    private static int mMoney;//所持金
    private static List<CItemData> mItemList;//所持アイテムリスト
    private static int mDay;//日付
    private static int mPayMoney;//支払額
    //体状態のリスト（実装予定）

    //現在の所持金を取得
    public static int GetMoney()
    {
        return mMoney;
    }

    //所持金加算処理
    public static void AddMoney(int add)
    {
        mMoney += add;
    }

    //所持金減算処理
    public static void PayMoney(int pay)
    {
        mMoney -= pay;
    }

    //所持金reset処理
    public static void ResetMoney()
    {
        mMoney = 0;
    }



    //所持アイテムリストを取得
    public static List<CItemData> GetItemList()
    {
        if (mItemList == null)
        {
            mItemList = new List<CItemData>();
        }

        return mItemList;
    }

    //所持アイテムリストへ追加
    public static void AddItemList(CItemData item)
    {
        if (mItemList == null)
        {
            mItemList = new List<CItemData>();
        }

        mItemList.Add(item);
    }

    //現在の日数を取得
    public static int GetDay()
    {
        return mDay;
    }

    //日数加算処理
    public static void AddDay(int add)
    {
        mDay += add;
    }

    //日数指定処理
    public static void SetDay(int day)
    {
        mDay = day;
    }

    //現在の所持金を取得
    public static int GetPayMoney()
    {
        return mPayMoney;
    }

    //所持金加算処理
    public static void AddPayMoney(int add)
    {
        mPayMoney += add;
    }

    //所持金加算処理
    public static void ResetPayMoney()
    {
        mPayMoney = 0;
    }


}
