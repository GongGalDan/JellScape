using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSVReader : MonoBehaviour
{
    public TextAsset monsterData;

    [System.Serializable]
    public class Monster
    {
        public string name;
        public float hp;
        public float meleeAttackDamage;
        public float rangedAttackDamage;
        public float attackSpeed;
        public float speed;
        public float meleeAttackRange;
        public float RangedAttackRange;
        public float detectRange;
    }

    [System.Serializable]
    public class MonsterList
    {
        public Monster[] monster;
    }

    public MonsterList myMonsterList = new MonsterList();

    // Start is called before the first frame update
    void Start()
    {
        ReadCSV();
    }

    MonsterList ReadCSV()
    {
        string[] data = monsterData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        int tableSize = data.Length / 11 - 1;
        myMonsterList.monster = new Monster[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            myMonsterList.monster[i] = new Monster();
            myMonsterList.monster[i].name = data[9 * (i + 1)];
            myMonsterList.monster[i].hp = int.Parse(data[9 * (i + 1) + 1]);
            myMonsterList.monster[i].meleeAttackDamage = int.Parse(data[9 * (i + 1) + 2]);
            myMonsterList.monster[i].rangedAttackDamage = int.Parse(data[9 * (i + 1) + 3]);
            myMonsterList.monster[i].attackSpeed = int.Parse(data[9 * (i + 1) + 4]);
            myMonsterList.monster[i].speed = int.Parse(data[9 * (i + 1) + 5]);
            myMonsterList.monster[i].meleeAttackRange = int.Parse(data[9 * (i + 1) + 6]);
            myMonsterList.monster[i].RangedAttackRange = int.Parse(data[9 * (i + 1) + 7]);
            myMonsterList.monster[i].detectRange = int.Parse(data[9 * (i + 1) + 8]);
        }

        return myMonsterList;
    }
}
