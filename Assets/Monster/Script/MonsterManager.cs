using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    
    MonsterData monsterData;

    // Start is called before the first frame update
    void Start()
    {
        monsterData = GameObject.Find("MonsterData").GetComponent<MonsterData>();

        
    }

    // Update is called once per frame
    void Update()
    {

    }

}