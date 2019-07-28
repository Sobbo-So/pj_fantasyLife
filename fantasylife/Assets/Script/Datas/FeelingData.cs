using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeelingData : BaseData {
    public readonly Dictionary<int, float> IncreaseStatus = new Dictionary<int, float>();
    public readonly Dictionary<int, float> DecreaseStatus = new Dictionary<int, float>();

    public FeelingData(List<Dictionary<string, object>> lst) : base(lst) {
    }
}
