using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot4 : MonoBehaviour
{
    public List<Image> itemImage;
    public Image currentItemImage;
    ItemDB4 itemDataBase;

    private void Start()
    {
        itemDataBase = GameObject.Find("GameManager").GetComponent<ItemDB4>();
       // slot1 = GameObject.Find("SlotItem1").GetComponent<Image>();
        //slot2 = GameObject.Find("SlotItem2").GetComponent<Image>();
    }


}
