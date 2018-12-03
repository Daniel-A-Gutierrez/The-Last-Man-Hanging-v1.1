using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathGateSettings : MonoBehaviour {

	IEnumerator coroutine;

	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter2D(Collider2D other)	//Whenever a player hits a death gate, they die and audio is played
	{
			if (other.gameObject.tag == "Player")
			{
					coroutine = WaitKill(other.gameObject);
					StartCoroutine(coroutine);
			}

	}
	IEnumerator WaitKill(GameObject player)
  {
      yield return new WaitForSeconds(0.1f);
			player.SetActive(false);
			GameObject.FindGameObjectWithTag("UI").GetComponent<CountdownStart>().decrementPlayerCount();
			FindObjectOfType<AudioManager>().Play("PlayerDeath");
  }
}
