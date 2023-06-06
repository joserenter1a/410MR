using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{

    ///public WaveSpawner WaveSpawner;
    public SprintController sprintController;

    public float movementMultiplier = 0.048f;
    public float turnSpeed = 30f;
    private float desiredAttackCooldown = 350;
    private float attackCooldown = 0;
    float m_timer = 0.0f;
    float m_idleTime = 0.4f;
    public float jumpHeight = 2f;
    private bool isGrounded;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    public Vector3 jump;
    Quaternion m_Rotation = Quaternion.identity;

    public Transform cam;
    int jumpCooldown;
    int desiredJumpCooldown = 350;

    public GameObject fireballPrefab;
    public float fireballSpeed = 10f;
    public int fireballDamage = 10;
    public float fireballCooldown = 3f;
    public float lastFireballTime;

    //public bool timeSlowActive = false; // Variable to track if time slow is active
    //public float timeSlowFactor = 0.5f; // The factor by which time is slowed down

    public SlowAbility slowAbility;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

        jumpCooldown = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (jumpCooldown > 0)
        {
            jumpCooldown--;
        }
        

        float horizontal = Input.GetAxisRaw("Horizontal") * movementMultiplier;
        float vertical = Input.GetAxisRaw("Vertical") * movementMultiplier;

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;
        camForward.y = 0;
        camRight.y = 0;

        Vector3 forwardRelative = vertical * camForward;
        Vector3 rightRelative = horizontal * camRight;

        Vector3 moveDir = forwardRelative + rightRelative;

        //m_Rigidbody.velocity = new Vector3(moveDir.x, m_Rigidbody.velocity.y, moveDir.z);
        //transform.forward = new Vector3(m_Rigidbody.velocity.x, 0f, m_Rigidbody.velocity.z);
        m_Movement.Set(moveDir.x, 0f, moveDir.z);
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

        attackCooldown--;
        if(Input.GetMouseButtonDown(0) && attackCooldown <= 0)
        {
            m_Animator.Play("Attack");
            attackCooldown = desiredAttackCooldown;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && jumpCooldown == 0){
            jumpCooldown = desiredJumpCooldown;
            m_Animator.Play("Jump");
            m_Rigidbody.AddForce(jump * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
        }

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);

        if(Input.GetKeyDown(KeyCode.Q) && CanShootFireball())
        {
            SpawnFireball();
            lastFireballTime = Time.time;
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            slowAbility.ActivateSlowAbility();
            //timeSlowActive = !timeSlowActive; // Toggle the time slow activation
            //Time.timeScale = timeSlowActive ? timeSlowFactor : 1f; // Adjust the time scale based on timeSlowActive

        }
    }


    void OnTriggerStay(Collider other){
        if (other.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * movementMultiplier);
        m_Rigidbody.MoveRotation(m_Rotation);
    }

    void OnButtonCkick(){
        m_Animator.SetBool("Attack", true);
    }

    private bool CanShootFireball()
    {
        return Time.time - lastFireballTime >= fireballCooldown;
    }

    private void SpawnFireball()
    {
        
        GameObject fireball = Instantiate(fireballPrefab, transform.position + transform.up * 1.2f + transform.forward, transform.rotation);
        Fireball fireballComponent = fireball.GetComponent<Fireball>();
        fireballComponent.speed = fireballSpeed;
        fireballComponent.damage = fireballDamage;
    }
    
}

