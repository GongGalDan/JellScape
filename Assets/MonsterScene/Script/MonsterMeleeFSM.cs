using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMeleeFSM : MonsterBase
{
    // ���� ����
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

    // �̵� ���
    private Transform path;
    private List<Transform> nodes;
    private int currentNode = 0;

    private Vector3 lastPlayerPos;

    protected override void Start() 
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
        // �������� ���� �� � ������ ������ ���¸� ������ �� ���� �����ؾ���
        // ----------------------------------------------------------------------

        while (true)
        {
            yield return StartCoroutine(currentState.ToString());
        }
    }

    protected virtual IEnumerator Idle()
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

    protected virtual IEnumerator Attack()
    {
        yield return null;
 
        nvAgent.stoppingDistance = 0f;
        lastPlayerPos = player.transform.position;
        nvAgent.SetDestination(lastPlayerPos);
        yield return Delay500;

        nvAgent.isStopped = false;
        nvAgent.speed = 50f;
        canAtk = false;

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetTrigger("Attack");
        }
        // AtkEffect(); �ʿ�� ����
        yield return new WaitForSeconds(1.5f);
        
        nvAgent.speed = monster.speed;
        nvAgent.stoppingDistance = monster.meleeAttackRange;
        currentState = State.Idle;
    }

    protected virtual IEnumerator Move()
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
            nvAgent.stoppingDistance = monster.meleeAttackRange;
            nvAgent.SetDestination(player.transform.position);
        }
    }
    // ��� ��ȸ
    private void MoveAround()
    {
        nvAgent.stoppingDistance = 0f;
        // ������ �Ÿ��� ��������� ���� ����
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

    protected override void Update()
    {
        base.Update();
    }
}