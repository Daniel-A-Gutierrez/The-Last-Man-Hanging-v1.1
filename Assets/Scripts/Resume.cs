using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour {

	GameObject pauseMenu;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	public void ResumeGame(){
		pauseMenu = GameObject.FindWithTag("PauseMenu");
		pauseMenu.SetActive(false);
		CountdownStart.Instance.StartEverything();
	}
}
