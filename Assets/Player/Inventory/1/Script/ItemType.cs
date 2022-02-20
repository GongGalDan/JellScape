using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    Melee,
    Defence
}

[System.Serializable]
public class ItemType
{
    public ItemType Type;
    public string itemName;
    public Sprite itemImage;

    // �÷��̾� �ɷ�ġ�� �������� ��ġ
    public float addDamage;
    public float addShootRate;
    public float addRange;
    public float addDefence;

    // ������ �⺻ ����
    float useDelay = 0;
    float apoloDelay = 0.7f;
    float stickDelay = 1f;



    public bool Use()
    {
        return false;
    }

}
