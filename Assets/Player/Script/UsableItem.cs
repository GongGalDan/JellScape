using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItem : MonoBehaviour
{
    Player2 player; //ü��, speed �̵��ӵ�
    BasicWeapon basWea; //shootrate, range (���ݼӵ�, ��Ÿ�) 
    BasicBullet basBull; //���ݷ�
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
            Debug.Log("ȹ���� �������� �����ϴ�.");
            return;
        }
        if(Input.GetMouseButtonDown(1) && items.currentItems.Count != 0)
        {
           if(items.currentItems[0] == items.itemlist[0])
            {
                Debug.Log("�����η� ���� ��");
                animat.SetTrigger("doAttack");
            }

            if (items.currentItems[0] == items.itemlist[1])
            {
                Debug.Log("��ƽ���� ���� ��");
                animat.SetTrigger("doAttack");
            }

            if (items.currentItems[0] == items.itemlist[2])
            {
                Debug.Log("ĸ���� ���� ��");
            }

            if (items.currentItems[0] == items.itemlist[3])
            {
                Debug.Log("���� �������� ��� ��");
                animat.SetTrigger("doAttack");
            }

            
            //Invoke(Attack, 0.3f);
        }

    }
}
