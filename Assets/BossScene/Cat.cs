using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cat : MonoBehaviour
{
    NavMeshAgent nvAgent;
    Transform catDestination;
    Transform player;
    Animator animator;
    bool isStart;

    void Start()
    {
        nvAgent = GetComponent<NavMeshAgent>();
        catDestination = GameObject.Find("CatDestination").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
            nvAgent.SetDestination(catDestination.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Caught by Cat");
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