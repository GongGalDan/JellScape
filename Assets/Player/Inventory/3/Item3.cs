using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item3 : ScriptableObject
{
    // �⺻ ����
    public string itemName;
    public Sprite itemImage;
    public GameObject prefabs;

    // �÷��̾� �ɷ�ġ�� �������� ��ġ
    public float addDamage;
    public float addShootRate;
    public float addRange;
    public float addDefence;

    // ������ �⺻ ����
    float useDelay = 0;
    float apoloDelay = 0.7f;
    float stickDelay = 1f;

    float apoloDamage;
    float stickDamage;

}
