using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory4 : MonoBehaviour
{
    public List<Sprite> itemImage; // ������ �̹���
    Image slot1; // ù ��° ����
    Image slot2; // �� ��° ����
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


    //slot 1 2 ��ġ�� �̹����� �ְ� �ʹ�...
    void AddItem()
    {
       if(itemDataBase.AllItemList[0].isUsing == true)
        {
            if (slot1.sprite = null)
            {
                slot1.sprite = itemImage[0];
            }

            if (slot1.sprite != null && slot1.sprite != itemImage[0])
            {
                slot2.sprite = itemImage[0];
                
            }
        }

        if (itemDataBase.AllItemList[1].isUsing == true)
        {
            if(slot1.sprite = null)
            {
                slot1.sprite = itemImage[1];
            }
            if (slot1.sprite != null && slot1.sprite != itemImage[1])
            {
                slot2.sprite = itemImage[1];
            }
        }

        if (itemDataBase.AllItemList[2].isUsing == true)
        {
            if (slot1.sprite = null)
            {
                slot1.sprite = itemImage[2];
            }

            if (slot1.sprite != null && slot1.sprite != itemImage[2])
            {
                slot2.sprite = itemImage[2];
            }
        }
    }

}
