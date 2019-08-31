using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : BaseData
{
    public readonly int maxCount;

    public static ItemData Get(long id) {
        return DataManager.Get().GetItemData(id);
    }
}
