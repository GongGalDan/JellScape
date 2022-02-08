using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityGrade { S, A, B, C }

[System.Serializable]
public class Ability
{
    // �ɷ� �̸�
    public string abilityName;
    // �ɷ� �±�
    public string abilityTag;
    // ������ �̹���
    public Sprite abilityImage;
    // �ɷ�ġ ���
    public AbilityGrade abilityGrade;
    // ���� �� ��� �� ����ġ (��� �ɷ��� �Ȱ��� Ȯ���� ������ �� ����) 
    public int weight;
    // ���� ���� (�ߺ� ����)
    public bool isPicked;
    // ������ ���� �ɷ� (�ߺ� ����)
    public bool isElement;
    // �ѹ��� ���� �� �ִ� �ɷ�����
    public bool isPickableOnce;
    
    public Ability(Ability ability)
    {
        this.abilityName = ability.abilityName;
        this.abilityTag = ability.abilityTag;
        this.abilityImage = ability.abilityImage;
        this.abilityGrade = ability.abilityGrade;
        this.weight = ability.weight;
        this.isPicked = ability.isPicked;
        this.isElement = ability.isElement;
        this.isPickableOnce = ability.isPickableOnce;
    }
}
