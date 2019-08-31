using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 세이브 데이터 (유저 행동으로 인한 저장, 종료 등)
public class SaveDataManager {
    public static SaveDataManager instance;
    public static SaveDataManager Get() {
        if (instance == null)
            instance = new SaveDataManager();
        return instance;
    }

    public List<SaveData> lstDatas = new List<SaveData>();
    public SaveData currentData = null;

    public SaveDataManager() {
        // from json data
    }

    public int Load(int id) {
        try {
        } catch {
            currentData = null;
        }
        return -1;
    } 

    public int Save(int id) {
        try {
            var data = lstDatas.Find(x => x.id == id);
            if (data == null) {
                data = new SaveData() {
                    id = id
                };
            }
            data.Save();
            return 1;
        } catch {
            return -1;
        }
    }

    public void SaveAll() {
        // all Save data to json data
    }
}
