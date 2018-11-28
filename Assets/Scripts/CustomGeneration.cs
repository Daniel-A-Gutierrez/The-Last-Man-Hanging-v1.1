using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CustomGeneration : MonoBehaviour 
{

	Transform camPos;
	List<List<GameObject>> tiers;
	List<GameObject> loaded;
	public float loadDistance;
	public float deleteDistance;
	public int numTiers;
	public int progressionRate; 

	public int distributionSize;

	int chunksLoaded = 0;
	// given the folder, load everything in it into an array of gameObjects. 
	//in start just load the first one randomly.
	//take the camera's position. load objects when the camera is within (SIZE) units of the end of the first one.
	//delete the gameObjects when the camera is more than (SIZE) units past the end of the last one. 
	//i want it to more or less load them in order. so the longer you go, the higher the number it will tend to pick.  
	void Awake()
	{
		tiers = new List<List<GameObject>>();
		loaded = new List<GameObject>();
		for(int o = 0 ; o <numTiers ;o++)
		{
			tiers.Add( new List<GameObject>() ) ;
			for(int i = 0; i < 10 ; i++)
			{
				try
				{
					tiers[o].Add(Resources.Load<GameObject>("Play Elements/Set" + (o*10 + i)));
					//tiers[o][i].SetActive(false); this is done by default by load.
					if(tiers[o][i] == null)
						throw new NullReferenceException();
				}
				catch(NullReferenceException)
				{
					tiers[o].RemoveAt(i);
					break;
				}
			}
		}
	}
	void Start () 
	{
		camPos = GameObject.FindGameObjectWithTag("MainCamera").transform;
		int loadnum = UnityEngine.Random.Range(0,tiers[0].Count);
		loaded.Add(Instantiate(tiers[0][loadnum],Vector3.zero,Quaternion.identity));
		loaded[loaded.Count -1].SetActive(true);
		chunksLoaded++;
	}

	Vector3 v2v3(Vector2 v2)
	{
		return new Vector3(v2.x,v2.y);
	}
	void loadChunk()
	{
		int maxtier = chunksLoaded/progressionRate;
		maxtier = maxtier >= numTiers ? numTiers -1 : maxtier;
		int mintier = maxtier > distributionSize ? maxtier-distributionSize : 0;
		int loadtier = UnityEngine.Random.Range(mintier,maxtier);
		int loadnum = UnityEngine.Random.Range(0,tiers[loadtier].Count);

		//adds one chunk to the end of the other.
		Vector3 move = loaded[loaded.Count -1].transform.position + 
			v2v3(loaded[loaded.Count -1].GetComponent<BoxCollider2D>().offset) +
			   v2v3(new Vector2(loaded[loaded.Count -1].GetComponent<BoxCollider2D>().size.x,0))/2 ;
		print("Adding");
		loaded.Add(Instantiate(tiers[loadtier][loadnum],Vector3.zero,Quaternion.identity));
		

		move +=	-v2v3(loaded[loaded.Count -1].GetComponent<BoxCollider2D>().offset) +
			   v2v3(new Vector2(loaded[loaded.Count -1].GetComponent<BoxCollider2D>().size.x,0))/2 ;
		loaded[loaded.Count -1].transform.position = move;
		
		loaded[loaded.Count -1].SetActive(true);
		chunksLoaded++;

	}
	
	// Update is called once per frame
	void Update () 
	{

		if(camPos.position.magnitude + loadDistance > (loaded[loaded.Count -1].transform.position + 
			v2v3(loaded[loaded.Count -1].GetComponent<BoxCollider2D>().offset) +
			   v2v3(loaded[loaded.Count -1].GetComponent<BoxCollider2D>().size)/2).magnitude) 
			   {
				   print(loaded.Count);
				   loadChunk();
			   }
		if(camPos.position.magnitude - deleteDistance > (loaded[0].transform.position + 
			v2v3(loaded[0].GetComponent<BoxCollider2D>().offset) +
			   v2v3(loaded[0].GetComponent<BoxCollider2D>().size)/2).magnitude) 
			   {
				   Destroy(loaded[0]);
				   loaded.RemoveAt(0);
			   }
	}
}
