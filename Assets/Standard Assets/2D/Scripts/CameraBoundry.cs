using UnityEngine;
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
            Destroy(other.gameObject);
            GameObject.FindGameObjectWithTag("CountdownStarter").GetComponent<CountdownStart>().decrementPlayerCount();
        }
       
    }
}
