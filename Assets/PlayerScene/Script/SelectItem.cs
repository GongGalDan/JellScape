using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectItem : MonoBehaviour
{
    public Item item; //획득한 아이템
    public int itemCount; //획득한 아이템의 개수
    public Image itemImage; //아이템의 이미지


    private void SetColor(float _alpha) //이미지 투명도 조절
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    public void AddItem(Item _item, int _count = 1) //아이템 획득
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        SetColor(1);
    }

    public void Throw() //아이템 버리기
    {
        if (Input.GetKeyDown("r"))
        {
            item = null;
            itemCount = 0;
            itemImage.sprite = null;
            SetColor(0);
        }
    }

}
