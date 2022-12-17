using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController cc;
    private float horizontal, vertical;
    public float move_speed;
    private Vector3 dir;
    public float gravity;
   private float velocity_vertical;
    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

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
            velocity_vertical = gravity;  //Ϊ��ֹ��ֱ�ٶ���������ֱ�Ӹ���һ���㶨�ٶ�
        }
        else
        {
            velocity_vertical = gravity * 0.3f;
        }
        dir *= move_speed * Time.deltaTime;
        dir += Vector3.up * velocity_vertical;
       
        cc.Move(dir);
    }
}