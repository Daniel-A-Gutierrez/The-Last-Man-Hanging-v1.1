using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CountdownStart : MonoBehaviour
{

    // Use this for initialization
    float cameraSpeed;
    float timeStart;
    bool poop = false;
    bool cursor = false; //Change to true for removing Cursor
    GameObject theCanvas;
    
    float timeEnd;

    public int playersLeft;
    public int numPlayers;

    GameObject[] players;
    GameObject[] deathField;
    GameObject mainCamera;
    GameObject pauseMenu;

    public static CountdownStart Instance;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        pauseMenu = GameObject.FindWithTag("PauseMenu");
        theCanvas = GameObject.Find("Canvas");
        numPlayers = playersLeft;
        timeStart = Time.time;
        PauseEverything();
        //int playersLeft; // 4 for multiplayer, 1 for singleplayer
        if (cursor)
        {
            Cursor.visible = false; //Removes cursor for PC users
        }
        deathField = GameObject.FindGameObjectsWithTag("DeathZone");
    }
    public void PauseEverything()
    {

        cameraSpeed = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<CameraScroll>().speed;
        GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<CameraScroll>().speed = 0;
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject go in gos)
        {
            go.GetComponent<Platformer2DUserControl>().noInput();
        }
        //actually do this in start everything. //transform.Find("MainCamera").gameObject.GetComponent<StartSong>().Play();
    }
    public void StartEverything()
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
        FindObjectOfType<AudioManager>().Play("BackgroundMusic");

    }
    // Update is called once per frame
    public void decrementPlayerCount()
    {
        playersLeft--;
        if (playersLeft <= 1)
        {
            foreach (GameObject zone in deathField)
            {
                zone.SetActive(false); //deactivates death zone on game
            }
            PauseEverything();

            GameObject[] lastPlayer = GameObject.FindGameObjectsWithTag("Player");
            int winNumber = 0;
            foreach (GameObject go in lastPlayer)
            {
                if (go.activeSelf)
                {
                    winNumber = go.GetComponent<HardCodedGrapple>().PlayerNumber;
                }
            }
            print(winNumber);
            theCanvas.GetComponent<CountdownManager>().fitText();
            int timer = (int)(Time.time - timeStart);
            theCanvas.GetComponent<CountdownManager>().SetText("<b>TIME : " + timer + " seconds\nWinner: Player " + winNumber + "</b>");

            timeEnd = Time.time;
        }

    }
    void Update()
    {
        if (Time.time - timeStart > 3 & !poop)
        {
            if (pauseMenu.activeSelf == false)
            {  //in case paused while countdown is still happening
                StartEverything();
                poop = true;
            }
        }
        else if (Time.time - timeStart > 2 & !poop)
        {
            theCanvas.GetComponent<CountdownManager>().SetText("<b>1</b>");
        }
        else if (Time.time - timeStart > 1 & !poop)
        {
            theCanvas.GetComponent<CountdownManager>().SetText("<b>2</b>");
        }
        if (timeEnd != 0 & Time.time - timeEnd > 3)
        {
            GameObject.FindGameObjectWithTag("UI").GetComponent<RandomLoadLevel>().RandomLevel();
        }
    }
    public void PlayersLeft(int num)
    {
        playersLeft = num;
        print(playersLeft);
    }
}
