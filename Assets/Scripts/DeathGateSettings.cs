using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathGateSettings : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter2D(Collision2D other)
	{
			if (other.gameObject.tag == "Player")
			{
					other.gameObject.SetActive(false);
					GameObject.FindGameObjectWithTag("UI").GetComponent<CountdownStart>().decrementPlayerCount();
					FindObjectOfType<AudioManager>().Play("PlayerDeath");
			}

	}
}
