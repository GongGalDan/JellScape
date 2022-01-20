using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public Camera mainCamera;

    float xHorizontal; // a, d x�� �̵�
    float zVertical; // w, s z�� �̵�

    bool isBorder;
    bool isAttackReady;
    bool isMove;
    bool isTurn;
    bool isSwap;



    Vector3 moveVec;
    Animator animator;
    Items items;
    Attack equipWeapon;
    float attackDelay;

    //player ability (basic~ �⺻�ɷ�ġ(�����Ҷ� �����´ɷ�), current~ �������� �ɷ�ġ(Ȯ�ο�))
    public float basicDamage;
    public float currentDamage; //���ݷ� 
    public float basicShootRate;
    public float currentShootRate; //���ݼӵ�
    public float basicSpeed;
    public float currentSpeed; //�̵��ӵ�
    public float basicRange;
    public float currentRange; //��Ÿ�
    public float currentHp; //���� hp
    public float MaxHp; //�ִ� hp
    public float basicDefence; 
    public float currentDefence; //����
    public float basicCritical;
    public float currentCritical; //ũ��Ƽ��



    void Start()
    {
        items = GetComponent<Items>();
        animator = GetComponentInChildren<Animator>();
        equipWeapon = GetComponent<Attack>();
    }


    void Update()
    {
        GetInput();
        Move();
        Turn();
        Hit();
    }

    void GetInput()
    {
        xHorizontal = Input.GetAxis("Horizontal");
        zVertical = Input.GetAxis("Vertical");

    }

    void Move()
    {
        moveVec = new Vector3(xHorizontal, 0, zVertical);
        if (!isBorder) //�浹���� ������ �����̵���
            transform.position += moveVec * currentSpeed * Time.deltaTime;

        animator.SetBool("isWalk", moveVec != Vector3.zero);
    }

    void Turn()
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
            isTurn = true;
        }
    }

    void StopWall()
    {
        Debug.DrawRay(transform.position, transform.forward * 5, Color.green);
        //ray�� �����ִ� �Լ�(������ġ, ��¹��� * ���� , ����)
        isBorder = Physics.Raycast(transform.position, moveVec, 5, LayerMask.GetMask("Wall"));
        //Raycast = ray�� ��� ������Ʈ�� ������ �Լ�(��ġ, ����, ����, layer - wall�� ������ true����) = ������X
    }


    void Hit()
    {
        if (equipWeapon == null)
            return;

        attackDelay += Time.deltaTime;
        isAttackReady = equipWeapon.rate < attackDelay;

        if(Input.GetMouseButtonDown(1) && isAttackReady)
        {
            
            equipWeapon.Use();
            animator.SetTrigger("doAttac"); // (equipWeapon.type == Attack.Type.Melee ? "doAttack" : "doSwing" );
            attackDelay = 0;
        }
    }
}
