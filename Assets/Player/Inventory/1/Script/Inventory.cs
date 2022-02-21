using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{/*
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnSlotCountCahnge(int val); // 대리자 정의
    public OnSlotCountCahnge onSlotCountCahnge; // 대리자 인스턴스화

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;

    //public List<Item> items = new List<Item>();


    private int slotCnt; // slot의 개수

    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
            onSlotCountCahnge.Invoke(slotCnt);
        }
    }

    void Start()
    {
        SlotCnt = 2;
    }

    /*public bool AddItem(Item _item)
    {
        if(items.Count < SlotCnt)
        {
            items.Add(_item);
            if(onChangeItem != null)
            onChangeItem.Invoke();
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IceSuit"))
        {
            FieldItems fieldItems = other.GetComponent<FieldItems>();
            if (AddItem(fieldItems.GetItem()))
                fieldItems.DestroyItem();
        }
    }

    */
}
