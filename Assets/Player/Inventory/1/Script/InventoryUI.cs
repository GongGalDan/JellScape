using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{/*
    Inventory inven;

    public GameObject inventoryPanel; // inventoryUI
    bool activeInventory = false; // 꺼진 상태

    public Slot[] slots;
    public Transform slotHolder;

    private void Start()
    {
        inven = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inven.onSlotCountCahnge += SlotChange;
        inventoryPanel.SetActive(activeInventory); // false = 꺼진 상태
    }

    private void SlotChange(int val)
    {
        for(int i =0; i<slots.Length; i++)
        {
            if (i < inven.SlotCnt)
                slots[i].GetComponent<Button>().interactable = true;
            else
                slots[i].GetComponent<Button>().interactable = false;
        }
    }

    private void Update()
    {
        // i키를 누르면 켜진다.
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory; // true로 변경
            inventoryPanel.SetActive(activeInventory); // true = 켜진 상태
        }
    }

    public void AddSlot()
    {
        inven.SlotCnt++;
    }
    */
}
