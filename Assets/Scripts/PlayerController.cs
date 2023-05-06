using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{

    public WaveSpawner WaveSpawner;
    public TextMeshProUGUI Conquered;

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
        //bool checkAttack = 
        //bool Attack = Input.GetMouseButtonDown(0);
        m_Animator.SetBool("IsWalking", isWalking);
        //m_Animator.SetBool("Attack", Attack); 
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
        //if(Attack)
        if(Input.GetMouseButtonDown(0))
        {
            //m_timer += Time.deltaTime;
            /*if(m_timer >= m_idleTime)
            {
                m_Animator.SetBool("Attack", false);
                m_timer = 0f;
            }
        } else*/
        
            m_Animator.Play("Attack");
            //m_timer = 0f;
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
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * movementMultiplier);//m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }

    void OnButtonCkick(){
        m_Animator.SetBool("Attack", true);
    }

    private void OnCollisionEnter(Collision other){


        /*if(other.gameObject.CompareTag("Human")){
            Debug.Log("ype");
            other.gameObject.SetActive(false);

            //WaveSpawner.spawnedEnemies.Count--;
  
        }*/
        ContactPoint contact = other.contacts[0];
        if(other.gameObject.CompareTag("Human")){
            count = count + 1;
            Destroy(other.gameObject);
            
            SetConqueredText();
            //WaveSpawner.spawnedEnemies.Count--;
        }
    }




}

