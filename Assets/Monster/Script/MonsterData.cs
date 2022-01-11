using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterData : MonoBehaviour
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
        public Monster[] monsters;
    }

    public MonsterList myMonsterList = new MonsterList();

    // Start is called before the first frame update
    void Start()
    {
        ReadCSV();
    }
    public MonsterList ReadCSV()
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
            myMonsterList.monsters[i].attackSpeed = int.Parse(data[9 * (i + 1) + 4]);
            myMonsterList.monsters[i].speed = int.Parse(data[9 * (i + 1) + 5]);
            myMonsterList.monsters[i].meleeAttackRange = int.Parse(data[9 * (i + 1) + 6]);
            myMonsterList.monsters[i].RangedAttackRange = int.Parse(data[9 * (i + 1) + 7]);
            myMonsterList.monsters[i].detectRange = int.Parse(data[9 * (i + 1) + 8]);
        }

        return myMonsterList;
    }
}
