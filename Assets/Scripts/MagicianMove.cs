using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MagicianMove : MonoBehaviour
{

    [SerializeField] NavMeshAgent navAgent;
    [SerializeField] Animator animator;
    [SerializeField] Transform[] enemys;
    [SerializeField] int seeDistanse;
    [SerializeField] float attackDistance;
    [SerializeField] HpSystemEnemy[] hpSystemsEnemy;
    private Vector3 startPosition;
    int i, min = 0;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
