using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItem : MonoBehaviour
{
    float attackDelay;

    Player2 player; //ü��, speed �̵��ӵ�
    Items items;
    Animator animat;


    private void Start()
    {
        player = GetComponent<Player2>();
        items = GetComponent<Items>();
        animat = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Use();
    }

    void Use()
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
                animat.SetTrigger("doAttack");
            }

            if (items.currentItems[0] == items.itemlist[3])
            {
                Debug.Log("���� �������� ��� ��");
            }
        }

    }
}
