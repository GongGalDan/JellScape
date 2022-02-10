using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    Rigidbody rigid;
    float bulletSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.forward * bulletSpeed;//속도 = 방향 * 속력
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
}
