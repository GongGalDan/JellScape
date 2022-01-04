using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed; // �̵� �ӵ� �Է�
    float HorizontalMove; //���� x��
    float VerticalMove; //���� z��
    Vector3 MoveVec; //3D

    Animator animator; //�ִϸ�����
    
    void Start()
    {
        
    }

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    
    void Update()
    {
        HorizontalMove = Input.GetAxis("Horizontal"); //x�� �̵�
        VerticalMove = Input.GetAxis("Vertical"); //z�� �̵�

        MoveVec = new Vector3(HorizontalMove, 0, VerticalMove).normalized; // ����, normalized = �Ÿ��� 1�� ����
        transform.position += MoveVec * speed * Time.deltaTime; // ��ġ�� 3���� ���Ѹ�ŭ ���� (speed�� �ӵ� ����)

        animator.SetBool("Run", MoveVec != Vector3.zero ); //moveVec�� 0,0,0�� �ƴҶ� �޸��� ����� ���´�.

        transform.LookAt(transform.position + MoveVec); //���� �������� �ٶ󺻴�.

    }
}
