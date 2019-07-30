using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Follow_Cam : MonoBehaviour
{
    public GameObject Charecter; // 쫒을 오브젝트
    void Update()
    {
        if (Pril_Ani.prilstate == 1) // 1) 캐릭터가 움직이고 있는 상태이면서
        {
            //Debug.Log(1);
            Debug.Log(Math.Abs((double)this.transform.position.x) -(double)Charecter.transform.position.x);

            if (Math.Abs(Charecter.transform.position.x) < 7.2) // 2) 배경의 최대 범위를 벗어나지 않으면서
            {
                if (Math.Abs((double)this.transform.position.x - (double)Charecter.transform.position.x) >= 1)
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