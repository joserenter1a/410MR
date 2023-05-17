using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{

    ///public WaveSpawner WaveSpawner;
    public TextMeshProUGUI Conquered;
    public SprintController sprintController;

    public float movementMultiplier = 0.048f;
    public float turnSpeed = 30f;
    float m_timer = 0.0f;
    float m_idleTime = 0.4f;
    public float jumpHeight = 2f;
    private bool isGrounded;

    
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    private int count;
    Vector3 m_Movement;
    public Vector3 jump;
    Quaternion m_Rotation = Quaternion.identity;


    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        count = 0;

        SetConqueredText();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        bool isSprinting = sprintController.isSprinting;

        // Set the IsSprinting parameter of the animator based on the sprinting state
        m_Animator.SetBool("IsSprinting", isSprinting);


        m_Animator.SetBool("IsWalking", isWalking);
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
        if(Input.GetMouseButtonDown(0))
        {
            m_Animator.Play("Attack");
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            m_Animator.Play("Jump");
            m_Rigidbody.AddForce(jump * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
        }

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }
    
    void SetConqueredText(){
        Conquered.text = "Defeated: " + count.ToString();
    }

    void OnTriggerStay(){
        isGrounded = true;
    }

    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * movementMultiplier);
        m_Rigidbody.MoveRotation(m_Rotation);
    }

    void OnButtonCkick(){
        m_Animator.SetBool("Attack", true);
    }

    private void OnCollisionEnter(Collision other){
        ContactPoint contact = other.contacts[0];
        if(other.gameObject.CompareTag("Human")){
            count = count + 1;
            Destroy(other.gameObject);
            
            SetConqueredText();
        }
    }




}

