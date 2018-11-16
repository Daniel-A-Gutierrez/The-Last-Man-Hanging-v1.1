using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuVisibility : MonoBehaviour {

	GameObject pauseMenu;

	// Use this for initialization
	void Start () {
		pauseMenu = GameObject.FindWithTag("PauseMenu");
		pauseMenu.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		//for(i=0; i<players.length; i++){
			if(Input.GetButtonDown("Cancel") && pauseMenu.activeSelf == false){
				pauseMenu.SetActive(true);
				CountdownStart.Instance.PauseEverything();
			}
			else if(Input.GetButtonDown("Cancel") && pauseMenu.activeSelf == true){
				pauseMenu.SetActive(false);
				CountdownStart.Instance.StartEverything();
			}
		//}

	}
}
