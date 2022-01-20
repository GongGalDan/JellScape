using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float currentHp;
    public float MaxHp;

    Player2 player;
    Attack equipWeapon;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2>();
        equipWeapon = GetComponent<Attack>();
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
            currentHp -= equipWeapon.damage; //�������� ������
            Debug.Log(currentHp + "�����ο��� ����");
        }

        if (other.CompareTag("Stick"))
        {
            currentHp -= equipWeapon.damage; //��ƽ�� ������
            Debug.Log(currentHp + "��ƽ���� ����");
        }


        if(currentHp <= 0)
        {
            Destroy(gameObject, 0.3f);
        }
    }
}
