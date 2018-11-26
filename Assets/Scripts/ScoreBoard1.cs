using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard1 : MonoBehaviour {

	GameObject[] players;

	static int[] scoreboard;
	public static bool reset;

	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag("Player");
		scoreboard = new int[players.Length];
	}

	// Update is called once per frame
	void Update () {
		if (reset = true){
			for(int i = 0; i<scoreboard.Length; i++){
				scoreboard[i] = 0;
			}
		}
	}
	public void IncreaseScore(int winNumber){
		scoreboard[winNumber-1] += 1;
	}
}
