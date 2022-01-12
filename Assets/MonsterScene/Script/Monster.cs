using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
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
}
