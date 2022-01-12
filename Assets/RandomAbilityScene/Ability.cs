using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityGrade { S, A, B, C }

[System.Serializable]
public class Ability
{
    public string abilityName;
    public Sprite abilityImage;
    public AbilityGrade AbilityGrade;
    public int weight;
    
    public Ability(Ability ability)
    {
        this.abilityName = ability.abilityName;
        this.abilityImage = ability.abilityImage;
        this.AbilityGrade = ability.AbilityGrade;
        this.weight = ability.weight;
    }
}
