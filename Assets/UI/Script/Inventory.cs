using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool inventoryActivated = false;

    //ÇÊ¿äÇÑ ÄÄÆ÷³ÍÆ®
    [SerializeField]
    private GameObject go_InventoryBase;
    [SerializeField]
    private GameObject go_SlotParnet;

    //½½·Ôµé
    private Slot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        slots = go_SlotParnet.GetComponentsInChildren<Slot>();
        OpenInventory();
    }

    void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inventoryActivated = !inventoryActivated;

            if (inventoryActivated)
                go_InventoryBase.SetActive(true);

            else
                go_InventoryBase.SetActive(false);
        }
    }
    /*
    public void AcquireItem(Items _items, int _count)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(slots[i].item.itemName == _items.Name)
            {
                slots[i].AddItem(_item, _count);
            }
        }
    }*/
}
