using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Follow_Cam : MonoBehaviour
{
    public GameObject Charecter; // 쫒을 오브젝트
    public static int ChasingCount = 0;
    public static int ChasingFullCount = 3;
    public static bool fluidChasingStartFlag;
    public static bool fluidChasingEndFlag = true;
    public static float ChasingSpeed;

    void FixedUpdate()
    {
        if(fluidChasingStartFlag == false)
        {
            ChasingCount++;
            if (ChasingCount == ChasingFullCount)
            {
                fluidChasingStartFlag = true;
            }
        }
    }

    void Update()
    {
        if (fluidChasingStartFlag == true && fluidChasingEndFlag == false || CharecterChaice.chacing_flag == true)
        {
            if (Mathf.Abs((float) Camera.main.transform.position.x - (float)Charecter.transform.position.x)<1) // 카메라와 캐릭터의 포지션이 같아지면
            {
                fluidChasingStartFlag = false;
                fluidChasingEndFlag = true;
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

        // 캐릭터가 카메라 안에 있을 때 내 추격하는 기능

        if (Pril_Ani.prilstate == 1) // 1) 캐릭터가 움직이고 있는 상태이면서
        {
            if (Math.Abs(Charecter.transform.position.x) < 7) // 2) 배경의 최대 범위를 벗어나지 않으면서
            {
                if (Math.Abs((float)Camera.main.transform.position.x - (float)Charecter.transform.position.x) >= 1)
                {
                    if (fluidChasingEndFlag == true)
                    {
                        if (Math.Abs((float)Camera.main.transform.position.x - (float)Charecter.transform.position.x) <= 1.5)
                        {
                            if (Pril_Ani.moveDir == 0) // 4-1 이동방향이 왼쪽이면 왼쪽으로 카메라 추격
                                Camera.main.transform.Translate(-Pril_Ani.movespeed, 0, 0); // 카메라 추격

                            else if (Pril_Ani.moveDir == 1) // 4-1 이동방향이 왼쪽이면 오른쪽으로 카메라 추격
                                Camera.main.transform.Translate(Pril_Ani.movespeed, 0, 0);
                        }
                    }
                }
            }
        }
    }
}