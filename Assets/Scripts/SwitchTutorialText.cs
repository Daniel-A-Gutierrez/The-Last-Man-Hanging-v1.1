using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchTutorialText : MonoBehaviour {

	Text welcome;
	Text trySwing;
	Text great;
	Text move;
	Text great2;
	Text right;

	public static bool gripped;
	float tempTime = 0.0f;
	int frame = 0;
	int count;
	bool over;
	float timeStart;

	GameObject player;
	GameObject grip;
	GameObject grip1;

	// Use this for initialization
	void Start () {
			timeStart = Time.time;
			welcome = transform.GetChild(1).gameObject.GetComponent<Text>();
			trySwing = transform.GetChild(2).gameObject.GetComponent<Text>();
			great = transform.GetChild(3).gameObject.GetComponent<Text>();
			move = transform.GetChild(4).gameObject.GetComponent<Text>();
			great2 = transform.GetChild(5).gameObject.GetComponent<Text>();
			right = transform.GetChild(6).gameObject.GetComponent<Text>();

			player = GameObject.FindWithTag("Player");
			grip = GameObject.Find("Grip");
			grip1 = GameObject.Find("Grip 1");

			welcome.enabled = false;
			trySwing.enabled = false;
			great.enabled = false;
			move.enabled = false;
			great2.enabled = false;
			right.enabled = false;
			grip.SetActive(false);
			grip1.SetActive(false);

			count = 0;
			over = false;
	}

	// Update is called once per frame
	void Update () {
		float frame = 1.0f/Time.deltaTime;
		float timer = Time.time - timeStart;

		if (Time.time >= 3.5 && timer < 8){
			welcome.enabled = true;
		}
		else if (Time.time >= 8 && Time.time < 12){
			welcome.enabled = false;
			trySwing.enabled = true;
			grip.SetActive(true);

		}
		else if (Time.time >= 12 && Time.time < 16){
			trySwing.enabled = false;
			move.enabled = true;
		}
		else if (Time.time >= 16 && Time.time < 20){
			move.enabled = false;
			right.enabled = true;
			grip1.SetActive(true);
		}
		else if (Time.time >= 20 && Time.time < 20){
			right.enabled = false;
			great.enabled = true;
		}
		//else if (){

		//}
		else{
			welcome.enabled = false;
			trySwing.enabled = false;
			great.enabled = false;
			move.enabled = false;
			great2.enabled = false;
			right.enabled = false;
		}
	}
}
