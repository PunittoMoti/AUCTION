using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "CreateItemDataBase")]
public class CItemDataBase : ScriptableObject
{
    public List<CItemData> items = new List<CItemData>();
}