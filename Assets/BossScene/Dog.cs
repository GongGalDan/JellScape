using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dog : MonoBehaviour
{
    NavMeshAgent nvAgent;
    GameObject dogDestination;

    void Start()
    {
        nvAgent = GetComponent<NavMeshAgent>();
        dogDestination = GameObject.Find("DogDestination");
    }

    void Update()
    {
        nvAgent.SetDestination(dogDestination.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Caught by Dog");
        }
    }
}