using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera mainCamera;

    float xHorizontal; // a, d x축 이동
    float zVertical; // w, s z축 이동

    bool isBorder;
    bool isAttackReady;
    bool isDead = false;

    public Vector3 moveVec;

    Animator animator;
    Rigidbody rigidbody;
    Items items;

    float attackDelay;

    // 플레이어 기본 능력치
    [SerializeField]
    public float hp;
    [SerializeField]
    public float damage;
    [SerializeField]
    public float shootRate;
    [SerializeField]
    public float speed;
    [SerializeField]
    public float range;
    [SerializeField]
    public float defence;
    [SerializeField]
    public float critical;

    PlayerData playerData;

    void Start()
    {
        items = GetComponent<Items>();
        animator = GetComponentInChildren<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        playerData = GameObject.Find("GameManager").GetComponent<PlayerData>();
        InitPlayer();
    }

    void Update()
    {
        GetInput();
        Move();
        Turn();
        Dead();

    }

    void InitPlayer()
    {
        hp = playerData.hp;
        damage = playerData.damage;
        shootRate = playerData.shootRate;
        speed = playerData.speed;
        range = playerData.range;
        defence = playerData.defence;
        critical = playerData.critical;
    }

    void GetInput()
    {
        xHorizontal = Input.GetAxis("Horizontal");
        zVertical = Input.GetAxis("Vertical");
    }

    void Move()
    {
        moveVec = new Vector3(xHorizontal, 0, zVertical);
        if (!isBorder && !isDead) //충돌하지 않으면 움직이도록
            transform.position += moveVec * speed * Time.deltaTime;

        animator.SetBool("isWalk", moveVec != Vector3.zero);

    }

    void Turn()
    {
        if (!isDead)
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
    }

    void StopWall()
    {
        Debug.DrawRay(transform.position, transform.forward * 5, Color.green);
        //ray를 보여주는 함수(시작위치, 쏘는방향 * 길이 , 색깔)
        isBorder = Physics.Raycast(transform.position, moveVec, 5, LayerMask.GetMask("Wall"));
        //Raycast = ray에 닿는 오브젝트를 가지는 함수(위치, 방향, 길이, layer - wall에 닿으면 true가됨) = 움직임X
    }

    void Dead()
    {
        if (isDead) return; //isdead가 true여서 밑에는 실행이 안됨.

        if (hp <= 0)
        {
            isDead = true;
            animator.SetTrigger("Dead");
        }
    }

}