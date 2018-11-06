using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    //Platformer2DUserControl control;
    //public bool inLevel;

    public void Load_Level()
    {
        float level = Random.Range(2.0f, 4.0f);
        print(level);
        SceneManager.LoadScene((int)level);

    }

    void Update()
    {
        /*if (!inLevel & (Input.GetKeyDown("joystick 1 button 7") || Input.GetKeyDown("joystick 2 button 7") || Input.GetKeyDown("joystick 3 button 7") || Input.GetKeyDown("joystick 4 button 7")))
        {
            print("start");

        }*/
    }
}
