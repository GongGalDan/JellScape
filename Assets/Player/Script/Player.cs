using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera mainCamera;

    float xHorizontal; // a, d x축 이동
    float zVertical; // w, s z축 이동

    [SerializeField] float invincibleTimer;
    float attackDelay;

    bool isBorder; 
    bool isAttackReady;
    bool isDead = false;

    public Vector3 moveVec;

    PlayerData playerData;
    Animator animator;
    Rigidbody rigidbody;
    Items items;


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
        RandomAbility();
    }


    //player 능력치 적용
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

    //키 입력
    void GetInput()
    {
        xHorizontal = Input.GetAxis("Horizontal");
        zVertical = Input.GetAxis("Vertical");
    }

    //이동
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

    //사망처리
    void Dead()
    {
        if (isDead) return; //isdead가 true여서 밑에는 실행이 안됨.

        if (hp <= 0)
        {
            isDead = true;
            animator.SetTrigger("Dead");
        }
    }

    //무적능력 적용
    void RandomAbility()
    {
        if(playerData.invincible == true)
        {
            invincibleTimer += Time.deltaTime;

            if (invincibleTimer >= 0 && invincibleTimer <= 3)
            {
                //3초 동안 무적
                gameObject.layer = 12;
            }

            else if(invincibleTimer >3 && invincibleTimer <23)
            { 
                //20초 쿨타임
                gameObject.layer = 6;
            }

            else if(invincibleTimer >= 23)
            {
                invincibleTimer = 0;
            }
        }
    }

}