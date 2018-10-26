using UnityEngine;
using System.Collections;

public class Items : MonoBehaviour {

    public bool hasStomp;
    public float stompForce = 1000;

    GameObject stomper;
    

	// Use this for initialization
	void Start () {
        stomper = transform.Find("Player1Stomper").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.H))
        {
            if (hasStomp)
            {
                stomper.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Finish")
        {
            print("butt");
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1*stompForce));
            stomper.GetComponent<BoxCollider2D>().enabled = false;
            hasStomp = false;
            //any any other item pickup deletion we need to do
        }
    }
}
