using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JjonDeuGi : MonsterMeleeFSM
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
        SetMeleeAtkArea();
    }

    override protected void Update()
    {
        base.Update();
    }

    // -------------------------------------------------
    // 몬스터 HP와 플레이어와 데미지 입는 방식 구현 필요 
    // -------------------------------------------------

    // 공격 범위 설정
    void SetMeleeAtkArea()
    {
        gameObject.transform.GetComponentInChildren<SphereCollider>().radius = monster.meleeAttackRange;
    }
}
