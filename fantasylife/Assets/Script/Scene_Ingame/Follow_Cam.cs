using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Cam : MonoBehaviour
{
    public GameObject Charecter; // 쫒을 오브젝트
    void Update()
    {
        Camera.main.transform.position = Charecter.transform.position - Vector3.forward;
    }
}