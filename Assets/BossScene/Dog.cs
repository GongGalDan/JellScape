using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dog : MonoBehaviour
{
    NavMeshAgent nvAgent;
    GameObject dogDestination;
    Transform player;
    Animator animator;
    bool isStart;

    void Start()
    {
        nvAgent = GetComponent<NavMeshAgent>();
        dogDestination = GameObject.Find("DogDestination");
        player = GameObject.Find("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        StartCoroutine(WaitForCine());
    }

    void Update()
    {
        if (!isStart) return;

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
            StartCoroutine(Stop());
        }
    }

    IEnumerator WaitForCine()
    {
        yield return null;

        yield return new WaitForSeconds(15f);
        isStart = true;
        animator.SetBool("Run", true);
    }

    IEnumerator Stop()
    {
        yield return null;

        animator.SetTrigger("Idle");
        animator.SetBool("Run", false);
        nvAgent.isStopped = true;

        yield return new WaitForSeconds(3f);

        nvAgent.isStopped = false;
        animator.SetBool("Run", true);
    }
}