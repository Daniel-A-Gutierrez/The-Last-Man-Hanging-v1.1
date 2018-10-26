using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour
{
    private PlatformerCharacter2D m_Character;
    private bool m_Jump;
    int playerNumber;
    public float hAim;
    public float vAim;
    public float xMove;
    public float yMove;
    public bool LThrow;
    public bool RThrow;
    public bool jump;
    Vector2 target;
    Vector2 normalizedVelocityFactor;
    Vector2 playerPosition;
    public bool useItemContinuous;
    public bool useItem1Frame;
    public bool justPressed;
    [SerializeField]
    public bool controller;
    public bool justJumped;
    public bool boogie;
    public bool inputing = true;

    private void Awake()
    {
        m_Character = GetComponent<PlatformerCharacter2D>();
        playerNumber = GetComponent<HardCodedGrapple>().PlayerNumber;
        if (controller)
        {
            hAim = Input.GetAxis("Cont_" + playerNumber + "_Right_Horiz");
            vAim = Input.GetAxis("Cont_" + playerNumber + "_Right_Vert");
            xMove = Input.GetAxis("Cont_" + playerNumber + "_Left_Horiz");
            yMove = Input.GetAxis("Cont_" + playerNumber + "_Left_Vert");
            LThrow = Input.GetAxis("Cont_" + playerNumber + "_RB") > .95;
            RThrow = Input.GetAxis("Cont_" + playerNumber + "_RT") > .95;
            jump = Input.GetAxis("Cont_" + playerNumber + "_A") > .95;
            useItemContinuous = Input.GetAxis("Cont_" + playerNumber + "_B") > .95;
            useItem1Frame = Input.GetAxis("Cont_" + playerNumber + "_B") > .95;
        }
        else
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition); //thanks shawn for this function
            playerPosition = transform.position;
            normalizedVelocityFactor = new Vector2(target.x - playerPosition.x, target.y - playerPosition.y);
            normalizedVelocityFactor.Normalize();
            hAim = normalizedVelocityFactor.x;
            vAim = -normalizedVelocityFactor.y;
            xMove = Input.GetAxis("Horizontal");
            yMove = Input.GetAxis("Vertical");
            LThrow = Input.GetKey(KeyCode.Mouse0);
            RThrow = Input.GetKey(KeyCode.Mouse1);
            jump = Input.GetKeyDown(KeyCode.Space);
            useItemContinuous = Input.GetKey(KeyCode.Return);
            useItem1Frame = Input.GetKeyDown(KeyCode.Return);
        }
    }


    private void Update()
    {
        if (inputing)
        {
            if (controller)
            {
                hAim = Input.GetAxis("Cont_" + playerNumber + "_Right_Horiz");
                vAim = Input.GetAxis("Cont_" + playerNumber + "_Right_Vert");
                xMove = Input.GetAxis("Cont_" + playerNumber + "_Left_Horiz");
                yMove = Input.GetAxis("Cont_" + playerNumber + "_Left_Vert");
                LThrow = Input.GetAxis("Cont_" + playerNumber + "_RB") > .95;
                RThrow = Input.GetAxis("Cont_" + playerNumber + "_RT") > .95;
                jump = Input.GetKeyDown("joystick " + playerNumber + " button 8");
                useItemContinuous = Input.GetAxis("Cont_" + playerNumber + "_B") > .95;
                if (useItemContinuous & justPressed)
                {
                    useItem1Frame = false;
                }
                if (useItemContinuous & !justPressed)
                {
                    useItem1Frame = true;
                    justPressed = true;
                }

                if (!useItemContinuous)
                {
                    justPressed = false;
                    useItem1Frame = false;
                }


            }

            else
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition); //thanks shawn for this function
                playerPosition = transform.position;
                normalizedVelocityFactor = new Vector2(target.x - playerPosition.x, target.y - playerPosition.y);
                normalizedVelocityFactor.Normalize();
                hAim = normalizedVelocityFactor.x;
                vAim = -normalizedVelocityFactor.y;
                xMove = Input.GetAxis("Horizontal");
                yMove = Input.GetAxis("Vertical");
                LThrow = Input.GetKey(KeyCode.Mouse0);
                RThrow = Input.GetKey(KeyCode.Mouse1);
                jump = Input.GetKeyDown(KeyCode.Space);
                useItemContinuous = Input.GetKey(KeyCode.Return);
                useItem1Frame = Input.GetKeyDown(KeyCode.Return);
            }
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                //m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
                //m_Jump = jump;
            }
            bool crouch = false;
            if (jump)
            {
                GetComponent<PlatformerCharacter2D>().jump();
            }
            m_Character.Move(xMove, crouch, jump);
            jump = false;
        }
    }
    public void noInput()
    {
        inputing = false;
    }
    public void startInput()
    {
        inputing = true;
    }


    private void FixedUpdate()
    {
        // Read the inputs.
        //bool crouch = Input.GetKey(KeyCode.LeftControl);
        //float h = CrossPlatformInputManager.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
        
        //m_Jump = false;
    }
}

