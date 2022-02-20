using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot2 : MonoBehaviour
{
    public int i; // 구분 변수
    private Inventory2 inventory;

    private void Awake()
    {
        inventory = GameObject.FindObjectOfType<Inventory2>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.fullCheck[i] = false;
        }
    }

    void RemoveItem()
    {
        for (int index = 0; index < transform.childCount; index++)
        {
            Destroy(transform.GetChild(index).gameObject);

        }
    }

}
