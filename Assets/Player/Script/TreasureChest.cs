using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    Rigidbody rigidbody;
    int count;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();    
    }

    private void Update()
    {
        Delete();
    }

    //충돌 처리
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            count++;
            Debug.Log(count);

        }
    }

    //10회 타격 후 삭제
    void Delete()
    {
        if(count == 10)
        {
            Destroy(gameObject);
        }
    }

}
