using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pril_Control : MonoBehaviour
{
    enum ANISTATE 
    {
        IDLE = 0, // 아이들
        WALK = 1, // 걷기
        TURN = 2, // 회전
        ANITYPE,
        TARGETWALK = 99
    };
    public GameObject Pril; // 프릴 오브젝트

    public static int prilstate_org; // 애니메이션(캐릭터)의 현재 상태
    public static int prilstate_cpy; // 애니메이션(캐릭터)의 현재 상태 복사본

    Vector3 TargetPoint; // 목표 좌표값

    public static float movespeed = 0.03f; // 캐릭터 이동 속도
    public static int moveDir_org = 1; // 현재 이동방향  0 = 왼쪽, 1 = 오른쪽
    public static int moveDir_cpy = 1; // 현재 이동방향 복사본
    public void AniChanger() // 애니메이션 스프라이트 변경 기능
    {
        
        if (prilstate_cpy != prilstate_org)
        {
            prilstate_org = prilstate_cpy;
            GetComponent<Animator>().SetInteger("animation", prilstate_org);
        }
    }
    public void CharecterWalk(float targetX) // 캐릭터 걷기 기능
    {
        if (moveDir_cpy == 0) // 왼쪽 이동
            transform.Translate(new Vector3(-movespeed, 0, 0));

        else if(moveDir_cpy == 1) // 오른쪽 이동
            transform.Translate(new Vector3(movespeed, 0, 0));
    }
    public void SetTargetPoint() // 목표지점 설정
    {
        if(Input.GetMouseButtonDown(1))
        {
            prilstate_cpy = (int)ANISTATE.WALK; // 애니메이션 변경
            TargetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Debug.Log(TargetPoint.x);
            Debug.Log(Pril.transform.position.x);

            if (TargetPoint.x > Size.maxMove)
                TargetPoint.x = Size.maxMove;

            if (TargetPoint.x < Size.minMove)
                TargetPoint.x = Size.minMove;

            if (TargetPoint.x > Pril.transform.position.x) // 이동 방향설정 - 오른쪽
            {
                moveDir_cpy = 1;

                if (moveDir_org != moveDir_cpy)
                {
                    moveDir_org = moveDir_cpy;
                    prilstate_cpy = (int)ANISTATE.TURN;
                    AniChanger();
                }
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if(TargetPoint.x < Pril.transform.position.x) // 이동 방향설정 - 왼쪽
            {
                moveDir_cpy = 0;

                if (moveDir_org != moveDir_cpy)
                {
                    moveDir_org = moveDir_cpy;
                    prilstate_cpy = (int)ANISTATE.TURN;
                    AniChanger();
                }
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }

    public void Update() 
    {
        SetTargetPoint();
        AniChanger();

        if (prilstate_cpy == (int)ANISTATE.WALK)
        {
            CharecterWalk(TargetPoint.x);

            if (Mathf.Abs(TargetPoint.x - Pril.transform.position.x) < 0.4)
                prilstate_cpy = (int)ANISTATE.IDLE;
        }
    }
}
