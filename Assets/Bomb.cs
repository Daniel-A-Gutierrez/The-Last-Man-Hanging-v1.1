using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour 
{
	public float radius;
	public float maxRadius;
	public float force;
	float maxForce;//determines the maximum force that can be applied within the max Radius. 
	public LayerMask trigger;

	void Start () 
	{
		maxForce = maxRadius/radius * force;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.CompareTag("Hook"))
		{
			print("Boom");
			
			Collider2D[] players = Physics2D.OverlapCircleAll(transform.position,radius,trigger);
			foreach(Collider2D col in players)
			{
				Vector3 offset = col.transform.position - transform.position;
				float inverse = offset.magnitude > maxRadius ? 1/(offset.magnitude) : 1;
				Vector2 offset2 = new Vector2(offset.x,offset.y).normalized;
				col.gameObject.GetComponent<Rigidbody2D>().AddForce(offset2*force*inverse,ForceMode2D.Impulse);
			}
			gameObject.SetActive(false);
		}
	}
}
