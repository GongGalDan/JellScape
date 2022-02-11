using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rat : MonoBehaviour
{
    NavMeshAgent nvAgent;
    GameObject player;
    Animator animator;
    bool isStart;

    void Start()
    {
        nvAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        StartCoroutine(WaitForCine());
    }

    void Update()
    {
        if (!isStart) return;

        nvAgent.SetDestination(player.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Caught by Rat");
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