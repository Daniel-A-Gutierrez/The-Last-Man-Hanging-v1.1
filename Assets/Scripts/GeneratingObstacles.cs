using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingObstacles : MonoBehaviour {

	int[] x_distance = {30, 40}; //distances between each obstacle
	int x;
	int[] y = {-8, -2, 4};	//holds three possible y coords for obstacles
	int done = 0;
	int x_select = 0; //For for loop
	public GameObject obstacle; //holds obstacle

	// Use this for initialization
	void Start () {
			x = -5 + x_distance[0]; //initializes first x coords, -5 last x coords for established obstacles
	}

	// Update is called once per frame
	void Update () {
			while (done < 10){ //replace with done function once created

					for (int m = 0; m < 3; m++)
					{
							int y_select = Random.Range(0, 3);
							Instantiate(obstacle, new Vector2(x, y[y_select]), Quaternion.identity);
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
