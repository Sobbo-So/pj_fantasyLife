using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 연출 및 데이터 실행자
public class Scene_Game : MonoBehaviour {
    public static MyGameManager myGameManager;
    public static BagManager bagManager;

    public void Awake() {
        myGameManager = new MyGameManager();

        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void FixedUpdate() {
    }
}
