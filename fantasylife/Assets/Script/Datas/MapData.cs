using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData {
    public readonly int id;
    public readonly Sprite sprData;

    public MapData(Dictionary<string, object> lst) {
        id = (int)lst["ID"];
        sprData = Resources.Load("MapData\\" + lst["Sprite"] as string) as Sprite;
    }
}
