using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slush : MonsterRangedFSM
{
    PlayerData playerData;
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
        playerData = GameObject.Find("GameManager").GetComponent<PlayerData>();
        base.Start();
        hp = monster.hp;
        speed = monster.speed;
        SetRangedAtkArea();
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
            if (playerData.isElementPicked == true)
            {
                StartCoroutine("ElementJelly");
            }

            if (playerData.headShot == true)
            {
                int headShotRandom = Random.Range(0, 101);
                if (headShotRandom < 3)
                {
                    hp -= 1000;
                    Debug.Log("��� ��");
                }
            }

            int criticalRandom = Random.Range(0, 101);
            if (criticalRandom < playerStats.critical)
            {
                hp -= playerStats.damage * 2;
                Debug.Log("ũ��Ƽ�� ������");
            }
            else
            {
                hp -= playerStats.damage;
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
            playerStats.hp -= monster.meleeAttackDamage * 100 / (100 + playerStats.defence);
            Debug.Log(playerStats.hp + "���Ϳ��� ����");
        }
    }

    IEnumerator ElementJelly()
    {
        if (playerData.hotJelly == true)
        {
            hp -= 5;
            yield return new WaitForSeconds(1f);
            hp -= 5;
            yield return new WaitForSeconds(1f);
            hp -= 5;

        }

        if (playerData.frozenJelly == true)
        {
            speed *= 0.5f;
        }

        if (playerData.poisonJelly == true)
        {
            hp -= 10;
            yield return new WaitForSeconds(3f);
            hp -= 10;
        }

        if (playerData.sparkJelly == true)
        {
            //��� ������ = 10�� 2���� �߰� ���� 
        }

        if (playerData.bombJelly == true)
        {
            RaycastHit[] rayHits = Physics.SphereCastAll
                (transform.position, 10, Vector3.up, 0, LayerMask.GetMask("Monster"));

            foreach (RaycastHit hitMonster in rayHits)
            {
                hitMonster.transform.GetComponent<MonsterBase>().hp -= 20;
                Debug.Log("��ź");
            }
        }
    }

    // ���� ���� ����
    void SetRangedAtkArea()
    {
        gameObject.transform.GetComponentInChildren<SphereCollider>().radius = monster.meleeAttackRange;
    }
}
