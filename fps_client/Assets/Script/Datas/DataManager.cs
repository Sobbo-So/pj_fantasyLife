using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager {
    public static DataManager instance;
    public static DataManager Get() {
        if (instance == null)
            instance = new DataManager();
        return instance;
    }

    private Dictionary<long, MapData> _mapDatas = new Dictionary<long, MapData>();
    private Dictionary<long, ItemData> _itemDatas = new Dictionary<long, ItemData>();

    public DataManager() {
        // Map
        List<Dictionary<string, object>> mapData = CSVLoader.Read("Maps");
        _mapDatas.Clear();
        foreach (var data in mapData) {
            var _temp = new MapData(data);
            _mapDatas.Add(_temp.id, _temp);
        }
    }

    public ItemData GetItemData(long id) {
        return _itemDatas[id];
    }
}
