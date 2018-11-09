using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "score", menuName = "ScriptableObjects/ScoreBoard", order = 1)]

public class ScoreBoard : ScriptableObject {
	public int[] score;
	//score.score[winNumber-1]++;
	//print(score.score);
}
