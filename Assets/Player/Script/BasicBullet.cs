using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    Player2 player;
    Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player2>();
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.forward * player.shootrate;//속도 = 방향 * 속력
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
    }
}
