using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalFigure : MonsterMeleeFSM
{
    public GameObject enemyCanvasGo;
    public GameObject meleeAtkArea;

    Player playerStats;
    UsableItem useItem;
    MeshRenderer mesh;
    Material material;

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
        SetMeleeAtkArea();
        playerStats = player.GetComponent<Player>();

        //mesh = GetComponent<MeshRenderer>();
        //material = mesh.material;
    }

    override protected void Update()
    {
        base.Update();
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


        if (monster.hp <= 0)
        {
            //gameObject.layer = 11;
            Destroy(gameObject, 0.3f);
        }
    }

    // ���� ���� ����
    void SetMeleeAtkArea()
    {
        gameObject.transform.GetComponentInChildren<SphereCollider>().radius = monster.meleeAttackRange;
    }
}
