using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayers : MonoBehaviour {

	GameObject Player2;
	GameObject Player3;
	GameObject Player4;

	GameObject[] players;


	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag("Player");

		RemovePlayers(RandomLoadLevel.playersLeft);
	}

	public void RemovePlayers(int numPlayers){
			Player2 = GameObject.Find("Player2");
			Player3 = GameObject.Find("Player3");
			Player4 = GameObject.Find("Player4");


			if (numPlayers == 1){
					Player2.SetActive(false);
					Player3.SetActive(false);
					Player4.SetActive(false);
			}
			else if (numPlayers == 2){
				Player3.SetActive(false);
				Player4.SetActive(false);
			}
			else if (numPlayers == 3){
				Player4.SetActive(false);
			}
			else if (numPlayers == 4){
				//print("all");
			}
	}
}
