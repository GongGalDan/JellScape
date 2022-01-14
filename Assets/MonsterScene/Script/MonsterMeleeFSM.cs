using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMeleeFSM : MonsterBase
{
    // 상태 정의
    public enum State
    {
        Idle,
        Move,
        Attack
    };
    [SerializeField]
    public State currentState = State.Idle;

    WaitForSeconds Delay500 = new WaitForSeconds(0.5f);
    WaitForSeconds Delay250 = new WaitForSeconds(0.25f);

    // 이동 경로
    private Transform path;
    private List<Transform> nodes;
    private int currentNode = 0;

    bool isDetected;

    override protected void Start() 
    {
        base.Start();
        path = transform.parent.GetChild(1).GetComponent<Transform>();
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();
        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
        nvAgent = GetComponent<NavMeshAgent>();
        nvAgent.stoppingDistance = monster.meleeAttackRange;

        StartCoroutine(FSM());
    }

    protected virtual IEnumerator FSM()
    {
        yield return null;

        // ----------------------------------------------------------------------
        // 스테이지 제작 후 어떤 식으로 몬스터의 상태를 시작할 것 인지 결정해야함
        // ----------------------------------------------------------------------

        while (true)
        {
            yield return StartCoroutine(currentState.ToString());
        }
    }

    virtual protected IEnumerator Idle()
    {
        yield return null;

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            animator.SetTrigger("Idle");
        }

        if (CanAtkStateFun())
        {
            if (canAtk)
            {
                currentState = State.Attack;
            }
            else
            {
                currentState = State.Idle;
                transform.LookAt(player.transform.position);
            }
        }
        else
        {
            currentState = State.Move;
        }
    }

    virtual protected IEnumerator Attack()
    {
        yield return null;

        nvAgent.stoppingDistance = 0f;
        nvAgent.isStopped = true;
        nvAgent.SetDestination(player.transform.position);
        yield return Delay500;

        nvAgent.isStopped = false;
        nvAgent.speed = 30f;
        canAtk = false;

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetTrigger("Attack");
        }
        // AtkEffect(); 필요시 구현
        yield return Delay500;

        nvAgent.speed = monster.speed;
        nvAgent.stoppingDistance = monster.meleeAttackRange;
        currentState = State.Idle;
    }

    virtual protected IEnumerator Move()
    {
        yield return null;

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Move"))
        {
            animator.SetTrigger("Move");
        }
        if (CanAtkStateFun() && canAtk)
        {
            currentState = State.Attack;
        }
        else if (distance > monster.detectRange)
        {
            //MoveAround();
        }
        else
        {
            nvAgent.SetDestination(player.transform.position);
        }
    }
    // 경로 순회
    private void MoveAround()
    {
        // 노드와의 거리가 가까워지면 다음 노드로
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 0.5f)
        {
            if ((currentNode + 1) % nodes.Count == 0)
            {
                currentNode = 0;
            }
            else
                currentNode++;
        }
        nvAgent.SetDestination(nodes[currentNode].position);
    }

    override protected void Update()
    {
        base.Update();
    }
}
