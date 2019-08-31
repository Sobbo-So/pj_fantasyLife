using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActButton : MonoBehaviour
{
    float MaxDistannce = 15f;
    Vector3 MousePosition;
    Camera Camera;
    public GameObject actUi;


    private void Start()
    {
        Camera = GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        /* if (Input.GetMouseButtonDown(0))
        {
            MousePosition = Input.mousePosition;
            MousePosition = Camera.ScreenToWorldPoint(MousePosition);

            RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.forward, MaxDistannce);
            if (hit)
            {
                MousePosition = Camera.WorldToScreenPoint(MousePosition);
                actUi.transform.position = MousePosition;
                Debug.Log("MousePosition");
                actUi.SetActive(true);
            }
        }
        */
    }

}

