using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    Rigidbody rigid;
    [SerializeField] Material bulletcolor;
    float bulletSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.forward * bulletSpeed;//�ӵ� = ���� * �ӷ�
        bulletcolor = GetComponent<TrailRenderer>().material;
    }

    private void Update()
    {
        ChangeBullet();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Chest")
        {
            Destroy(gameObject);
        }
    }

    // ���� �Ӽ� �ɷµ�� �ٲ��ֱ�
    
    void ChangeBullet()
    {
        if(Input.GetKeyDown("1"))
        {
            bulletcolor.color = Color.red;

            Debug.Log("�� ����");
        }
        
        if (Input.GetKeyDown("2"))
        {
            bulletcolor.color = Color.blue;
            Debug.Log("���̽� ����");
        }

        if (Input.GetKeyDown("3"))
        {
            bulletcolor.color = Color.yellow;
            Debug.Log("���� ����");
        }

        if (Input.GetKeyDown("4"))
        {
            bulletcolor.color = Color.green;
            Debug.Log("�� ����");
        }

        if (Input.GetKeyDown("5"))
        {
            bulletcolor.color = Color.black;
            Debug.Log("��ź ����");
        }

    }
}
