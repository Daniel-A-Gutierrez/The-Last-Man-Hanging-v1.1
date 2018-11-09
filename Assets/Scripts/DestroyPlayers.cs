using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayers : MonoBehaviour {

	int numPlayers;

	GameObject Player2;
	GameObject Player3;
	GameObject Player4;
	// Use this for initialization
	void Start () {
			Player2 = GameObject.Find("Player2");
			Player3 = GameObject.Find("Player3");
			Player4 = GameObject.Find("Player4");
			numPlayers = CountdownStart.playersLeft;
			RemovePlayers();
	}

	// Update is called once per frame
	void Update () {

	}

	void RemovePlayers(){
			if (numPlayers == 1){
					Destroy(Player2);
					Destroy(Player3);
					Destroy(Player4);
			}
			else if (numPlayers == 2){
				Destroy(Player3);
				Destroy(Player4);
			}
			else if (numPlayers == 3){
				Destroy(Player4);
			}
	}
}
