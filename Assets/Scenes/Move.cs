using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //ĳ���� �̵�
    public float speed = 10f;
    Rigidbody rigdbody;
    Vector3 movement;

    //ī�޶�
    private Animator animator;
    Camera characterCamera;


    void Awake()
    {
        rigdbody = GetComponent<Rigidbody>(); //ĳ����

        characterCamera = GetComponentInChildren<Camera>(); //palyer�ȿ��ִ� �ڽ��� camera�� ����?�θ���?
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
        movement.Set(h, 0, v); //x,y,z y�� ���� = 0
        movement = movement.normalized * speed * Time.deltaTime; //�밢�� �̵�����

        rigdbody.MovePosition(transform.position + movement);
    }
  
    
    public void LookMouseCursor() //���콺 Ŀ�������� �ٶ󺸱�
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
