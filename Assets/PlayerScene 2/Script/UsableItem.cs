using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItem : MonoBehaviour
{
    Player2 player; //ü��, speed �̵��ӵ�
    BasicWeapon basWea; //shootrate, range (���ݼӵ�, ��Ÿ�) 
    BasicBullet basBull; //���ݷ�
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
            Debug.Log("�������");
        }


    }
}
