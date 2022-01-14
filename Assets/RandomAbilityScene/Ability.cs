using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityGrade { S, A, B, C }

[System.Serializable]
public class Ability
{
    // �ɷ� �̸�
    public string abilityName;
    // ������ �̹���
    public Sprite abilityImage;
    // �ɷ�ġ ���
    public AbilityGrade abilityGrade;
    // ���� �� ��� �� ����ġ ( ��� �ɷ��� �Ȱ��� Ȯ���� ������ �� ����) 
    public int weight;
    
    public Ability(Ability ability)
    {
        this.abilityName = ability.abilityName;
        this.abilityImage = ability.abilityImage;
        this.abilityGrade = ability.abilityGrade;
        this.weight = ability.weight;
    }
}
