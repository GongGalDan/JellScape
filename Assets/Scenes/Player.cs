using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed; // 이동 속도 입력
    float HorizontalMove; //가로 x축
    float VerticalMove; //세로 z축
    Vector3 MoveVec; //3D

    Animator animator; //애니메이터
    
    void Start()
    {
        
    }

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    
    void Update()
    {
        HorizontalMove = Input.GetAxis("Horizontal"); //x축 이동
        VerticalMove = Input.GetAxis("Vertical"); //z축 이동

        MoveVec = new Vector3(HorizontalMove, 0, VerticalMove).normalized; // 방향, normalized = 거리가 1로 고정
        transform.position += MoveVec * speed * Time.deltaTime; // 위치는 3개를 곱한만큼 변함 (speed로 속도 조절)

        animator.SetBool("Run", MoveVec != Vector3.zero ); //moveVec이 0,0,0이 아닐때 달리는 모션이 나온다.

        transform.LookAt(transform.position + MoveVec); //가는 방향으로 바라본다.

    }
}
