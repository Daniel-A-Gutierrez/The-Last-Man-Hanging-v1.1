﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RandomLoadLevel : MonoBehaviour
{
    //Platformer2DUserControl control;
    //public bool inLevel;

    public void RandomLevel()
    {
        int level = Random.Range(4, 7);
        SceneManager.LoadScene(level);

    }

    void Update()
    {
        /*if (!inLevel & (Input.GetKeyDown("joystick 1 button 7") || Input.GetKeyDown("joystick 2 button 7") || Input.GetKeyDown("joystick 3 button 7") || Input.GetKeyDown("joystick 4 button 7")))
        {
            print("start");

        }*/
    }
}
