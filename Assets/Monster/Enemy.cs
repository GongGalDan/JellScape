using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform path;
    private List<Transform> nodes;
    private int currentNode = 0;

    void Start()
    {
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();
        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        MoveAround();
    }

    private void MoveAround()
    {
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
            agent.destination = nodes[currentNode].position;
    }
}
