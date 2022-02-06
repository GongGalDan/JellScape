using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slush : MonsterRangedFSM
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
        Gizmos.DrawWireSphere(transform.position, monster.rangedAttackRange);
    }

    override protected void Start()
    {
        base.Start();
        SetRangedAtkArea();
    }

    override protected void Update()
    {
        base.Update();
        if (monster.hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    // -------------------------------------------------
    // ���� HP�� �÷��̾�� ������ �Դ� ��� ���� �ʿ� 
    // -------------------------------------------------
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            monster.hp -= playerStats.currentDamage;
            Debug.Log(monster.hp);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Apolo"))
        { // ��ũ��Ʈ�� gameobject���� ã�Ƽ� �����Ѵ�.
            useItem = GameObject.FindGameObjectWithTag("Apolo").GetComponent<UsableItem>();
            monster.hp -= useItem.Damage; //�������� ������
            Debug.Log(monster.hp + "�����ο��� ����");
            //material.color = new Color(0, 100, 0);
        }

        if (other.CompareTag("Stick"))
        {
            useItem = GameObject.FindGameObjectWithTag("Stick").GetComponent<UsableItem>();
            monster.hp -= useItem.Damage; //��ƽ�� ������
            Debug.Log(monster.hp + "��ƽ���� ����");
            //material.color = new Color(100, 100, 0);
        }
    }
    // ���� ���� ����
    void SetRangedAtkArea()
    {
        gameObject.transform.GetComponentInChildren<SphereCollider>().radius = monster.meleeAttackRange;
    }
}
