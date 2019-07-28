using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : EventListener {
    public static GameManager instance;
    public static GameManager Get() {
        return instance;
    }

    public enum ParamType {
        // Status
        BLADDER,
        HUNGER,
        HYGIENE,
        STRESS,
        ENERGY,

        // Proficiency
        COOKING,
        CLEANING,
        MANAGING,

        MAX
    };

    public static int gameday = 1; // 일차     ★ 껐을 때 저장될 날짜 데이터  일,시,분,PMAM
    public static int gamehour = 0; // 시         
    public static int gameminute; // 분

    private static int _playerJob = 0;
    private static int _playerFeeling = 0;

    private static float[] _playerParam = new float[(int)ParamType.MAX];

    public void Awake() {
        instance = this;
        for (int n = 0; n < (int)ParamType.MAX; ++n) {
            _playerParam[n] = 100f;
        }
        EventManager.instance.AddListener(this);
    }

    public void FixedUpdate() {
        gameminute++;

        for (int i = 0; i < 5; ++i) {
            DecreaseParam(i, 10);
        }

        if (gameminute == 60) // '분'이 60분이 됐을 때(1)
        {
            AddHour(); // '시'를 1 올려줌(1)
        }
    }

    void AddHour() {
        gameminute = 0;
        gamehour++;
   
        if (gamehour == 12)
            EventManager.instance.DispatchEvent(GameEventType.REFRESH_NOON);
        else if (gamehour > 24) {
            gamehour = 0;
            gameday++; // 일차 추가
            EventManager.instance.DispatchEvent(GameEventType.REFRESH_NOON);
        }
    }

    public void MoveMapToID(int id) {
        // Start FadeIn
        // Coroutine Start
    }

    public void IncreaseParam(int type, float value) {
        if (type >= _playerParam.Length)
            return;

        _playerParam[type] = Mathf.Min(float.MaxValue, _playerParam[type] + value);
        EventManager.instance.DispatchEvent(GameEventType.REFRESH_STATUS, type);
    }

    public void DecreaseParam(int type, float value) {
        if (type >= _playerParam.Length)
            return;

        _playerParam[type] = Mathf.Max(0, _playerParam[type] - value);
        EventManager.instance.DispatchEvent(GameEventType.REFRESH_STATUS, type);
    }

    public float GetParam(int type) {
        if (type > _playerParam.Length)
            return 0;

        return _playerParam[type];
    }

    public void HandleEvent(GameEvent e) {

    }
}
