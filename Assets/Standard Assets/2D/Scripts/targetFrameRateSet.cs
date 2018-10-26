using UnityEngine;
using System.Collections;

public class targetFrameRateSet : MonoBehaviour {

    // Use this for initialization
    public int targetFrameRate;
    int once;
	void Start () {
	
	}
	void Awake()
    {
        Application.targetFrameRate = targetFrameRate;
    }
	// Update is called once per frame
	void Update () {
        once++;
        if (once == 100)
        {
           // print(1 / Time.deltaTime);
            once = 0;
        }
	}
}
