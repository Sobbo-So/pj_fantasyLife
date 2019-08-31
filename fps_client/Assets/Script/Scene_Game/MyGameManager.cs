using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 시간, 대화, NPC 인지도 등 처리
public class MyGameManager : MonoBehaviour {
    private static bool _isSpendRealTime;
    private static bool _isLeapYear;

    private static float _second;
    private static int _day;
    private static int _year;

    public void Awake() {
        var data = SaveDataManager.Get().currentData;
        if (data == null) {
            Debug.Log("불려진 데이터가 없습니다.");
        }

        _second = (float)data.second;
        _day = data.day;
        _year = data.year;

        _isSpendRealTime = false;
        _isLeapYear = data.leapYear;
    }

    public static int GetMaxDayByYear(int year) {
        switch (year) {
            case 2:
                return _isLeapYear ? 29 : 28;
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                return 31;
            case 4:
            case 6:
            case 9:
            case 11:
                return 30;
            default:
                return 31;
        }
    }

    public void FixedUpdate() {
        _second += !_isSpendRealTime ? 60f : Time.fixedDeltaTime;
        if (_second > 86400f) {
            if (_day >= GetMaxDayByYear(_year)) {
                _day = 0;
                ++_year;
            } else {
                ++_day;
            }
        }
    }

    public void SetCheckSpendRealTime(bool value) {
        _isSpendRealTime = value;
    }
}
