﻿using UnityEngine;
using System.Collections;

public class CameraBoundry : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("UI").GetComponent<CountdownStart>().decrementPlayerCount();
        }

    }
}
