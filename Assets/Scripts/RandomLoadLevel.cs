using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RandomLoadLevel : MonoBehaviour
{
    //Platformer2DUserControl control;
    public bool sameLevel;
    public void RandomLevel()
    {
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
