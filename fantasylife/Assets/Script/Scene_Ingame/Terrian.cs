using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using DG.Tweening;

public class Terrian : MonoBehaviour {
    private MapData _mapData;

    public SpriteRenderer sprite; 
    
    public void Awake() {
    }

    public void ChangeData(int id) {
        sprite.sprite = _mapData.sprData;
    }
}
