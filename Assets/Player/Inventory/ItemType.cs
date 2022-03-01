using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemType : MonoBehaviour
{
    public enum Type
    {
        Apolo,
        Stick,
        Armor
    }

    public Type type; //무기 타입
    public Sprite itemImage; // 이미지

    // 플레이어 능력치에 더해지는 수치
    public float addDamage;
    public float addShootRate;
    public float addRange;
    public float addDefence;

    // 아이템 기본 정보
    float useDelay = 0;
    float apoloDelay = 0.7f;
    float stickDelay = 1f;

    float apoloDamage;
    float stickDamage;
}
