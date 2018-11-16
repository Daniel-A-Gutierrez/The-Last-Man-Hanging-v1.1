using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RandomLoadLevel : MonoBehaviour
{
    //Platformer2DUserControl control;
    public bool sameLevel;

    void Start(){

    }
    public void RandomLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 4){
          CountdownStart.playersLeft = CountdownStart.numPlayers;
        }
        if (!sameLevel){
          int level = Random.Range(5, 8);
          SceneManager.LoadScene(level);
        }
        else{
          Scene scene = SceneManager.GetActiveScene();
          SceneManager.LoadScene(scene.buildIndex);
        }
    }
}
