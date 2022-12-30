using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController cc;
    public Animator animator;
    private float horizontal, vertical;
    public float move_speed;
    private Vector3 dir;
    public float gravity;
    private float velocity_vertical;
    public float slide_speed;
    public float slide_duration;
    private float slide_startTime;
    private ApplyDamage _applyDamage;
    public enum CharacterState
    {
        Normal,
        Attacking,
    }
    public CharacterState currentState;
    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        _applyDamage = GetComponentInChildren<ApplyDamage>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.J))
        {
            SwitchToNewState(CharacterState.Attacking);
        }
        
        switch (currentState)
        {
            case CharacterState.Normal:
                PlayerMovement();
                break;
            case CharacterState.Attacking:
                Slide();
                break;
        }
    }

    void PlayerMovement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        dir.Set(horizontal, 0, vertical);
        dir = Quaternion.Euler(0, -45f, 0) * dir; 
        if(dir!=Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(dir);
        }
        
        if (cc.isGrounded == false) 
        {
            velocity_vertical = gravity;  //为防止竖直速度无限增大，直接给定一个恒定速度
        }
        else
        {
            velocity_vertical = gravity * 0.3f;
        }
        animator.SetFloat("Speed", dir.magnitude);
        animator.SetBool("IsAir", !cc.isGrounded);
        dir *= move_speed;
        dir += Vector3.up * velocity_vertical;
       
        cc.Move(dir*Time.deltaTime);
    }

    

    void Slide()
    {
        Vector3 dir = transform.forward * slide_speed;
        slide_startTime = Time.time;
        if (Time.time - slide_startTime < slide_duration)
        {
            cc.Move(dir * Time.deltaTime);
        }
    }
    public void SwitchToNewState(CharacterState newState)
    {
        switch(currentState)
        {
            case CharacterState.Normal:
                break;
            case CharacterState.Attacking:
                damageTriggerDisabled();
                break;
        }
        switch (newState)
        {
            case CharacterState.Normal:
                break;
            case CharacterState.Attacking:
                animator.SetTrigger("Attack");
                
                break;
        }
        currentState = newState;
    }

    void AttackAnimationEnd()
    {
        SwitchToNewState(CharacterState.Normal);
    }

    void damageTriggerEnabled()
    {
        _applyDamage._collider.enabled = true;
        _applyDamage.damageTargets.Clear();
    }

    void damageTriggerDisabled()
    {
        _applyDamage._collider.enabled = false;
        _applyDamage.damageTargets.Clear();
    }
}
