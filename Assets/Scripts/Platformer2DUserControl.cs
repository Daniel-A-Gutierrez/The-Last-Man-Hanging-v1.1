using System;
using UnityEngine;

public class Platformer2DUserControl : MonoBehaviour
{
    private PlayerController2 m_Character;
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
    public Vector2 movedir;

    private void Awake()
    {
        m_Character = GetComponent<PlayerController2>();
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
            jump = Input.GetKey(KeyCode.Space);
            useItemContinuous = Input.GetKey(KeyCode.Return);
            useItem1Frame = Input.GetKeyDown(KeyCode.Return);
        }
        movedir = new Vector2(xMove,yMove);
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
                jump = Input.GetKey(KeyCode.Space);
                useItemContinuous = Input.GetKey(KeyCode.Return);
                useItem1Frame = Input.GetKeyDown(KeyCode.Return);
            }
            movedir = new Vector2(xMove,yMove);
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

