using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed; //�̵� �ӵ�
    public Camera Camera;

    public int CurItem; //���� ������ ������ ����
    public int MaxItem; //�ִ� ���������� ������ ����
    public GameObject[] weapons;
    public bool[] hasWeapons;

    float xMove; //x��
    float zMove; //z��

    bool fDown; //�⺻ ����
    bool sDwon; //���� ��ü
    bool fDown2; //������ ����

    Vector3 moveVec;

    bool isBorder; //���� ��Ҵ���
    bool isFireReady; //������ �غ� �����

    GameObject nearObject; //��ó���ִ� ������Ʈ
    Weapon equipWeapon; //�������� ����
    int equipWeaponIndex = 0; //���� index
    float fireDelay; //���� ������


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
        xMove = Input.GetAxis("Horizontal"); //x�� �̵� a d
        zMove = Input.GetAxis("Vertical"); //z���̵� w s
        fDown = Input.GetButton("Fire1"); //�⺻ ���� ���콺 ��Ŭ��
        fDown2 = Input.GetButton("Fire2"); //������ ���� ���콺 ��Ŭ��
    }

    void Move()
    {
        moveVec = new Vector3(xMove, 0, zMove).normalized;
        if(!isBorder) //�浹���� ������ �����̵���
            transform.position += moveVec * Speed * Time.deltaTime;
    }

    void Turn()
    {
        //#1. Ű���忡 ���� ȸ��
        transform.LookAt(transform.position + moveVec);

        //#2. ���콺�� ���� ȸ��
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
        //ray�� �����ִ� �Լ�(������ġ, ��¹��� * ���� , ����)
        isBorder = Physics.Raycast(transform.position, moveVec, 5, LayerMask.GetMask("Wall"));
        // Raycast = ray�� ��� ������Ʈ�� �����ϴ� �Լ�(��ġ, ����,����,layer - wall�� ������) true�� �ٲ�
    }

    void Attack()
    {
        if (equipWeapon == null) //������ ���Ⱑ ������ ����X
            return;
        fireDelay += Time.deltaTime;
        isFireReady = equipWeapon.rate < fireDelay; //���ݼӵ��� ���ݴ�⺸�� �۾ƾ� �غ񰡵�

        if (fDown)
        {
            equipWeapon.Use(); //use �Լ� ����
            fireDelay = 0; //�������ؼ� delay = 0
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item") //�±װ� item�̸鼭
        {
            Item item = other.GetComponent<Item>();
            switch (item.mainType) //item ���� Ÿ���߿���
            {
                case Item.MainType.Item: //item�� object��
                    if (CurItem == MaxItem)
                        return;
                    CurItem += item.value;
                    break;
            }

            Destroy(other.gameObject);
        }
        
    }

}
