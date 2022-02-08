using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityGrade { S, A, B, C }

[System.Serializable]
public class Ability
{
    // 능력 이름
    public string abilityName;
    // 능력 태그
    public string abilityTag;
    // 보여줄 이미지
    public Sprite abilityImage;
    // 능력치 등급
    public AbilityGrade abilityGrade;
    // 뽑을 때 사용 할 가중치 (모든 능력이 똑같은 확률로 뽑히는 걸 방지) 
    public int weight;
    // 뽑힌 여부 (중복 방지)
    public bool isPicked;
    // 젤리빈 원소 능력 (중복 방지)
    public bool isElement;
    // 한번만 뽑을 수 있는 능력인지
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
