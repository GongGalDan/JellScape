using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dog : MonoBehaviour
{
    NavMeshAgent nvAgent;
    GameObject dogDestination;

    // Start is called before the first frame update
    void Start()
    {
        nvAgent = GetComponent<NavMeshAgent>();
        dogDestination = GameObject.Find("DogDestination");
    }

    // Update is called once per frame
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