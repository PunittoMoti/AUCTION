using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "CreateItemDataBase")]
public class CItemDataBase : ScriptableObject
{
    //�A�C�e���f�[�^�̃��X�g
    [SerializeField] List<CItemData> items = new List<CItemData>();

    //�A�C�e���f�[�^�Q��
    public CItemData GetItemData(int Number)
    {
        return items[Number];
    }

}
