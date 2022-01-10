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
    bool sDwon; //무기 교체
    bool fDown2; //아이템 공격

    Vector3 moveVec;

    bool isBorder; //벽에 닿았는지
    bool isFireReady; //공격할 준비가 됬는지

    GameObject nearObject; //근처에있는 오브젝트
    Weapon equipWeapon; //장착중인 무기
    int equipWeaponIndex = 0; //무기 index
    float fireDelay; //공격 딜레이


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
        fDown = Input.GetButton("Fire1"); //기본 공격 마우스 좌클릭
        fDown2 = Input.GetButton("Fire2"); //아이템 공격 마우스 우클릭
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
        Debug.DrawRay(transform.position, transform.forward * 5, Color.green);
        //ray를 보여주는 함수(시작위치, 쏘는방향 * 길이 , 색깔)
        isBorder = Physics.Raycast(transform.position, moveVec, 5, LayerMask.GetMask("Wall"));
        // Raycast = ray에 닿는 오브젝트를 가지하는 함수(위치, 방향,길이,layer - wall에 닿으면) true로 바뀜
    }

    void Attack()
    {
        if (equipWeapon == null) //장착된 무기가 없으면 실행X
            return;
        fireDelay += Time.deltaTime;
        isFireReady = equipWeapon.rate < fireDelay; //공격속도가 공격대기보다 작아야 준비가됨

        if (fDown)
        {
            equipWeapon.Use(); //use 함수 실행
            fireDelay = 0; //공격을해서 delay = 0
        }
        
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
