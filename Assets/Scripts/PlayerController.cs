using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed = 20f;
    float m_timer = 0.0f;
    float m_idleTime = 0.4f;
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;


    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        //bool checkAttack = 
        bool Attack = Input.GetMouseButtonDown(0);
        m_Animator.SetBool("IsWalking", isWalking);
        m_Animator.SetBool("Attack", Attack); 
        if(!isWalking)
        {
            m_timer += Time.deltaTime;
            if(m_timer >= m_idleTime)
            {
                m_Animator.SetBool("IsWalking", false);
                m_timer = 0f;
            }
        } else
        {
            m_Animator.SetBool("IsWalking", true);
            m_timer = 0f;
        }
        if(Attack)
        {
            m_timer += Time.deltaTime;
            /*if(m_timer >= m_idleTime)
            {
                m_Animator.SetBool("Attack", false);
                m_timer = 0f;
            }
        } else*/
        
            m_Animator.SetTrigger("Attack");
            m_timer = 0f;
        }

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * .2f);//m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }

    void OnButtonCkick(){
        m_Animator.SetBool("Attack", true);
    }
}
