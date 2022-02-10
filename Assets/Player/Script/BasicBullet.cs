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
        rigid.velocity = transform.forward * bulletSpeed;//¼Óµµ = ¹æÇâ * ¼Ó·Â
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

    // »ÌÀº ¼Ó¼º ´É·Âµé·Î ¹Ù²ãÁÖ±â
    
    void ChangeBullet()
    {
        if(Input.GetKeyDown("1"))
        {
            bulletcolor.color = Color.red;

            Debug.Log("ÇÖ Á©¸®");
        }
        
        if (Input.GetKeyDown("2"))
        {
            bulletcolor.color = Color.blue;
            Debug.Log("¾ÆÀÌ½º Á©¸®");
        }

        if (Input.GetKeyDown("3"))
        {
            bulletcolor.color = Color.yellow;
            Debug.Log("Àü±â Á©¸®");
        }

        if (Input.GetKeyDown("4"))
        {
            bulletcolor.color = Color.green;
            Debug.Log("µ¶ Á©¸®");
        }

        if (Input.GetKeyDown("5"))
        {
            bulletcolor.color = Color.black;
            Debug.Log("ÆøÅº Á©¸®");
        }

    }
}
