using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStartEverything : MonoBehaviour {
	// Use this for initialization
	float timeStart;
	bool poop = false;
	bool cursor = false; //Change to true for removing Cursor
	GameObject theCanvas;
	float timeEnd;

	GameObject player;

	void Start ()
	{
			theCanvas = GameObject.Find("Canvas");
			timeStart = Time.time;
			player = GameObject.FindWithTag("Player");
			PauseEverything();
			//int playersLeft; // 4 for multiplayer, 1 for singleplayer
			if (cursor){
					Cursor.visible = false; //Removes cursor for PC users
			}
	}
	void PauseEverything()
	{
			GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
			foreach(GameObject go in gos)
			{
					go.GetComponent<Platformer2DUserControl>().noInput();
			}
			//actually do this in start everything. //transform.Find("MainCamera").gameObject.GetComponent<StartSong>().Play();
	}
	void StartEverything()
	{

			//foreach(GameObject go in GameObject.FindGameObjectsWithTag("UI"))
			//{
			//    Destroy(go);
			//}
			theCanvas.GetComponent<CountdownManager>().SetText(" ");

			GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
			foreach (GameObject go in gos)
			{
					go.GetComponent<Platformer2DUserControl>().startInput();
			}
			GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<StartSong>().Play();
			FindObjectOfType<AudioManager>().Play("BackgroundMusic");

	}
	// Update is called once per frame

	void Update ()
	{
		if(Time.time - timeStart > 3 &!poop)
			{
					StartEverything();
					poop = true;
			}
		else if (Time.time - timeStart > 2 & !poop)
		{
				theCanvas.GetComponent<CountdownManager>().SetText("<b>1</b>");
		}
		else if (Time.time - timeStart > 1 & !poop)
		{
				theCanvas.GetComponent<CountdownManager>().SetText("<b>2</b>");
		}
		else if (player == null){
			player = (GameObject)(Instantiate(Resources.Load("Player4"), new Vector2(-13.0f, 10.5f), Quaternion.identity));
		}
		else if(timeEnd != 0 & Time.time - timeEnd > 3)
		{
				GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RandomLoadLevel>().RandomLevel();
		}
	}
}
