using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory4 : MonoBehaviour
{
    public List<Sprite> itemImage; // 아이템 이미지
    Image slot1; // 첫 번째 슬롯
    Image slot2; // 두 번째 슬롯
    ItemDB4 itemDataBase;

    private void Start()
    {
        itemDataBase = GameObject.Find("GameManager").GetComponent<ItemDB4>();
        slot1 = GameObject.Find("SlotItem1").GetComponent<Image>();
        slot2 = GameObject.Find("SlotItem2").GetComponent<Image>();
    }

    private void Update()
    {
        AddItem();
    }


    void AddItem()
    {
       if(itemDataBase.AllItemList[0].isUsing == true)
        { 
            if (slot1.sprite != null && slot1.sprite !=itemImage[0])
            {
                slot2.sprite = itemImage[0];
            }
            else
            {
                slot1.sprite = itemImage[0];
            }
        }

        if (itemDataBase.AllItemList[1].isUsing == true)
        {
            if (slot1.sprite != null && slot1.sprite != itemImage[1])
            {
                slot2.sprite = itemImage[1];
            }
            else
            {
                slot1.sprite = itemImage[1];
            }
        }

        if (itemDataBase.AllItemList[2].isUsing == true)
        {
            if (slot1.sprite != null && slot1.sprite != itemImage[2])
            {
                slot2.sprite = itemImage[2];
            }
            else
            {
                slot1.sprite = itemImage[2];
            }
        }
    }


     public void SwapItemImage()
    {
        Sprite swapImage;
        swapImage = slot1.sprite;
        slot1.sprite = slot2.sprite;
        slot2.sprite = swapImage;
    }

    public void RemoveItemImage()
    {
        if(itemDataBase.AllItemList[0].isUsing == false && slot1.sprite ==itemImage[0])
        {
            slot1.sprite = null;
            slot2.sprite = slot1.sprite;
        }

        if (itemDataBase.AllItemList[1].isUsing == false && slot1.sprite == itemImage[1])
        {
            slot1.sprite = null;
            slot2.sprite = slot1.sprite;
        }

        if (itemDataBase.AllItemList[2].isUsing == false && slot1.sprite == itemImage[2])
        {
            slot1.sprite = null;
            slot2.sprite = slot1.sprite;
        }
    }
}
