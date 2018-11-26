using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingDeathGate : MonoBehaviour {

	int[] x_distance = {50, 60}; //distances between each death gate
	int x;
	int[] y = {-8, -2, 4};	//holds three possible y coords for death gates
	int[] z = {0, -45, 45, 90}; //holds the four rotatoin angles for the death gates
	int done = 0;
	int x_select = 0; //For for loop
	int y_select;
	int z_select;
	int object_select; //To rotate between types of death gates
	public GameObject deathGate; //holds death gates

	// Use this for initialization
	void Start () {
			x = 30 + x_distance[0]; //initializes first x coords, 70 last x coords for established death gate
	}

	// Update is called once per frame
	void Update () {
			while (done < 10){ //replace with done function once created

					for (int m = 0; m < 3; m++)
					{
							y_select = Random.Range(0, 3);
							z_select = Random.Range(0, 4);
							Instantiate(deathGate, new Vector2(x, y[y_select]), Quaternion.Euler(0, 0, z[z_select]));
							x += x_distance[x_select];

							if (x_select == 1){
								x_select = 0;
							}
							else{
								x_select++;
							}
					}
					done++;
			}
	}
}
