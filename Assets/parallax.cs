using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour 
{
	Transform camTrans;
	Vector3 oldCamPos;
	Mesh m;
	MeshFilter mf;
	public float speed = .1f;

	// Use this for initialization
	void Start () 
	{
		camTrans = GameObject.FindGameObjectWithTag("MainCamera").transform;
		oldCamPos = camTrans.position;
		mf = GetComponent<MeshFilter>();
		m = mf.mesh;
		Vector2 [] uvs = m.uv;
		foreach(Vector2 v in uvs)
			print(v);
	}
	void Update () 
	{
		Vector3 offset = camTrans.position - oldCamPos;
		oldCamPos = camTrans.position;
		Vector2[] uvs = m.uv;

		for(int i = 0; i<uvs.Length;i++)
		{
			uvs[i].x -= speed*offset.x/transform.localScale.x;
			uvs[i].y -= speed*offset.y/transform.localScale.z;
		}

		m.uv = uvs;
	}
}
