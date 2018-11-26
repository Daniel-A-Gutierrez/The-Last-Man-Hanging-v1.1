using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingGrips : MonoBehaviour {

	int x_distance = 375; //distance between each grip stack
	int x = -2;
	int[] y = {-15, 9, 35};	//holds three possible y coords for grips
	int done = 0;
	int object_select;

	public GameObject[] grips = new GameObject[3]; //holds three main grip stacks to clone

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
			while (done < 10){ //replace with done function once created
					object_select = Random.Range(0, 3);
					for (int m = 0; m < 3; m++)
					{
							Instantiate(grips[object_select], new Vector2(x, y[m]), Quaternion.identity);
					}
					x += x_distance;
					done++;
			}

	}
}
