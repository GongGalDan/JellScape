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
    Item equipItem;
    ItemSwitching switching;


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
        moveVec = new Vector3(xMove, 0, zMove);
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
        Debug.DrawRay(transform.position, transform.forward * 5, Color.green);
        //ray를 보여주는 함수(시작위치, 쏘는방향 * 길이 , 색깔)
        isBorder = Physics.Raycast(transform.position, moveVec, 5, LayerMask.GetMask("Wall"));
        // Raycast = ray에 닿는 오브젝트를 가지하는 함수(위치, 방향,길이,layer - wall에 닿으면) true로 바뀜
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item") //태그가 item이면
        {
            nearObject = other.gameObject; //nearobject에 저장
      
            Item item = nearObject.GetComponent<Item>();
            switch (item.mainType) //item 메인 타입중에서
            {
                case Item.MainType.Item: //item인 object만
                    if (CurItem == MaxItem)
                        return;
                    CurItem += item.value; //현재 아이템 개수에는 value값이 더해지고
                    Debug.Log("dtd");
                    int weaponIndex = item.number; //weaponindex에는 number가 들어감
                    hasWeapons[weaponIndex] = true;
                    break;
            }

            Destroy(nearObject);
        }
        
    }

    void Swap()
    {
        if (equipItem = null) 
            return;


    }

}
