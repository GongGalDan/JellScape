using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterRangedFSM : MonsterBase
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

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletSocket;
    [SerializeField]
    private int bulletsNum;

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
        nvAgent.stoppingDistance = monster.rangedAttackRange;

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

        yield return Delay250;

        for (int i = 0; i < bulletsNum; i++)
        {
            transform.LookAt(player.transform.position);

            Instantiate(bulletPrefab, bulletSocket.position, bulletSocket.rotation);

            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                animator.SetTrigger("Attack");
            }

            yield return new WaitForSeconds(0.2f);
        }

        nvAgent.speed = monster.speed;
        canAtk = false;

        // AtkEffect(); 필요시 구현
        yield return new WaitForSeconds(0.2f);

        nvAgent.isStopped = false;

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
            transform.LookAt(player.transform.position);
            nvAgent.isStopped = true;
            nvAgent.velocity = Vector3.zero;
            currentState = State.Attack;
        }
        if (distance > monster.detectRange)
        {
            MoveAround();
        }
        else if (distance < monster.detectRange)
        {
            nvAgent.stoppingDistance = monster.rangedAttackRange;
            nvAgent.SetDestination(player.transform.position);
        }
    }
    // 경로 순회
    private void MoveAround()
    {
        nvAgent.stoppingDistance = 0f;
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