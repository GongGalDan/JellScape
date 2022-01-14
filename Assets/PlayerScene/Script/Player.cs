using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed; //이동 속도
    public Camera Camera;

    public int CurItem; //현재 소지한 아이템 개수
    public int MaxItem; //최대 소지가능한 아이템 개수
    public GameObject[] weapons;
    public bool[] hasWeapons;

    float xMove; //x축
    float zMove; //z축


    bool fDown; //기본 공격


    Vector3 moveVec;

    bool isBorder; //벽에 닿았는지


    GameObject nearObject; //근처에있는 오브젝트



    void Start()
    {
        
    }

    void Awake()
    {
        
    }

    void Update()
    {
        GetInput();
        Move();
        Turn();
    }

    void FixedUpdate()
    {
        StopToWall();
    }

    void GetInput()
    {
        xMove = Input.GetAxis("Horizontal"); //x축 이동 a d
        zMove = Input.GetAxis("Vertical"); //z축이동 w s

       
    }

    void Move()
    {
        moveVec = new Vector3(xMove, 0, zMove).normalized;
        if(!isBorder) //충돌하지 않으면 움직이도록
            transform.position += moveVec * Speed * Time.deltaTime;
    }

    void Turn()
    {
        //#1. 키보드에 의한 회전
        transform.LookAt(transform.position + moveVec);

        //#2. 마우스에 의한 회전
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
        if (Physics.Raycast(ray, out rayHit, 100))
        {
            Vector3 nextVec = rayHit.point - transform.position;
            nextVec.y = 0;
            transform.LookAt(transform.position + nextVec);
        }
    }

    void StopToWall()
    {
        isBorder = Physics.Raycast(transform.position, moveVec, 5, LayerMask.GetMask("Wall"));
        // Raycast = ray에 닿는 오브젝트를 가지하는 함수(위치, 방향,길이,layer - wall에 닿으면) true로 바뀜
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item") //태그가 item이면서
        {
            Item item = other.GetComponent<Item>();
            switch (item.mainType) //item 메인 타입중에서
            {
                case Item.MainType.Item: //item인 object만
                    if (CurItem == MaxItem)
                        return;
                    CurItem += item.value;
                    break;
            }

            Destroy(other.gameObject);
        }
        
    }

}
