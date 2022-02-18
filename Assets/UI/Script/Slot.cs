using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public UsableItem item; // ȹ���� ������
    public int itemCount; //ȹ���� �������� ����
    public Image itemImage; // ������ �̹���

    // �̹����� ���� ����
    void Setcolor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    // ������ ȹ��
    public void AddItem(UsableItem _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        Setcolor(1);
    }

    // ������ ���� ����
    void SetSlotCount(int _count)
    {
        itemCount += _count;
    }

    // ���� �ʱ�ȭ
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
