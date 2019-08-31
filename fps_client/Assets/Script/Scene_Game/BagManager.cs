using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    public int dataID;
    public int count;
    public float expiration;    // start + expiration

    public Item() {
    }
}

public class BagManager {
    public List<Item> lstItems = new List<Item>();
    public int maxCount = 0;

    public BagManager() {
    }

    public int PutItem(Item item, bool merge) {
        if (merge) {
            int count = item.count;
            foreach (var it in lstItems) {
                if (it.dataID != item.dataID)
                    continue;

                var itData = ItemData.Get(item.dataID);
                if (itData == null)
                    continue;



                if (count <= 0)
                    break;
            }
        } else {
        }
        return 0;
    }
}
