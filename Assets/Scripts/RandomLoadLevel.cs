using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RandomLoadLevel : MonoBehaviour
{
    //Platformer2DUserControl control;
    public bool sameLevel;
    int numPlayers;
    public static int playersLeft;

    void Start(){
      numPlayers = playersLeft;
    }
    public void RandomLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 4){
          playersLeft = numPlayers;
          Scene scene = SceneManager.GetActiveScene();
          SceneManager.LoadScene(scene.buildIndex);
        }
        if (!sameLevel){
          int level = Random.Range(5, 8);
          SceneManager.LoadScene(level);
        }
    }
    public void PlayersLeft(int num)
    {
        playersLeft = num;
        print(playersLeft);
    }
}
