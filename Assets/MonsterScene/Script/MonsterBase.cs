using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterBase : MonoBehaviour
{
    // ���� ����
    MonsterData monsterData;
    // ���� Ÿ�� ����
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

    // ���� ���� ���� 
    private void SetMonsterData()
    {
        // ���� ������ �����ͼ� ���� Type�� ���� �̸��� ���� ������ ����
        foreach (Monster values in monsterData.monstersDic.Values)
        {
            if (type.ToString() == values.name)
            {
                monster = values;
            }
        }
    }

    // ���� ���� ���� ����
    protected bool CanAtkStateFun()
    {
        // Ÿ�� ���� ����
        Vector3 targetDir = new Vector3(player.transform.position.x - transform.position.x, 0f, player.transform.position.z - transform.position.z);

        // Ÿ���� ���� ���� �߻�
        Physics.Raycast(new Vector3(transform.position.x, 0.5f, transform.position.z), targetDir, out RaycastHit hit, 30f, layerMask);
        Debug.DrawRay(new Vector3(transform.position.x, 0.5f, transform.position.z), targetDir, Color.green);

        // Ÿ�ٰ��� �Ÿ�
        distance = Vector3.Distance(player.transform.position, transform.position);

        // Ÿ���� ���ٸ�
        if (hit.transform == null)
        {
            return false;
        }
        // Ÿ���� Player�̰� ���� ���� �ȿ� �ִٸ�
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

    // ���� ��Ÿ��
    protected virtual IEnumerator CalcCoolTime()
    {
        while (true)
        {
            yield return null;
            // ������ ��Ÿ���̶��
            if (!canAtk)
            {
                attackCoolTimeCalc -= Time.deltaTime;
                // ��Ÿ���� ������
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
