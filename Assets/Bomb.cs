using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Bomb : MonoBehaviour 
{
	public float radius;
	public float maxRadius;
	public float force;
	float maxForce;//determines the maximum force that can be applied within the max Radius. 
	public LayerMask trigger;
	
	public Animator animator;

	public float TickTime;
	public float tickSpeed;
	public float idleSpeed;
	public float explosionSpeed;
	bool exploded = false;
	AudioManager audioManager;

	void Start () 
	{
		audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>(); 
		Array.Find(audioManager.sounds, sound => sound.name == "Phone_Dial_Beeps").source.pitch = tickSpeed/2;
		maxForce = maxRadius/radius * force;
		animator.speed = idleSpeed;//plays the idle by entry default.
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	//the animations have events which progress the method stream and terminate the explosion. 
	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.CompareTag("Hook") & !exploded)
		{
			animator.Play("BombAnim");
			audioManager.Play("Phone_Dial_Beeps");
			animator.speed = tickSpeed;
			exploded = true;
			StartCoroutine("Tick");
		}
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, radius);
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position,maxRadius);
	}

	IEnumerator Tick() 
	{
		yield return new WaitForSeconds(TickTime);
		EndTick();
	}
	void EndTick()
	{
		animator.Play("BombExplosion");
		audioManager.Stop("Phone_Dial_Beeps");
		audioManager.Play("explosion1");
		animator.speed = explosionSpeed;
		Collider2D[] players = Physics2D.OverlapCircleAll(transform.position,radius,trigger);
		foreach(Collider2D col in players)
		{
			Vector3 offset = col.transform.position - transform.position;
			float inverse = offset.magnitude > maxRadius ? (maxRadius/offset.magnitude) : 1;
			Vector2 offset2 = new Vector2(offset.x,offset.y).normalized;
			col.gameObject.GetComponent<Rigidbody2D>().AddForce(offset2*force*inverse,ForceMode2D.Impulse);
		}
	}

	void EndExplosion()
	{
		gameObject.SetActive(false);
	}
	
}
