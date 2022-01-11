using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    Dictionary<string, MonsterData.Monster> monstersDic = new Dictionary<string, MonsterData.Monster>();
    MonsterData monsterData;

    // Start is called before the first frame update
    void Start()
    {
        monsterData = GameObject.Find("MonsterData").GetComponent<MonsterData>();

        for (int i = 0; i < monsterData.myMonsterList.monsters.Length; i++)
        {
            monstersDic.Add(monsterData.myMonsterList.monsters[i].name, monsterData.myMonsterList.monsters[i]);
            Debug.Log(monsterData.myMonsterList.monsters[i].name);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetMonstersData()
    {

    }
}