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
    }

    override protected void Update()
    {
        base.Update();
    }

    // -------------------------------------------------
    // ���� HP�� �÷��̾�� ������ �Դ� ��� ���� �ʿ� 
    // -------------------------------------------------

    // ���� ���� ����
    void SetMeleeAtkArea()
    {
        gameObject.transform.GetComponentInChildren<SphereCollider>().radius = monster.meleeAttackRange;
    }
}
