using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeelingData {
    public readonly Dictionary<int, float> IncreaseStatus = new Dictionary<int, float>();
    public readonly Dictionary<int, float> DecreaseStatus = new Dictionary<int, float>();

    public FeelingData(Dictionary<string, object> lst) {
    }
}
