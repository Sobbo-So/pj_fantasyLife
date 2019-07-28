using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, EventListener {
    public static GameManager instance;
    public static GameManager Get() {
        return instance;
    }

    public GameObject ui_timehour;
    public GameObject ui_timeminute;
    public GameObject ui_pmap;

    public static int gameday = 1; // 일차     ★ 껐을 때 저장될 날짜 데이터  일,시,분,PMAM
    public static int gamehour = 12; // 시         
    public static int gameminute; // 분
    public static int itspm; // PM AM

    public void Awake() {
        instance = this;
    }

    void FixedUpdate()
    {

        gameminute++;

        if (gameminute == 60) // '분'이 60분이 됐을 때(1)
        {
            ChangeHour(); // '시'를 1 올려줌(1)

            if(gamehour == 12) // '시'가 12이 됐을 때 (2)
            {
                ChangePMAM(); // PM AM을 바꿔줌
            }

            if(gamehour >= 13) // '시'가 13보다 같거나 클때(3)
            {
                gamehour = 1; //1로 바꿔줌
            }
        }

        ui_timehour.GetComponent<Text>().text = string.Format("{0:D2}", gamehour).ToString(); // 시간 표시
        ui_timeminute.GetComponent<Text>().text = string.Format("{0:D2}",gameminute).ToString(); // 분 표시

        if (itspm == 0) // AM이면
            ui_pmap.GetComponent<Text>().text = "AM";
        else //PM 이면
            ui_pmap.GetComponent<Text>().text = "PM";
 
    }

    void ChangeHour()
    {
        gameminute = 0;
        gamehour++; 
    }

    void ChangePMAM()
    {
        gamehour = 12;

        if (itspm == 0) // AM이면 PM으로
            itspm = 1;


        else if (itspm == 0) // PM이면 AM으로
        {
            itspm = 0;
            gameday++; // 일차 추가
        }
    }

    public void MoveMapToID(int id) {

    }

    public void HandleEvent(GameEvent e) {

    }
}
