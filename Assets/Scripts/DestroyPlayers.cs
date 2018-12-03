﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayers : MonoBehaviour {

	GameObject Player2;
	GameObject Player3;
	GameObject Player1;

//	GameObject[] players; // was unused


	// Use this for initialization
	void Start () {
//unused		players = GameObject.FindGameObjectsWithTag("Player");

		RemovePlayers(RandomLoadLevel.playersLeft); //depends on the character menu option
	}

	public void RemovePlayers(int numPlayers){ //sets active players to false depending on how many players are needed
			Player2 = GameObject.Find("Player2");
			Player3 = GameObject.Find("Player3");
			Player1 = GameObject.Find("Player1");


			if (numPlayers == 1){
					Player2.SetActive(false);
					Player3.SetActive(false);
					Player1.SetActive(false);
			}
			else if (numPlayers == 2){
				Player2.SetActive(false);
				Player1.SetActive(false);
			}
			else if (numPlayers == 3){
				Player1.SetActive(false);
			}
			else if (numPlayers == 4){
				//print("all");
			}
	}
}
