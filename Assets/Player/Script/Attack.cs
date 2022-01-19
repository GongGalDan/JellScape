using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // ��������
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
            if (items.currentItems[0] == items.itemlist[0]) //������ ����ó��
            {
                animat.SetTrigger("doAttack");
                attackDelay += player.basicShootRate;
            }

            if (items.currentItems[0] == items.itemlist[1]) //��ƽ ���� ó��
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
