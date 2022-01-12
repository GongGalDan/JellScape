using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IAttack
{
    public enum MonsterType
    {
        Dalgona,
        Jjondeugi,
        ChocoPie,
        Icecream,
        Slush,
        FishIcecream,
        FigureMuchine,
        FigureCapsule,
        MinicarFigure,
        AnimalFigure,
        RobotFigure
    };
    public MonsterType type;

    [SerializeField]
    MonsterData.Monster monster;

    MonsterData monsterData;

    // Start is called before the first frame update
    void Start()
    {
        monsterData = GameObject.Find("MonsterData").GetComponent<MonsterData>();
        SetMonsterData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetMonsterData()
    {
        foreach (MonsterData.Monster values in monsterData.monstersDic.Values)
        {
            if (type.ToString() == values.name)
            {
                monster = values;
            }
        }
    }
    
    public void Attack()
    {
        switch (type)
        {
            case MonsterType.Dalgona:
                break;
            case MonsterType.Jjondeugi:
                break;
            case MonsterType.ChocoPie:
                break;
            case MonsterType.Icecream:
                break;
            case MonsterType.Slush:
                break;
            case MonsterType.FishIcecream:
                break;
            case MonsterType.FigureMuchine:
                break;
            case MonsterType.FigureCapsule:
                break;
            case MonsterType.MinicarFigure:
                break;
            case MonsterType.AnimalFigure:
                break;
            case MonsterType.RobotFigure:
                break;
            default:
                break;
        }
    }
}
