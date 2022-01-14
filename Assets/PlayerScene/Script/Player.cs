using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed; //�̵� �ӵ�
    public Camera Camera;

    public int CurItem; //���� ������ ������ ����
    public int MaxItem; //�ִ� ���������� ������ ����
    public float itemDelay; //������ ��ü �����̽ð�
    public GameObject[] items;
    public bool[] hasitems;
    int itemIndex = -1; //0���� ������ inex ����

    float xMove; //x��
    float zMove; //z��

    bool fDown; //�⺻ ����
    bool isSwap;

    Vector3 moveVec;

    bool isBorder; //���� ��Ҵ���

    GameObject nearObject; //��ó���ִ� ������Ʈ
    Item equipItem;

    

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

       
    }

    void Move()
    {
        moveVec = new Vector3(xMove, 0, zMove);
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


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item") //�±װ� item�̸�
        {
            nearObject = other.gameObject; //nearobject�� ����

            Item item = nearObject.GetComponent<Item>();
            switch (item.mainType) //item ���� Ÿ���߿���
            {
                case Item.MainType.Item: //item�� object��
                    if (CurItem == MaxItem)
                        return;
                    CurItem += item.value; //���� ������ �������� value���� ��������
                    itemIndex = item.number; //weaponindex���� number�� ��
                    hasitems[itemIndex] = true;
                    Destroy(nearObject);
                    break;
            }
        }
    }

}
