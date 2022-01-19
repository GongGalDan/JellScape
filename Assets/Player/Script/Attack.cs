using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // 근접무기
    float attackDelay;

    Items items;
    Animator animat;
    Player2 player;

    private void Start()
    {
        items = GetComponent<Items>();
        animat = GetComponent<Animator>();
        player = GetComponent<Player2>();
    }

    void AttackDelay()
    {
        if (attackDelay > 0)
            attackDelay -= Time.deltaTime;
    }

    void Melee()
    {
        if (Input.GetMouseButtonDown(1) && attackDelay < 0)
        {
            if (items.currentItems[0] == items.itemlist[0]) //아폴로 공격처리
            {
                animat.SetTrigger("doAttack");
                attackDelay += player.basicShootRate;
            }

            if (items.currentItems[0] == items.itemlist[1]) //스틱 공격 처리
            {
                animat.SetTrigger("doAttack");
                attackDelay += player.basicShootRate;
            }
            if (items.currentItems[0] == items.itemlist[2])
            {
                animat.SetTrigger("doAttack");
                attackDelay += player.basicShootRate;
            }
            if (items.currentItems[0] == items.itemlist[3])
            {
                animat.SetTrigger("doAttack");
                attackDelay += player.basicShootRate;
            }
        }

    }
}
