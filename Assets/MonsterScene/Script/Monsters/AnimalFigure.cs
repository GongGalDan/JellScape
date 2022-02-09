using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalFigure : MonsterMeleeFSM
{
    public GameObject enemyCanvasGo;
    public GameObject meleeAtkArea;


    private void OnDrawGizmosSelected()
    {
        if (monster == null) return;

        Gizmos.color = Color.yellow;
        // �ν� ���� ǥ��
        Gizmos.DrawWireSphere(transform.position, monster.detectRange);
        Gizmos.color = Color.red;
        // ���� ���� ǥ��
        Gizmos.DrawWireSphere(transform.position, monster.meleeAttackRange);
    }

    override protected void Start()
    {
        base.Start();
        hp = monster.hp;
        SetMeleeAtkArea();
    
    }

    override protected void Update()
    {
        base.Update();

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // -------------------------------------------------
    // ���� HP�� �÷��̾�� ������ �Դ� ��� ���� �ʿ� 
    // -------------------------------------------------

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Bullet"))
        {
            int criticalRandom = Random.Range(0, 101);
            if(criticalRandom < playerStats.currentCritical)
            {
                hp -= playerStats.currentDamage * 2;
                Debug.Log("ũ��Ƽ�� ������");
            }
            else
            {
                hp -= playerStats.currentDamage;
                Debug.Log("�Ϲ� ������");
            }
            Destroy(other.gameObject); //�浹 �ϸ� bullet�� ���������
            Debug.Log(hp + "bullet���� ����");

        }

        if (other.CompareTag("Apolo"))
        { // ��ũ��Ʈ�� gameobject���� ã�Ƽ� �����Ѵ�.
            useItem = GameObject.FindGameObjectWithTag("Apolo").GetComponent<UsableItem>();
            hp -= useItem.Damage;
            Debug.Log(hp + "apolo���� ����");
        }

        if (other.CompareTag("Stick"))
        {
            useItem = GameObject.FindGameObjectWithTag("Stick").GetComponent<UsableItem>();
            hp -= useItem.Damage;
            Debug.Log(hp + " stick���� ����");
        }


        if (other.CompareTag("Player"))
         {
           playerStats.currentHp -= monster.meleeAttackDamage * 100/(100 + playerStats.currentDefence);
           Debug.Log(playerStats.currentHp + "���Ϳ��� ����");
         }
    }


    // ���� ���� ����
    void SetMeleeAtkArea()
    {
        gameObject.transform.GetComponentInChildren<SphereCollider>().radius = monster.meleeAttackRange;
    }
}
