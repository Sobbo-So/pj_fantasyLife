using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : EventManager, EventListener {
    // temp
    public const float MAX_STRESS = 100f;
    public const float MAX_HYGIENE= 100f;
    public const float MAX_HUNGER = 100f;
    public const float MAX_BLADDER = 100f;

    public enum Type {
        STRESS,
        HYGIENE,
        HUNGER,
        BLADDER,
        MAX,
    }

    // tmp player Status Values
    private float[] _playerParameter = new float[(int)Type.MAX];
    private float[] _calcParameterCount = new float[(int)Type.MAX];

    private readonly float[] _maxCountParameter = new float[(int)Type.MAX] {
        3, 4, 10, 6
    };
    private readonly float[] _calcParameter = new float[(int)Type.MAX] {
        1.1f, 1.0f, 2f, 0.5f
    };

    private float _fixedTime = 0f;

    public void Awake() {
        this.AddListener(this);
    }

    public void FixedUpdate() {
        _fixedTime += Time.deltaTime;

        if (_fixedTime >= 1f) {
            for (int i = 0; i < (int)Type.MAX; ++i) {
                if (_playerParameter[i] > 0) {
                    if (++_maxCountParameter[i] > _maxCountParameter[i]) {
                        _calcParameter[i] = 0;
                        _playerParameter[i] -= _calcParameter[i];
                        DispatchEvent(GameEventType.RUNOUT_STATUS, i);
                    }
                }
            }
        }
    }

    public void HandleEvent(GameEvent e) {
        
    }
}
