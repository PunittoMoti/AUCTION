using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SItemList 
{
    public static List<CItemData> Items;

    public static void AddItemList(CItemData item)
    {
        Items.Add(item);
    }

}
