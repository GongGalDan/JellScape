using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //캐릭터 이동
    public float speed = 10f;
    Rigidbody rigdbody;
    Vector3 movement;

    //카메라
    private Animator animator;
    Camera characterCamera;


    void Awake()
    {
        rigdbody = GetComponent<Rigidbody>(); //캐릭터

        characterCamera = GetComponentInChildren<Camera>(); //palyer안에있는 자식인 camera를 선언?부른다?
    }

    void Update() 
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Run(h, v);
        LookMouseCursor();
    }

    void Run(float h, float v)
    {
        movement.Set(h, 0, v); //x,y,z y는 높이 = 0
        movement = movement.normalized * speed * Time.deltaTime; //대각선 이동가능

        rigdbody.MovePosition(transform.position + movement);
    }
  
    
    public void LookMouseCursor() //마우스 커서쪽으로 바라보기
    {
        Ray ray = characterCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitResult;
        if(Physics.Raycast(ray, out hitResult))
        {
            Vector3 mouseDir = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z) - transform.position;
            // animator.transform.forward = mouseDir;
            transform.LookAt(mouseDir);
        }
    }

}
