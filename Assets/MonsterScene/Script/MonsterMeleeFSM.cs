using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMeleeFSM : MonsterBase
{
    private Transform path;
    private List<Transform> nodes;
    private int currentNode = 0;
    bool isDetected;
    Transform target;
  
    void Start() 
    {
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
        target = GameObject.Find("Player").GetComponent<Transform>();

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

    protected void Update()
    {
        MoveAround();
    }

    private void MoveAround()
    {
        if (isDetected) return;
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 0.5f)
        {
            if (currentNode == nodes.Count - 1)
            {
                currentNode = 0;
            }
            else
            {
                currentNode++;
            }
        }
        nvAgent.destination = nodes[currentNode].position;
    }
}
