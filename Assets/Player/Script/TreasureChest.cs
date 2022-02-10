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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            count++;
            Debug.Log(count);

        }
    }

    void Delete()
    {
        if(count == 10)
        {
            Destroy(gameObject);
        }
    }

}
