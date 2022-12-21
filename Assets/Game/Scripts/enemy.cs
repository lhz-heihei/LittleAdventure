using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;
using static player;

public class enemy : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    Vector3 targetPlayer;
    private Animator animator;
    public enum CharacterState
    {
        Normal,
        Attacking,
    }
    public CharacterState currentState;
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (currentState)
        {
            case CharacterState.Normal:
                EnemyMovement();
                break;
            case CharacterState.Attacking:
                
                break;
        }
        
    }

    void EnemyMovement()
    {
        targetPlayer = GameObject.FindWithTag("Player").transform.position;
        if (Vector3.Distance(transform.position,targetPlayer)>=_navMeshAgent.stoppingDistance)
        {
            _navMeshAgent.SetDestination(targetPlayer);
            animator.SetFloat("Speed", 0.2f);
        }
        else
        {
            animator.SetFloat("Speed", 0);
            SwitchToNewState(CharacterState.Attacking);
        }
       
    }

    public void SwitchToNewState(CharacterState newState)
    {
        switch (currentState)
        {
            case CharacterState.Normal:
                break;
            case CharacterState.Attacking:
                break;
        }
        switch (newState)
        {
            case CharacterState.Normal:
                break;
            case CharacterState.Attacking:
                animator.SetTrigger("Attack");
                transform.rotation = Quaternion.LookRotation(targetPlayer-transform.position);
                break;
        }
        currentState = newState;
    }

    void AttackAnimationEnd()
    {
        SwitchToNewState(CharacterState.Normal);
    }
}
