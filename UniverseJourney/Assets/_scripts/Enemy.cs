using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;
    private Transform target;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").transform;
    }

    
    void Update()
    {

        navMeshAgent.SetDestination(target.position);
    }
}
