using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cat : MonoBehaviour
{
    NavMeshAgent nvAgent;
    Transform catDestination;
    Transform player;

    void Start()
    {
        nvAgent = GetComponent<NavMeshAgent>();
        catDestination = GameObject.Find("CatDestination").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < 6f)
        {
            nvAgent.SetDestination(player.position);
        }
        else
        {
            nvAgent.SetDestination(catDestination.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Caught by Cat");
        }
    }
}