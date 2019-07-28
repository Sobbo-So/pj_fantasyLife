using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pril_Ani : MonoBehaviour
{
    enum ANISTATE
    {
        IDLE = 0,
        WALK = 1,
        ANITYPE,
        TARGETWALK = 99
    };
    int prilstate; // 애니메이션(캐릭터)의 현재 상태를 저장
    int stategauge; // animation 시간 카운트

    public int walkgauge; // WALK 유지상태 설정 시간
    public int idlegauge; // IDLE 유지상태 설정 시간

    public int idle_timeMax, idle_timeMin; // IDLE 시간 최대값, 최소값
    public float movespeed; // 캐릭터 이동 속도


    public void FixedUpdate() // 상태를 바꿔주는 게이지를 채워줌
    {
        if(prilstate == 0 && stategauge  > idlegauge) // idle -> walk 교체 시
        {
            prilstate = (int)ANISTATE.WALK;
            stategauge = 0; // 게이지 초기화
            GetComponent<Animator>().SetInteger("animation", prilstate);
        }

        if(prilstate == 1 && stategauge > idlegauge) // walk -> idle 교체 시
        {
            prilstate = (int)ANISTATE.IDLE;
            stategauge = 0; // 게이지 초기화
            GetComponent<Animator>().SetInteger("animation", prilstate);
        }
        stategauge++; // 게이지 채우기
    }

    public void Update() //움직임을 담당
    {
        if(prilstate == (int)ANISTATE.WALK) // 걷기 상태
        {
            if(GetComponent<SpriteRenderer>().flipX == true) // 왼쪽을 보고있으면 왼쪽이동
            {
                this.transform.Translate(new Vector3(-movespeed, 0, 0));

                if (this.transform.position.x < -2.8) // 캐릭터 좌표값이 왼쪽끝이면 오른쪽을 보게함
                    GetComponent<SpriteRenderer>().flipX = false;
            }
            else //오른쪽을 보고 있으면 오른쪽 이동
            {
                this.transform.Translate(new Vector3(movespeed, 0, 0));

                if (this.transform.position.x > 2.8) // 캐릭터 좌표값이 오른쪽끝이면 왼쪽을 보게함
                    GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }
}
