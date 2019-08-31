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

    private Dictionary<int, MapData> _mapDatas = new Dictionary<int, MapData>();
    private Dictionary<int, FeelingData> _feelingDatas = new Dictionary<int, FeelingData>();
    private Dictionary<int, FeelingData> _jobDatas = new Dictionary<int, FeelingData>();

    public DataManager() {
        // Map
        List<Dictionary<string, object>> mapData = CSVLoader.Read("Maps");
        _mapDatas.Clear();
        foreach (var data in mapData) {
            var _temp = new MapData(data);
            _mapDatas.Add(_temp.id, _temp);
        }

        // Feeling
        // job
    }
}
