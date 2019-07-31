using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraMode : MonoBehaviour
{
    enum CAMERAMODE {LOCK= 0, FREE = 1, FLUID = 2}  // 잠금카메라, 자유카메라, 유동카메라
    public GameObject Charecter;
    public GameObject ButtenText;
    public static bool pludidmode;
    int mode =0 ;

    public void CameraModeChange()
    {
        if (mode ==(int)CAMERAMODE.LOCK)
        {
            mode = (int)CAMERAMODE.FREE; // FREE 모드로 변경
            transform.GetComponent<Drag_Cam>().enabled = true;
            transform.GetComponent<Follow_Cam>().enabled = false;
            ButtenText.GetComponent<Text>().text = "Free";
            pludidmode = false;
        }
        
        else if (mode == (int)CAMERAMODE.FREE)
        {
            mode = (int)CAMERAMODE.FLUID; // FLUID 모드로 변경
            transform.GetComponent<Drag_Cam>().enabled = true;
            transform.GetComponent<Follow_Cam>().enabled = true;
            ButtenText.GetComponent<Text>().text = "Fluid";
            pludidmode = true;

        }

        else if(mode ==(int) CAMERAMODE.FLUID)
        {
            mode = (int)CAMERAMODE.LOCK; // LOCK 모드로 변경
            transform.GetComponent<Drag_Cam>().enabled = false;
            transform.GetComponent<Follow_Cam>().enabled = true;
            Camera.main.transform.position = new Vector3(Charecter.transform.position.x, 0, -10);
            ButtenText.GetComponent<Text>().text = "Lock";
            pludidmode = false;

        }
    }
}
