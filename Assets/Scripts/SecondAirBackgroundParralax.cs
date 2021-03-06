using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondAirBackgroundParralax : MonoBehaviour {

	Transform camTrans;
	Vector3 oldCamPos;
	GameObject m;
	SpriteRenderer mf;
	public float ratio = 1f;

	// Use this for initialization
	void Start ()
	{
		camTrans = GameObject.FindGameObjectWithTag("MainCamera").transform;
		oldCamPos = camTrans.position;
		mf = GetComponent<SpriteRenderer>();
		m = mf.gameObject;
		Vector2 uvs = m.transform.position;
		ratio = ratio/10;
	}
	void Update ()
	{
		Vector3 offset = camTrans.position - oldCamPos;
		oldCamPos = camTrans.position;
		Vector2 uvs = m.transform.position;

		uvs.x -= ratio*offset.x/transform.localScale.x;
		uvs.y -= ratio*offset.y/transform.localScale.z;

		m.transform.position = uvs;
	}
/*
	public float speed;

	float initialy;
	float initialx;
	float length;
	float width;
	float set;
	float camerax;
	float cameray;

	GameObject mainCamera;
	GameObject thisLayer;
	Vector3 previousPos;
	Vector3 mcPosition;
	Vector3 direction;

	// Use this for initialization
	void Start () {
			mcPosition = GameObject.FindWithTag("MainCamera").transform.position;
			previousPos = mcPosition;
			mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
			thisLayer = GameObject.Find("Layer2");
			initialy = thisLayer.transform.localPosition.y;
			initialx = thisLayer.transform.localPosition.x;
			camerax = mainCamera.transform.localPosition.x + (mainCamera.transform.localPosition.x * 1/2);
			cameray = mainCamera.transform.localPosition.y + (mainCamera.transform.localPosition.y * 1/2);
			length = thisLayer.GetComponent<SpriteRenderer>().size.y * thisLayer.transform.localScale.y;// THIS CAN CAUSE PROBLEMS
			width = thisLayer.GetComponent<SpriteRenderer>().size.x * thisLayer.transform.localScale.x;
			set = length;
	}

	// Update is called once per frame
	void Update () {
			mcPosition = GameObject.FindWithTag("MainCamera").transform.position;
			direction = mcPosition - previousPos;

			if (direction.y > 0){ //if camera moves up
					thisLayer.transform.localPosition = new Vector2(thisLayer.transform.localPosition.x, thisLayer.transform.localPosition.y -
						speed * mainCamera.GetComponent<CameraScroll>().speed * Time.deltaTime);
			}
			else if (direction.y < 0){ //if camera goes down
				thisLayer.transform.localPosition = new Vector2(thisLayer.transform.localPosition.x, thisLayer.transform.localPosition.y +
					speed * mainCamera.GetComponent<CameraScroll>().speed * Time.deltaTime);
			}
			else{ //if camera goes straight
				thisLayer.transform.localPosition = new Vector2(thisLayer.transform.localPosition.x, thisLayer.transform.localPosition.y);
			}

			previousPos = mcPosition;

			if(initialy - thisLayer.transform.localPosition.y  >= set)
			{
					thisLayer.transform.localPosition = new Vector2(camerax, cameray);
			}
	}*/
	}
