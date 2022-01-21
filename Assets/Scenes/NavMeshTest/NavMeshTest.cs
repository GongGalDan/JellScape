using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshTest : MonoBehaviour
{
    NavMeshAgent nvAgent;
    public GameObject target;
    void Start()
    {
        nvAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        nvAgent.SetDestination(target.transform.position);
    }
}
