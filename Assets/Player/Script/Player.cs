using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera mainCamera;

    float xHorizontal; // a, d x�� �̵�
    float zVertical; // w, s z�� �̵�

    bool isBorder;
    bool isAttackReady;
    bool isDead = false;

    public Vector3 moveVec;

    Animator animator;
    Rigidbody rigidbody;
    Items items;

    float attackDelay;

    // �÷��̾� �⺻ �ɷ�ġ
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
        if (!isBorder && !isDead) //�浹���� ������ �����̵���
            transform.position += moveVec * speed * Time.deltaTime;

        animator.SetBool("isWalk", moveVec != Vector3.zero);

    }

    void Turn()
    {
        if (!isDead)
        {
            //#1. Ű���忡 ���� ȸ��
            transform.LookAt(transform.position + moveVec);

            //#2. ���콺�� ���� ȸ��
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
        //ray�� �����ִ� �Լ�(������ġ, ��¹��� * ���� , ����)
        isBorder = Physics.Raycast(transform.position, moveVec, 5, LayerMask.GetMask("Wall"));
        //Raycast = ray�� ��� ������Ʈ�� ������ �Լ�(��ġ, ����, ����, layer - wall�� ������ true����) = ������X
    }

    void Dead()
    {
        if (isDead) return; //isdead�� true���� �ؿ��� ������ �ȵ�.

        if (hp <= 0)
        {
            isDead = true;
            animator.SetTrigger("Dead");
        }
    }

}