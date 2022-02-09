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
        // 인식 범위 표시
        Gizmos.DrawWireSphere(transform.position, monster.detectRange);
        Gizmos.color = Color.red;
        // 공격 범위 표시
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
    // 몬스터 HP와 플레이어와 데미지 입는 방식 구현 필요 
    // -------------------------------------------------

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Bullet"))
        {
            int criticalRandom = Random.Range(0, 101);
            if(criticalRandom < playerStats.currentCritical)
            {
                hp -= playerStats.currentDamage * 2;
                Debug.Log("크리티컬 데미지");
            }
            else
            {
                hp -= playerStats.currentDamage;
                Debug.Log("일반 데미지");
            }
            Destroy(other.gameObject); //충돌 하면 bullet이 사라지도록
            Debug.Log(hp + "bullet에게 맞음");

        }

        if (other.CompareTag("Apolo"))
        { // 스크립트를 gameobject에서 찾아서 참조한다.
            useItem = GameObject.FindGameObjectWithTag("Apolo").GetComponent<UsableItem>();
            hp -= useItem.Damage;
            Debug.Log(hp + "apolo에게 맞음");
        }

        if (other.CompareTag("Stick"))
        {
            useItem = GameObject.FindGameObjectWithTag("Stick").GetComponent<UsableItem>();
            hp -= useItem.Damage;
            Debug.Log(hp + " stick에게 맞음");
        }


        if (other.CompareTag("Player"))
         {
           playerStats.currentHp -= monster.meleeAttackDamage * 100/(100 + playerStats.currentDefence);
           Debug.Log(playerStats.currentHp + "몬스터에게 맞음");
         }
    }


    // 공격 범위 설정
    void SetMeleeAtkArea()
    {
        gameObject.transform.GetComponentInChildren<SphereCollider>().radius = monster.meleeAttackRange;
    }
}
