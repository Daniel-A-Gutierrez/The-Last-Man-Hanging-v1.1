using System;
using UnityEngine;


public class PlatformerCharacter2D : MonoBehaviour
{
    [SerializeField]
    private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
    [SerializeField]
    private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
    [Range(0, 1)]
    [SerializeField]
    private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
    private bool m_AirControl = true;                 // Whether or not a player can steer while jumping;
    [SerializeField]
    private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character
    [SerializeField]
    float airAccel;
    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .04f; // Radius of the overlap circle to determine if grounded
    public bool m_Grounded;            // Whether or not the player is grounded.
    private Transform m_CeilingCheck;   // A position marking where to check for ceilings
    const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
    private Animator m_Anim;            // Reference to the player's animator component.
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private bool m_JustGrounded = true;
    const float m_PlayerAcceleration = .002f;
    //bool suspended1 = false;
    //bool suspended2 = false;
    //bool suspended3 = false;
    //bool suspended4 = false;
    int player_num;
    bool ggds;
    bool sda;
    Platformer2DUserControl control;

    public void jump()
    {
        ggds = true;
        sda = true;
    }

    void Awake()
    {
        // Setting up references.
        ggds = false;
        sda = false;
        //^^CHANGE THESE
        m_GroundCheck = transform.Find("GroundCheck");
        m_CeilingCheck = transform.Find("CeilingCheck");
        m_Anim = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        player_num = GetComponent<HardCodedGrapple>().PlayerNumber;
        control = GetComponent<Platformer2DUserControl>();
    }


    private void Update()
    {
        m_Grounded = false;
        float mass = GetComponent<Rigidbody2D>().mass;// why
        //CHANGE THIS
        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                //m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 0f);
                m_JustGrounded = false;
            }
        }
        if (m_JustGrounded == true)
        {
            m_Rigidbody2D.position.Set(m_Rigidbody2D.position.x, m_Rigidbody2D.position.y);
            m_JustGrounded = false;
            m_Anim.SetBool("Ground", true);
        }
        m_Anim.SetBool("Ground", m_Grounded);
        // Set the vertical animation
        float yJumpInitVelocity =  m_JumpForce / m_Rigidbody2D.mass *Time.deltaTime; 
        m_Anim.SetFloat("vSpeed", -m_Rigidbody2D.velocity.y/yJumpInitVelocity);
        if (GetComponent<HardCodedGrapple>().CLIMBDOWN)
        {
            m_Anim.SetFloat("vSpeed", 0);
        }
        Vector3 v3 = new Vector3(1, 0, 0);

        if (m_Grounded)
        {
            if (control.xMove < -0.05f)
            {
                transform.position += m_MaxSpeed * Time.deltaTime * v3 * control.xMove;

            }

            if (control.xMove > 0.05f)
            {
                transform.position += m_MaxSpeed * Time.deltaTime * v3 * control.xMove;

            }


        }
        if (!m_Grounded)
        {
            if ((control.xMove < -0.05f) & GetComponent<HardCodedGrapple>().directionVectorRotation < 90)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0) * mass * airAccel * control.xMove * Time.deltaTime, ForceMode2D.Impulse);
            }

            if ((control.xMove > 0.05f) & GetComponent<HardCodedGrapple>().directionVectorRotation > -90)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0) * mass * airAccel * control.xMove * Time.deltaTime, ForceMode2D.Impulse);
            }
        }
        ggds = false;
    }


    public void Move(float move, bool crouch, bool jump)
    {

        if (m_Grounded || m_AirControl)
        {
            // Reduce the speed if crouching by the crouchSpeed multiplier
            move = (crouch ? move * m_CrouchSpeed : move);

            // The Speed animator parameter is set to the absolute value of the horizontal input.
            m_Anim.SetFloat("Speed", Mathf.Abs(move));

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }
        // If the player should jump...
        if (m_Grounded && sda && m_Anim.GetBool("Ground"))
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            m_JustGrounded = true;
            m_Anim.SetBool("Ground", false);
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            if (control.xMove > 0.05f)
            {

                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x +
                    m_MaxSpeed * control.xMove, GetComponent<Rigidbody2D>().velocity.y);

            }
            if (control.xMove < -0.05f)
            {

                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + 
                    m_MaxSpeed * control.xMove, GetComponent<Rigidbody2D>().velocity.y);

            }
            sda = false;
            
        }
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

