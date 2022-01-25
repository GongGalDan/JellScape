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
    }

    // -------------------------------------------------
    // ���� HP�� �÷��̾�� ������ �Դ� ��� ���� �ʿ� 
    // -------------------------------------------------

    // ���� ���� ����
    void SetRangedAtkArea()
    {
        gameObject.transform.GetComponentInChildren<SphereCollider>().radius = monster.meleeAttackRange;
    }
}
