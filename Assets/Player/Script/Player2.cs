using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public Camera cam;

    float xHorizontal; // a, d x�� �̵�
    float zVertical; // w, s z�� �̵�

    bool isBorder;

    Vector3 moveVec;
    Animator animat;

    //player ability
    public float damage; //���ݷ�
    public float shootrate; //���ݼӵ�
    public float speed; //�̵��ӵ�
    public float range; //��Ÿ�
    public float currentHp; //���� hp
    public float MaxHp; //�ִ� hp
    public float defence; //����
    public float critical; //ũ��Ƽ��



    void Start()
    {
        Items items = GetComponent<Items>();
        animat = GetComponentInChildren<Animator>();
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
        if (!isBorder) //�浹���� ������ �����̵���
            transform.position += moveVec * speed * Time.deltaTime;

        animat.SetBool("isWalk", moveVec != Vector3.zero);
    }

    void Turn()
    {
        //#1. Ű���忡 ���� ȸ��
        transform.LookAt(transform.position + moveVec);

        //#2. ���콺�� ���� ȸ��
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
        //ray�� �����ִ� �Լ�(������ġ, ��¹��� * ���� , ����)
        isBorder = Physics.Raycast(transform.position, moveVec, 5, LayerMask.GetMask("Wall"));
        //Raycast = ray�� ��� ������Ʈ�� ������ �Լ�(��ġ, ����, ����, layer - wall�� ������ true����) = ������X
    }

}
