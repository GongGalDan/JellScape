using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dog : MonoBehaviour
{
    NavMeshAgent nvAgent;
    GameObject dogDestination;
    Transform player;

    void Start()
    {
        nvAgent = GetComponent<NavMeshAgent>();
        dogDestination = GameObject.Find("DogDestination");
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < 6f) 
        {
            nvAgent.SetDestination(player.position);
        }
        else
        {
            nvAgent.SetDestination(dogDestination.transform.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Caught by Dog");
        }
    }
}