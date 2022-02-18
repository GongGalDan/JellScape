using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public UsableItem item; // 획득한 아이템
    public int itemCount; //획득한 아이템의 개수
    public Image itemImage; // 아이템 이미지

    // 이미지의 투명도 조절
    void Setcolor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    // 아이템 획득
    public void AddItem(UsableItem _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        Setcolor(1);
    }

    // 아이템 개수 조정
    void SetSlotCount(int _count)
    {
        itemCount += _count;
    }

    // 슬롯 초기화
    public void ClearSlot(int _count)
    {
        itemCount += _count;

        if(itemCount <= 0)
        {
            item = null;
            itemCount = 0;
            itemImage.sprite = null;
            Setcolor(0);
        }

    }
}
