using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterBase : MonoBehaviour
{
    // 몬스터 정보
    MonsterData monsterData;
    // 몬스터 타입 지정
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
    public float hp;
    protected float speed;
    [SerializeField]
    protected bool canAtk;
    protected float attackCoolTimeCalc;

    protected GameObject player;
    protected Player playerStats;
    protected UsableItem useItem;
    protected NavMeshAgent nvAgent;
    protected float distance;

    protected Animator animator;
    protected Rigidbody rigidBody;

    public LayerMask layerMask;

    virtual protected void Start()
    {
        monsterData = GameObject.Find("GameManager").GetComponent<MonsterData>();
        SetMonsterData();
        player = GameObject.FindGameObjectWithTag("Player");

        playerStats = player.GetComponent<Player>();
        

        nvAgent = GetComponent<NavMeshAgent>();
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        canAtk = true;
        attackCoolTimeCalc = monster.attackCoolTime;

        StartCoroutine(CalcCoolTime());

        Debug.Log(monster.hp);
    }

    // 몬스터 정보 세팅 
    private void SetMonsterData()
    {
        // 몬스터 정보를 가져와서 현재 Type과 같은 이름의 몬스터 정보를 저장
        foreach (Monster values in monsterData.monstersDic.Values)
        {
            if (type.ToString() == values.name)
            {
                monster = values;
            }
        }
    }

    // 공격 가능 범위 감지
    protected bool CanAtkStateFun()
    {
        // 타겟 방향 설정
        Vector3 targetDir = new Vector3(player.transform.position.x - transform.position.x, 0f, player.transform.position.z - transform.position.z);

        // 타겟을 향해 광선 발사
        Physics.Raycast(new Vector3(transform.position.x, 0.5f, transform.position.z), targetDir, out RaycastHit hit, 30f, layerMask);
        Debug.DrawRay(new Vector3(transform.position.x, 0.5f, transform.position.z), targetDir, Color.green);

        // 타겟과의 거리
        distance = Vector3.Distance(player.transform.position, transform.position);

        // 타겟이 없다면
        if (hit.transform == null)
        {
            return false;
        }
        // 타겟이 Player이고 공격 범위 안에 있다면
        if (hit.transform.CompareTag("Player") && (distance <= monster.meleeAttackRange || distance <= monster.rangedAttackRange))
        {
            return true;
        }
        else if (transform.position == player.transform.position)
        { 
            return true;
        }
        else return false;
    }

    // 공격 쿨타임
    protected virtual IEnumerator CalcCoolTime()
    {
        while (true)
        {
            yield return null;
            // 공격이 쿨타임이라면
            if (!canAtk)
            {
                attackCoolTimeCalc -= Time.deltaTime;
                // 쿨타임이 끝나면
                if (attackCoolTimeCalc <= 0)
                {
                    attackCoolTimeCalc = monster.attackCoolTime;
                    canAtk = true;
                }
            }
        }
    }

    protected virtual void Update() { }
}
