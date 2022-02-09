using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float currentHp;
    public float MaxHp;

    Player player;
    UsableItem useItem;

    MeshRenderer mesh;
    Material material;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        useItem = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<UsableItem>();

        mesh = GetComponent<MeshRenderer>();
        material = mesh.material;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Bullet"))
        {
            int criticalRandom = Random.Range(0, 101);
            if (criticalRandom < player.currentCritical)
            {
                currentHp -= player.currentDamage * 2;
                Debug.Log("ũ��Ƽ�� ������");
            }
            else
            {
                currentHp -= player.currentDamage;
                Debug.Log("�Ϲ� ������");
            }
            Destroy(other.gameObject); //�浹 �ϸ� bullet�� ���������
            Debug.Log(currentHp + "bullet���� ����");
        }

        if (other.CompareTag("Apolo"))
        {
            currentHp -= useItem.Damage; //�������� ������
            Debug.Log(currentHp + "�����ο��� ����");
            material.color = new Color(0,100,0);
        }

        if (other.CompareTag("Stick"))
        {
            currentHp -= useItem.Damage; //��ƽ�� ������
            Debug.Log(currentHp + "��ƽ���� ����");
            material.color = new Color(100, 100, 0);
        }


        if(currentHp <= 0)
        {
            gameObject.layer = 11;
            Destroy(gameObject, 0.3f);
        }
    }
}
