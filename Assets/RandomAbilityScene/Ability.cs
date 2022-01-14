using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityGrade { S, A, B, C }

[System.Serializable]
public class Ability
{
    // 능력 이름
    public string abilityName;
    // 보여줄 이미지
    public Sprite abilityImage;
    // 능력치 등급
    public AbilityGrade abilityGrade;
    // 뽑을 때 사용 할 가중치 ( 모든 능력이 똑같은 확률로 뽑히는 걸 방지) 
    public int weight;
    
    public Ability(Ability ability)
    {
        this.abilityName = ability.abilityName;
        this.abilityImage = ability.abilityImage;
        this.abilityGrade = ability.abilityGrade;
        this.weight = ability.weight;
    }
}
