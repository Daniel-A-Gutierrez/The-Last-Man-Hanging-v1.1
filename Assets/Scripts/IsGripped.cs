using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGripped : MonoBehaviour {

	GameObject grip;

	float distance;

	// Use this for initialization
	void Start () {
		grip = GameObject.Find("Grip");
	}

	// Update is called once per frame
	void Update () {
			GameObject hook = GameObject.FindWithTag("Hook");
			distance = Vector3.Distance(hook.transform.position, grip.transform.position);
			if (distance < 0.1){
				SwitchTutorialText.gripped = true;
			}
			else{
				SwitchTutorialText.gripped = false;
			}
	}
}
