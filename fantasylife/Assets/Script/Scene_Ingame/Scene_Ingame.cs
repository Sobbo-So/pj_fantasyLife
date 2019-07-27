using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Ingame : MonoBehaviour, EventListener {
    public Canvas canvas_Base;

    public void Awake() {
        CSVLoader.instance = new CSVLoader();
    }

    public void HandleEvent(GameEvent e) {
    }
}
