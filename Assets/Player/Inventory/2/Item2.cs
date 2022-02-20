using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2 : MonoBehaviour
{
    private Inventory2 inventory;
    public GameObject itemObject;

    private void Awake()
    {
        inventory = GameObject.FindObjectOfType<Inventory2>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            for(int i = 0; i < inventory.slots.Length; i++ )
            {
                if(inventory.fullCheck[i] == false)
                {
                    inventory.fullCheck[i] = true;
                    Instantiate(itemObject, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
