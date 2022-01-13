using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterBase : MonoBehaviour
{
    MonsterData monsterData;

    public enum MonsterType
    {
        Dalgona,
        Jjondeugi,
        ChocoPie,
        Icecream,
        Slush,
        FishIcecream,
        FigureMuchine,
        FigureCapsule,
        MinicarFigure,
        AnimalFigure,
        RobotFigure
    };
    public MonsterType type;

    protected Monster monster;
    protected bool canAtk;
    protected float attackCoolTimeCalc;

    protected GameObject player;
    protected NavMeshAgent nvAgent;
    protected float distance;

    protected Animator animator;
    protected Rigidbody rigidBody;

    public LayerMask layerMask;

    protected void Start()
    {
        monsterData = GameObject.Find("MonsterData").GetComponent<MonsterData>();
        SetMonsterData();
        player = GameObject.FindGameObjectWithTag("Player");

        nvAgent = GetComponent<NavMeshAgent>();
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        canAtk = true;
        attackCoolTimeCalc = monster.attackCoolTime;

        StartCoroutine(CalcCoolTime());

        Debug.Log(monster.name);
        Debug.Log(monster.hp);
        Debug.Log(monster.meleeAttackDamage);
        Debug.Log(monster.rangedAttackDamage);
        Debug.Log(monster.attackCoolTime);
        Debug.Log(monster.speed);
        Debug.Log(monster.meleeAttackRange);
        Debug.Log(monster.rangedAttackRange);
        Debug.Log(monster.detectRange);
    }

    private void SetMonsterData()
    {
        foreach (Monster values in monsterData.monstersDic.Values)
        {
            if (type.ToString() == values.name)
            {
                monster = values;
            }
        }
    }

    protected bool CanAtkStateFun()
    {
        Vector3 targetDir = new Vector3(player.transform.position.x - transform.position.x, 0f, player.transform.position.z - transform.position.z);

        Physics.Raycast(new Vector3(transform.position.x, 0.5f, transform.position.z), targetDir, out RaycastHit hit, 30f, layerMask);
        distance = Vector3.Distance(player.transform.position, transform.position);

        if (hit.transform == null)
        {
            Debug.Log("hit.transform == null");
            return false;
        }

        if (hit.transform.CompareTag("Player") && (distance <= monster.meleeAttackRange || distance <= monster.rangedAttackRange))
        {
            return true;
        }
        else return false;
    }

    protected virtual IEnumerator CalcCoolTime()
    {
        while (true)
        {
            yield return null;
            if (!canAtk)
            {
                attackCoolTimeCalc -= Time.deltaTime;
                Debug.Log(attackCoolTimeCalc);
                if (attackCoolTimeCalc <= 0)
                {
                    attackCoolTimeCalc = monster.attackCoolTime;
                    canAtk = true;
                }
            }
        }
    }
}
