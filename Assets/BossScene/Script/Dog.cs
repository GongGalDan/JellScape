using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class Dog : MonoBehaviour
{
    GameManager gm;
    NavMeshAgent nvAgent;
    GameObject dogDestination;
    Transform player;
    Animator animator;
    public UnityEvent onHit;

    bool isStart;
    float currentHeight;
    float previousHeight;
    float heightTimer;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        nvAgent = GetComponent<NavMeshAgent>();
        dogDestination = GameObject.Find("DogDestination");
        player = GameObject.Find("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        StartCoroutine(WaitForCine());

        previousHeight = transform.position.y;
        currentHeight = transform.position.y;
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
        CheckHeightDifference();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Caught by Dog");
            gm.bossSceneLife--;
            onHit.Invoke();
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

    void CheckHeightDifference()
    {
        previousHeight = transform.position.y;

        heightTimer += Time.deltaTime;

        if (heightTimer > 2f)
        {
            currentHeight = transform.position.y;
            heightTimer = 0;
        }

        if (previousHeight < currentHeight)
        {
            animator.SetBool("Land", true);
        }
        else if (previousHeight > currentHeight)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Land", false);
        }    
    }
}