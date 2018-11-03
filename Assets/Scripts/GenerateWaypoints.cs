using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWaypoints : MonoBehaviour {

	int x_distance = 60; //distance between each waypoint
	int x;
	int done = 0;

	public GameObject[] waypoints = new GameObject[7];	//holds manual waypoints

	// Use this for initialization
	void Start () {
			x = 485 + x_distance;	//initializes x, 485 last coord for established waypoints
	}

	// Update is called once per frame
	void Update () {
			while (done < 10){	//Replace with done function when created
					for (int i = 0; i < 3; i++)
					{
							float y_coords = waypoints[i].transform.localPosition.y;	//takes same y coords as established waypoints
							Instantiate(waypoints[i], new Vector2(x, y_coords), Quaternion.identity);
							x += x_distance;
					}
					done++;
			}
	}
}
