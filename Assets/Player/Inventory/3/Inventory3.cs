using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory3 : MonoBehaviour
{/*
    public List<Item3> items;

    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private Slot3[] slots;

    Items Item;

    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot3>();
    }

    private void Awake()
    {
        AddItem();
        //FreshSlot();
    }

    private void Start()
    {
        Item = GameObject.Find("Player").GetComponent<Items>();
    }


    public void FreshSlot()
    {
        int i = 0;
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }

        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
    }

    public void AddItem()
    {
        if(items.Count < slots.Length)
        {
            if (Item.currentItems[0].CompareTag("Apolo"))
            {
                items.Add(items[0]);
                FreshSlot();
            }

        }
        else
        {
            print("½½·ÔÀÌ °¡µæ Â÷ ÀÖ½À´Ï´Ù.");
        }
    }
    */
}
