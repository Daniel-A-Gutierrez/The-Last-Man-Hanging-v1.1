using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathObjects : MonoBehaviour {

	float currentX;
	float currentY;
	public float speed;

	// Use this for initialization
	void Start () {
		currentX = transform.localPosition.x;
		currentY = transform.localPosition.y;
	}

	// Update is called once per frame
	void Update () {

		if(currentY >= 12){
			while (!(currentY <= -12)){
				currentY -= speed*Time.deltaTime*Time.deltaTime;
				print(Time.deltaTime);
				transform.localPosition = (new Vector2 (currentX, currentY));
			}
		}
		else if(currentY <= -12){
			while (!(currentY >= 12)){
				currentY += speed*Time.deltaTime*Time.deltaTime;
				print(Time.deltaTime);
				transform.localPosition = (new Vector2 (currentX, currentY));
			}
		}


	}
}
