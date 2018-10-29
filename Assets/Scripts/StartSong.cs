using UnityEngine;
using System.Collections;

public class StartSong : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
    
    public void Play()
    {
        AudioSource Audio = GetComponent<AudioSource>();
        Audio.Play();
    }
	// Update is called once per frame
	void Update ()
    {
	
	}
}
