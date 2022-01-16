using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float Speed;
    public Camera cam;

    public int currentItem;
    public int maxItem;


    float xHorizontal; // a, d x축 이동
    float zVertical; // w, s z축 이동

    bool isBorder;

    Vector3 moveVec;

    GameObject nearObject;


    void Start()
    {
        Items items = GetComponent<Items>();
    }


    void Update()
    {
        GetInput();
        Move();
        Turn();
   
    }

    void GetInput()
    {
        xHorizontal = Input.GetAxis("Horizontal");
        zVertical = Input.GetAxis("Vertical");

    }

    void Move()
    {
        moveVec = new Vector3(xHorizontal, 0, zVertical);
        if (!isBorder) //충돌하지 않으면 움직이도록
            transform.position += moveVec * Speed * Time.deltaTime;
    }

    void Turn()
    {
        //#1. 키보드에 의한 회전
        transform.LookAt(transform.position + moveVec);

        //#2. 마우스에 의한 회전
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
        if (Physics.Raycast(ray, out rayHit, 100))
        {
            Vector3 nextVec = rayHit.point - transform.position;
            nextVec.y = 0;
            transform.LookAt(transform.position + nextVec);
        }


    }

    void StopWall()
    {
        Debug.DrawRay(transform.position, transform.forward * 5, Color.green);
        //ray를 보여주는 함수(시작위치, 쏘는방향 * 길이 , 색깔)
        isBorder = Physics.Raycast(transform.position, moveVec, 5, LayerMask.GetMask("Wall"));
        //Raycast = ray에 닿는 오브젝트를 가지는 함수(위치, 방향, 길이, layer - wall에 닿으면 true가됨) = 움직임X
    }

}
