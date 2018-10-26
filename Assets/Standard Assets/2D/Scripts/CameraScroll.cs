using UnityEngine;
using System;
using System.Collections;

/*
 * Attach this script to the camera itself.
 * 
*/
public class CameraScroll : MonoBehaviour {
    GameObject[] waypoints;
    int currentWaypoint = 0;

    public float speed;
	// Use this for initialization
	void Start () {
        waypoints = GameObject.FindGameObjectsWithTag("CameraWaypoint");
        Array.Sort(waypoints, compareWaypoints);
        flattenWaypoints();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        moveToWaypoint();
	}

    void moveToWaypoint()
    {
        Vector3 target = waypoints[currentWaypoint].transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
        speed += .035f * Time.deltaTime;
        if (transform.position == target)
        {
            findNextWaypoint();
        }

    }
    void findNextWaypoint()
    {
        if (currentWaypoint < waypoints.Length - 1)
            currentWaypoint++;
        else
            currentWaypoint = 0;
    }
    void flattenWaypoints() //Puts each waypoint on the same z-axis as the camera regardless of their initial placement.
    {
        foreach (GameObject point in waypoints)
        {
            point.transform.position = new Vector3(point.transform.position.x, point.transform.position.y, this.transform.position.z);
        }
    }
    int compareWaypoints(GameObject x, GameObject y) //Sorting algorithm for alphabatizing waypoints by their Unity names (letters then nums)
    {
        return x.name.CompareTo(y.name);
    }
}
