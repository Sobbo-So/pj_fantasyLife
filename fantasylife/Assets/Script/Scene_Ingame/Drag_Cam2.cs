using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Drag_Cam2 : MonoBehaviour
{
    public float Speed;
    public Vector2 nowPos, prePos;
    public Vector3 movePos;
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                prePos = touch.position - touch.deltaPosition;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                nowPos = touch.position - touch.deltaPosition;
                movePos = (Vector3)(prePos - nowPos) * Speed;
                transform.Translate(movePos); // 이럴수가 !!!!!!!
                prePos = touch.position - touch.deltaPosition;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
            }
        }
    }
}