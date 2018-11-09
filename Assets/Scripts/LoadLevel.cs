using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

	// Use this for initialization
	public void Load_Level(int level){
		SceneManager.LoadScene(level);
	}
}
