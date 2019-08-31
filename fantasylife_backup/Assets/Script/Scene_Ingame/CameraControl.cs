using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Size
{
    public static int minMove = -7, maxMove = 7;
    public static int minMapSize = -9, maxMapSize = 9;
}
public class CameraControl : MonoBehaviour
{
    public GameObject Charecter;

    public int ChasingCount;
    public int ChasingFullCount;

    public bool ChasingStartFlag;
    public bool ChasingEndFlag;

    float ChasingSpeed; // 추격 스피드
    float dragSpeed; //드래그 스피드
    float overAccel; // 끄트머리 가속도 값
    float dragAccel; // 드래그 가속도 값
    float bounceAccel;// 바운스 가속도 값

    bool dragAccelFlag; // 드래그 가속 플래그
    bool dragAccelStop; // 드래그 스톱 플래그
    bool bounceFlag; // 바운스 플래그

    Vector3 dragOrigin; // 눌렀을 때 마우스의 좌표값
    Vector3 pos;  // 순수 최초 마우스위치 - 현재 마우스 위치
    Vector3 move; // 이동할 값
    public void SetCamera() // 카메라 수치 세팅

    {
        dragSpeed = 0.3f;
        ChasingSpeed = 0.27f;

        bounceAccel = 0.03f;

        dragAccelFlag = false;
        dragAccelStop = false;
        bounceFlag = false;

        dragOrigin = Input.mousePosition; // 현재의 마우스 포지션값

        ChasingCount = 0;
    }
    public void SetAccel() // 카메라 이동 가속도 세팅
    {
        if (Mathf.Abs((float)move.x) < 0.02) // 드래그 강도1
            dragAccelFlag = false;

        if (Mathf.Abs((float)move.x) < 0.15) // 드래그 강도2
        {
            dragAccel = 0.08f;
            overAccel = 0.09f;
            dragAccelFlag = true;
        }

        if (Mathf.Abs((float)move.x) > 0.15) // 드래그 강도3
        {
            dragAccel = 0.3f;
            overAccel = 0.3f;
            dragAccelFlag = true;
        }
    }
    public void ChaiceCamera()
    {
        if (ChasingStartFlag == true && ChasingEndFlag == false || CharecterChaice.chacing_flag == true)
        {
            if (Mathf.Abs((float)Camera.main.transform.position.x - (float)Charecter.transform.position.x) < 1) // 카메라와 캐릭터의 포지션이 같아지면
            {
                ChasingStartFlag = false;
                ChasingEndFlag = true;
                CharecterChaice.chacing_flag = false;
                return;
            }

            if (Camera.main.transform.position.x < Charecter.transform.position.x)
            {
                Camera.main.transform.Translate(ChasingSpeed, 0, 0);
            }

            if (Camera.main.transform.position.x > Charecter.transform.position.x)
            {
                Camera.main.transform.Translate(-ChasingSpeed, 0, 0);
            }

            ChasingSpeed *= 0.98f;
            if (ChasingSpeed < 0.09f)
            {
                ChasingSpeed = 0.09f;
            }
        }
    } // 카메라 추격 기능
    public void CountingChaice()
    {
        if (ChasingStartFlag == false)
        {
            ChasingCount++;
            if (ChasingCount == ChasingFullCount)
            {
                ChasingStartFlag = true;
            }
        }
    } // 카메라 추격 카운팅 기능
    public void FollowCamera()
    {
        if (Pril_Control.prilstate_cpy == 1) // 1) 캐릭터가 움직이고 있는 상태이면서
        {
            if (Math.Abs(Charecter.transform.position.x) < 7) // 2) 배경의 최대 범위를 벗어나지 않으면서
            {
                if (Math.Abs((float)Camera.main.transform.position.x - (float)Charecter.transform.position.x) >= 1) // 3) 캐릭터와의 좌표 절대값 차이가 1 이상이면서
                {
                    if (ChasingEndFlag == true) // 4) 추격이 완료되었으면서
                    {
                        if (Math.Abs((float)Camera.main.transform.position.x - (float)Charecter.transform.position.x) <= 1.5) // 5) 캐릭터와의 좌표 절대값 차이가 1.5 미만이면서
                        {
                            if (Pril_Control.moveDir_cpy == 0) // 4-1 이동방향이 왼쪽이면 왼쪽으로 카메라 추격
                                Camera.main.transform.Translate(-Pril_Control.movespeed, 0, 0); // 카메라 추격

                            else if (Pril_Control.moveDir_cpy == 1) // 4-1 이동방향이 왼쪽이면 오른쪽으로 카메라 추격
                                Camera.main.transform.Translate(Pril_Control.movespeed, 0, 0);
                        }
                    }
                }
            }
        }
    } // 카메라 팔로우 기능
    public void DragCamera() // 카메라 드래그 기능
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 버튼(0)을 눌렀을 때
            SetCamera();

        if (Input.GetMouseButtonUp(0)) // 마우스 버튼(0)을 놨을 때
        {
            ChasingStartFlag = false;
            ChasingEndFlag = false;
            ChasingCount = 0;

            SetAccel();
        } // 마우스 버튼(0)을 놨을 때

        if (dragAccelFlag == true) // 드래그 가속도가 켜졌을 때
        {
            if (dragAccel >= 0.01f && Mathf.Abs(Camera.main.transform.position.x) < Size.maxMove- 0.1 && bounceFlag == false) // 카메라 바운스 아닐때
            {
                dragAccel *= 0.98f;

                if ((float)move.x < 0) //오른쪽
                    transform.Translate(dragAccel, 0, 0);

                if ((float)move.x > 0) //왼쪽
                    transform.Translate(-dragAccel, 0, 0);
            }

            else if (Mathf.Abs(Camera.main.transform.position.x) > Size.maxMove - 0.1 || bounceFlag == true) // 카메라 바운스 일 때
            {
                bounceFlag = true;
                bounceAccel *= 0.98f;

                if (Camera.main.transform.position.x < -0) //오른쪽
                    transform.Translate(bounceAccel, 0, 0);

                if (Camera.main.transform.position.x > 0) //왼쪽
                    transform.Translate(-bounceAccel, 0, 0);
            }

            else if (dragAccel <= 0.0f) // 드래그 트리거 끄기
            {
                dragAccelFlag = false;
                bounceFlag = false;
            }
        } // 드래그 가속도가 켜졌을 때

        if (!Input.GetMouseButton(0)) // 마우스가 입력 안된 상태 일 때
        {
            overAccel *= 0.88f;

            if (Camera.main.transform.position.x < Size.minMove) //가속도 오른쪽 이동
                transform.Translate(overAccel, 0, 0);

            if (Camera.main.transform.position.x > Size.maxMove) // 가속도 왼쪽 이동
                transform.Translate(-overAccel, 0, 0);

            return;

        } // 마우스가 입력 안된 상태 일 때

        if (dragAccelFlag == false) // 드래그 가속도가 꺼져있을 때
        {
            pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            move = new Vector3(pos.x * dragSpeed, 0, 0);
            transform.Translate(-move, Space.World);
        }// 드래그 가속도가 꺼져있을 때

        if (Camera.main.transform.position.x > 9) // 맵 최대 표시크기 R
            Camera.main.transform.position = new Vector3(Size.maxMapSize, 0, -10);

        if (Camera.main.transform.position.x < -9) // 맵 최대 표시크기 L
            Camera.main.transform.position = new Vector3(Size.minMapSize, 0, -10);
    }

    void Update() // 프레임마다 실행시키기
    {
        ChaiceCamera();
        DragCamera();
        FollowCamera();
    }
    void FixedUpdate() // 1초마다 실행시키기
    {
        CountingChaice();
    }
}