using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingGrips : MonoBehaviour {

	int x_distance = 375; //distance between each grip stack
	int x;
	int[] y = {-15, 9, 35};	//holds three possible y coords for grips
	int done = 0;

	public GameObject[] grips = new GameObject[3]; //holds three main grip stacks to clone

	// Use this for initialization
	void Start () {
			x = 750 + x_distance; //initializes first x coords, 750 last x coords for established grip stacks
	}

	// Update is called once per frame
	void Update () {
			while (done < 10){ //replace with done function once created
					for (int i = 0; i < 3; i++)
					{
							for (int m = 0; m < 3; m++)
							{
									Instantiate(grips[i], new Vector2(x, y[m]), Quaternion.identity);
							}
							x += x_distance;
					}
					done++;
			}
	}
}
