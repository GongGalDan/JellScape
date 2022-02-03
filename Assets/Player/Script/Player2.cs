using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public Camera mainCamera;

    float xHorizontal; // a, d x축 이동
    float zVertical; // w, s z축 이동

    bool isBorder;
    bool isAttackReady;


    Vector3 moveVec;
    Animator animator;
    Items items;

    float attackDelay;

    //player ability (basic~ 기본능력치(시작할때 가지는능력), current~ 더해지는 능력치(확인용))
    public float basicDamage;
    public float currentDamage; //공격력 
    public float basicShootRate;
    public float currentShootRate; //공격속도
    public float basicSpeed;
    public float currentSpeed; //이동속도
    public float basicRange;
    public float currentRange; //사거리
    public float currentHp; //현재 hp
    public float MaxHp; //최대 hp
    public float basicDefence; 
    public float currentDefence; //방어력
    public float basicCritical;
    public float currentCritical; //크리티컬



    void Start()
    {
        items = GetComponent<Items>();
        animator = GetComponentInChildren<Animator>();
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
            transform.position += moveVec * currentSpeed * Time.fixedDeltaTime;

        animator.SetBool("isWalk", moveVec != Vector3.zero);
    }

    void Turn()
    {
        //#1. 키보드에 의한 회전
        transform.LookAt(transform.position + moveVec);

        //#2. 마우스에 의한 회전
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
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

    void AddItemAbility()
    {
        if (items.currentItems[0].CompareTag("Apolo"))
        {
            currentRange += 0.2f;
            currentDamage += 10;
            currentShootRate += 0.1f;
        }

        if (items.currentItems[0].CompareTag("Stick"))
        {
            currentDamage += 10;
            currentShootRate += 0.1f;
        }

        if (items.currentItems[0].CompareTag("Icesuit"))
        {
            currentDefence += 50;
        }

    }

}
