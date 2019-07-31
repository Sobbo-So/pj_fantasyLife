using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_Cam : MonoBehaviour
{
    float dragSpeed; //드래그 스피드
    float overAccel; // 끄트머리 가속도 값
    float dragAccel; // 드래그 가속도 값
    bool dragAccelFlag; // 드래그 가속 플래그
    bool dragAccelStop; // 드래그 스톱 플래그
    Vector3 dragOrigin;
    Vector3 pos;
    Vector3 move;
    Vector3 nine;
    void Update()
    { 
        // 1_1 마우스 눌렀을 때
        if (Input.GetMouseButtonDown(0))
        {
            dragSpeed = 0.3f; // 드래그 스피드 초기화
            overAccel = 0.3f; // 끄트머리 가속도값 초기화
            dragAccel = 0.15f; // 드래그 가속도값 초기화
            dragAccelFlag = false; // 드래그 엑셀
            dragAccelStop = false;
            dragOrigin = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (Mathf.Abs((float)move.x) < 0.15)
            {
                dragAccel = 0.08f;
                overAccel = 0.09f;
            }

            if (Mathf.Abs((float)move.x) > 0.15)
            {
                dragAccel = 0.3f;
                overAccel = 0.3f;
            }

            if ((float)move.x == 0)
                return;

            dragAccelFlag = true;
            Debug.Log((float)move.x);
        }

        if(dragAccelFlag == true)
        {
            if (dragAccel >= 0.01f && Mathf.Abs(Camera.main.transform.position.x) < 6.7) //제한점 더 낮음
            {
                dragAccel *= 0.98f;

                if ((float)move.x < 0)
                    transform.Translate(dragAccel, 0, 0); //오른쪽 가속도

                if ((float)move.x > 0)
                    transform.Translate(-dragAccel, 0, 0); // 왼쪽 가속도
            }
            else
                dragAccelFlag = false;


        }

        if (!Input.GetMouseButton(0))
        {
            overAccel *= 0.88f;

            if (Camera.main.transform.position.x > 7) //가릴려고 노력하는 영역 ★
                transform.Translate(-overAccel, 0, 0);

            if (Camera.main.transform.position.x < -7)
                transform.Translate(overAccel, 0, 0);

            return;

        }
        if (dragAccelFlag == false)
        {
            pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);

            move = new Vector3(pos.x * dragSpeed, 0, 0); // 카메라는 좌우로만 이동

            if (Mathf.Abs(Camera.main.transform.position.x) < 9) // 넘으면 안되는 영역 ★
                transform.Translate(-move, Space.World); // (-) = 드래그의 반대방향
        }
    }
}
