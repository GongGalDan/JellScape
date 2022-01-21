using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterData : MonoBehaviour
{
    public TextAsset monsterData;
    public Dictionary<string, Monster> monstersDic = new Dictionary<string, Monster>();

    public class MonsterList
    {
        public Monster[] monsters;
    }

    public MonsterList myMonsterList = new MonsterList();

    void Awake()
    {
        ReadCSV();
        SetMonstersDic();
    }
    public void ReadCSV()
    {
        string[] data = monsterData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        int tableSize = data.Length / 9 - 1;
        myMonsterList.monsters = new Monster[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            myMonsterList.monsters[i] = new Monster();
            myMonsterList.monsters[i].name = data[9 * (i + 1)];
            myMonsterList.monsters[i].hp = int.Parse(data[9 * (i + 1) + 1]);
            myMonsterList.monsters[i].meleeAttackDamage = int.Parse(data[9 * (i + 1) + 2]);
            myMonsterList.monsters[i].rangedAttackDamage = int.Parse(data[9 * (i + 1) + 3]);
            myMonsterList.monsters[i].attackCoolTime = int.Parse(data[9 * (i + 1) + 4]);
            myMonsterList.monsters[i].speed = int.Parse(data[9 * (i + 1) + 5]);
            myMonsterList.monsters[i].meleeAttackRange = int.Parse(data[9 * (i + 1) + 6]);
            myMonsterList.monsters[i].rangedAttackRange = int.Parse(data[9 * (i + 1) + 7]);
            myMonsterList.monsters[i].detectRange = int.Parse(data[9 * (i + 1) + 8]);
        }
    }

    public void SetMonstersDic()
    {
        for (int i = 0; i < myMonsterList.monsters.Length; i++)
        {
            monstersDic.Add(myMonsterList.monsters[i].name, myMonsterList.monsters[i]);
        }
    }
}
