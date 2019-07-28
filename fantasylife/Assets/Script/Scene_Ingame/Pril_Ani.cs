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
    int stategauge; // animation 현재 애니메이션 시간 카운트
    int walkgauge, idlegauge; // 각 애니메이션 유지상태 설정 시간

    public int idle_timeMax, idle_timeMin; // IDLE 시간 최대값, 최소값
    public int walk_timeMax, walk_timeMin; // WALK 시간 최대값, 최소값

    public float movespeed; // 캐릭터 이동 속도

    public void FixedUpdate() // 상태 바꾸기
    {
        if(prilstate == 0 && stategauge  > idlegauge) // idle -> walk 교체
        {
            prilstate = (int)ANISTATE.WALK;
            SetAniTime(prilstate); //애니메이션 변경
        }

        if(prilstate == 1 && stategauge > walkgauge) // walk -> idle 교체
        {
            prilstate = (int)ANISTATE.IDLE;
            SetAniTime(prilstate); //애니메이션 변경
        }
        stategauge++; // 게이지 채우기
    }

    public void Update() // 움직임 담당
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
    public void SetAniTime(int nowstate) // 애니메이션 변경하기
    {
        stategauge = 0; // 게이지 초기화
        GetComponent<Animator>().SetInteger("animation", prilstate); //애니메이션 변경

        int aniTimeValue;


        switch (nowstate) {
            case (int)ANISTATE.IDLE:
                aniTimeValue = Random.Range(idle_timeMax, idle_timeMax);
                idlegauge = aniTimeValue;
                break;
            case (int)ANISTATE.WALK:
                aniTimeValue = Random.Range(walk_timeMax, walk_timeMax);
                walkgauge = aniTimeValue;
                break;
            default:
                Debug.Log("ERROR");
                break;
        }
    }
}
