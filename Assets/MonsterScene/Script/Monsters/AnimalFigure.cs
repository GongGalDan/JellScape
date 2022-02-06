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
            hp -= playerStats.currentDamage;
            Debug.Log(hp);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Apolo"))
        { // 스크립트를 gameobject에서 찾아서 참조한다.
            useItem = GameObject.FindGameObjectWithTag("Apolo").GetComponent<UsableItem>();
            hp -= useItem.Damage; //아폴로의 데미지
            Debug.Log(hp + "아폴로에게 맞음");
        }

        if (other.CompareTag("Stick"))
        {
            useItem = GameObject.FindGameObjectWithTag("Stick").GetComponent<UsableItem>();
            hp -= useItem.Damage; //스틱의 데미지
            Debug.Log(hp + "스틱에게 맞음");
        }
    }

    // 공격 범위 설정
    void SetMeleeAtkArea()
    {
        gameObject.transform.GetComponentInChildren<SphereCollider>().radius = monster.meleeAttackRange;
    }
}