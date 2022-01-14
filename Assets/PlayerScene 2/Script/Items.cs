using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    List<GameObject> items;
    List<GameObject> currentItems;
    GameObject apolo;
    GameObject stick;
    GameObject capsule;
    GameObject icesuit;

    private void Start()
    {
        //ItemInfo itmInfo = GetComponent<ItemInfo>)(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apolo")) 

            currentItems.Add(apolo);

        if (other.CompareTag("stick"))
            currentItems.Add(stick);

        if (other.CompareTag("capsule"))
            currentItems.Add(capsule);

        if (other.CompareTag("icesuit"))
            currentItems.Add(icesuit);
        //if (ItemInfo.mainType.item)
        {

        }
    }

    
}
