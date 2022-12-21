using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class enemy_move : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    Vector3 targetPlayer;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        targetPlayer = GameObject.FindWithTag("Player").transform.position;
        EnemyMovement();
    }

    void EnemyMovement()
    {
       if(Vector3.Distance(transform.position,targetPlayer)>=_navMeshAgent.stoppingDistance)
        {
            _navMeshAgent.SetDestination(targetPlayer);
            animator.SetFloat("Speed", 0.2f);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
       
    }
}
