using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float currentHp;
    public float MaxHp;

    Player2 player;
    UsableItem useItem;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2>();
        useItem = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<UsableItem>();


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            currentHp -= player.currentDamage;
            Debug.Log(currentHp);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Apolo"))
        {
            currentHp -= useItem.apoloDamage; //�������� ������
            Debug.Log(currentHp + "�����ο��� ����");
        }

        if (other.CompareTag("Stick"))
        {
            currentHp -= useItem.stickDamage; //��ƽ�� ������
            Debug.Log(currentHp + "��ƽ���� ����");
        }


        if(currentHp <= 0)
        {
            //���� ����ϵ��� �����ϴ°� ����
            Destroy(gameObject, 0.3f);
        }
    }
}
