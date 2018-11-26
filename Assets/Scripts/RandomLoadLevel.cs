using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RandomLoadLevel : MonoBehaviour
{
    //Platformer2DUserControl control;
    public bool sameLevel; //For if the same level is to be repeated
    int numPlayers; //current number of players left
    public static int playersLeft;

    void Start(){
      numPlayers = playersLeft;
    }
    public void RandomLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 4){ //For level scenes only
          playersLeft = numPlayers;
          ScoreBoard1.reset = true;
          Scene scene = SceneManager.GetActiveScene();
          SceneManager.LoadScene(scene.buildIndex); //Reloads the level again if sameLevel is True
        }
        if (!sameLevel){ //Raandom level if sameLevel is not true
          int level = Random.Range(5, 8);
          ScoreBoard1.reset = true;
          SceneManager.LoadScene(level);
        }
    }
    public void PlayersLeft(int num) //input from the character menu
    {
        playersLeft = num;
        print(playersLeft);
    }
}
