using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItem : MonoBehaviour
{
    Player2 player; //체력, speed 이동속도
    BasicWeapon basWea; //shootrate, range (공격속도, 사거리) 
    BasicBullet basBull; //공격력
    Items items;

    Animation animat;

    private void Start()
    {
        player = GetComponent<Player2>();
        basWea = GetComponent<BasicWeapon>();
        basBull = GetComponent<BasicBullet>();
        items = GetComponent<Items>();
    }

    private void Update()
    {
        Attack();
    }

    void Attack()
    {
       if( Input.GetKeyDown("Mouse1") && items.currentItems.Count >= 1)
        {
            Debug.Log("무기공격");
        }


    }
}
