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

    // 플레이어 능력치에 더해지는 수치
    public float addDamage;
    public float addShootRate;
    public float addRange;
    public float addDefence;

    // 아이템 기본 정보
    float useDelay = 0;
    float apoloDelay = 0.7f;
    float stickDelay = 1f;



    public bool Use()
    {
        return false;
    }

}
