using UnityEngine;
using System.Collections;

public class CountdownStart : MonoBehaviour {

    // Use this for initialization
    float cameraSpeed;
    float timeStart;
    bool poop = false;
    GameObject theCanvas;
    public int playersLeft;
    float timeEnd;
	void Start ()
    {
        theCanvas = GameObject.Find("Canvas");
        timeStart = Time.time;
        PauseEverything();
//        playersLeft; // 4 for multiplayer, 1 for singleplayer
        Debug.Log("line 19 in CountdownStart: playersLeft typo. plz fix. ");
	}
    void PauseEverything()
    {
        cameraSpeed = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<CameraScroll>().speed;
        GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<CameraScroll>().speed = 0;
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
        GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<CameraScroll>().speed = cameraSpeed;
        
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in gos)
        {
            go.GetComponent<Platformer2DUserControl>().startInput();
        }
        GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<StartSong>().Play();
    }
	// Update is called once per frame
    public void decrementPlayerCount()
    {
        playersLeft--;
        if (playersLeft <= 1)
        {
            PauseEverything();

            GameObject[] lastPlayer = GameObject.FindGameObjectsWithTag("Player");
            int winNumber = 0;
            foreach (GameObject go in lastPlayer)
            {
                if(go!=null)
                {
                    winNumber = go.GetComponent<HardCodedGrapple>().PlayerNumber;
                }
            }
            print(winNumber);
            theCanvas.GetComponent<CountdownManager>().fitText();
            theCanvas.GetComponent<CountdownManager>().SetText("<b>TIME : " + Time.time + "</b>");

            timeEnd = Time.time;
        }
        
    }
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
        if(timeEnd != 0 & Time.time - timeEnd > 3)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LoadLevel>().Load_Level(0);
        }
    }
}
