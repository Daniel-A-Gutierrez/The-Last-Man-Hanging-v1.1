using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayers : MonoBehaviour {

	GameObject Player2;
	GameObject Player3;
	GameObject Player4;

	int players;

	// Use this for initialization
	void Start () {
		Debug.Log(CountdownStart.playersLeft);
		RemovePlayers(CountdownStart.playersLeft);
	}

	public void RemovePlayers(int numPlayers){
			Player2 = GameObject.Find("Player2");
			Player3 = GameObject.Find("Player3");
			Player4 = GameObject.Find("Player4");
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
			else if (numPlayers == 4){
				print("all");
			}
	}
}
