using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItem : MonoBehaviour
{
    Player2 player; //체력, speed 이동속도
    BasicWeapon basWea; //shootrate, range (공격속도, 사거리) 
    BasicBullet basBull; //공격력
    Items items;
    ItemInfo itemifo;

    Animator animat;

    private void Start()
    {
        player = GetComponent<Player2>();
        basWea = GetComponent<BasicWeapon>();
        basBull = GetComponent<BasicBullet>();
        items = GetComponent<Items>();
        itemifo = GetComponent<ItemInfo>();
        animat = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(1) && items.currentItems.Count == 0)
        {
            Debug.Log("획득한 아이템이 없습니다.");
            return;
        }
        if(Input.GetMouseButtonDown(1) && items.currentItems.Count != 0)
        {
           if(items.currentItems[0] == items.itemlist[0])
            {
                Debug.Log("아폴로로 공격 중");
                animat.SetTrigger("doAttack");
            }

            if (items.currentItems[0] == items.itemlist[1])
            {
                Debug.Log("스틱으로 공격 중");
                animat.SetTrigger("doAttack");
            }

            if (items.currentItems[0] == items.itemlist[2])
            {
                Debug.Log("캡슐로 공격 중");
            }

            if (items.currentItems[0] == items.itemlist[3])
            {
                Debug.Log("얼음 갑옷으로 방어 중");
                animat.SetTrigger("doAttack");
            }

            
            //Invoke(Attack, 0.3f);
        }

    }
}
