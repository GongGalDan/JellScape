using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public Transform target; //player object위치
    public Vector3 offset; //y좌표랑 z좌표 입력 

    private void Update()
    {
        transform.position = target.position + offset;
    }
}
