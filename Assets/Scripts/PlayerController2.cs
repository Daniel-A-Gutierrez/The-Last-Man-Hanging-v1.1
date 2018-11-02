using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController2 : MonoBehaviour 
{
	public int player_num;
	public float walkSpeed = 10f;
	public float jumpImpulse = 400f;
	[Range(0,1)]
	public float airControl = .5f; // the fraction  of ground accel that the player has in air
	public LayerMask ground;
	public float groundCheckOffset; 
	public float groundCheckRadius; 
	public float playerAccel;
	bool facingRight;

	private float topSpeed;
	private Platformer2DUserControl user;  
	private Animator anim;
	private Rigidbody2D rb;
	private string State;
	private Dictionary<string,Action> States;
	
	void Start () 
	{
		user = GetComponent<Platformer2DUserControl>(); 
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		player_num = GetComponent<HardCodedGrapple>().PlayerNumber; //overrides player num in player controller
		topSpeed = walkSpeed;
		States = new Dictionary<string,Action> ();
		State = "GROUNDED";
		States["GROUNDED"] = GROUNDED;
		States["AIRBORNE"] = AIRBORNE;
		States["SWINGING"] = SWINGING;
	}

	void Update () 
	{
		States[State]();
		print(State);
		print(user.jump);
		setFace();
	}

	/*--------------------------------------------------------------------------------------------------------------------- */
	void GROUNDED()
	{
		State = "GROUNDED";
	
		if(!checkGround())
		{
			AIRBORNE();
			return;
		}
		walk();
	}

	public void Jump()
	{
		if(State == "GROUNDED")
		{		
			rb.AddForce(new Vector2(0,1)*jumpImpulse,ForceMode2D.Impulse);
			AIRBORNE();
			return;
		}
	}

	void AIRBORNE()
	{
		State = "AIRBORNE";
		if(checkGround())
		{
			GROUNDED();
			return;
		}
		fly();
	}

	void SWINGING()// currently not used, because swinging is handled independently by hard coded grapple. at best a flag can be obtained. 
	{
		State = "SWINGING";
	}
	/*--------------------------------------------------------------------------------------------------------------------- */

	void walk()
	{
		//i want them to always have startup acceleration , but have no deceleration.
		//sadly this is all i want to do for now.
		topSpeed = Math.Abs(rb.velocity.x);
		if(Mathf.Abs(user.xMove) > .01f  &  (user.xMove * rb.velocity.x) > -.01f)
			if(Mathf.Abs(rb.velocity.x) < walkSpeed)
				rb.velocity += new Vector2(user.xMove*playerAccel*Time.deltaTime,0);
			else
				rb.velocity = new Vector2(user.xMove*topSpeed,rb.velocity.y);
		else
			rb.velocity -= new Vector2(rb.velocity.x,0);
			topSpeed = walkSpeed;
	}

	void fly()
	{
		topSpeed = Math.Abs(rb.velocity.x);
		if(Mathf.Abs(user.xMove) > .01f)
			rb.velocity += new Vector2(user.xMove*airControl*playerAccel*Time.deltaTime,0);
		
	}

	void swing()
	{

	}

	void setFace()
	{
		facingRight = (rb.velocity.x>0) ? true : false;
		if(Math.Abs(user.xMove) > .01f)
		{
			Vector3 theScale = transform.localScale;
			theScale.x = new Vector2(rb.velocity.x,0).normalized.x;
			transform.localScale = theScale;
		}
	}

	bool checkGround()
	{
		Collider2D col = Physics2D.OverlapCircle(new Vector3(transform.position.x,transform.position.y+groundCheckOffset,0),groundCheckRadius,ground);
		if(col != null)
		{
			return true;
		}
		return false;
	}

	/*----------------------------------------------------------------------------------------------------------------------- */
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(new Vector3(transform.position.x,transform.position.y+groundCheckOffset,0),groundCheckRadius);
		//maybe one for jump height and grapple length as well? 
	}

	Vector3 v3(Vector2 v2)
	{
		return new Vector3(v2.x,v2.y,0);
	}
}
