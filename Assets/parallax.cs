using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour 
{
	Transform camTrans;
	Vector3 oldCamPos;
	Mesh m;
	MeshFilter mf;
	public float ratio = 1f;

	// Use this for initialization
	void Start () 
	{
		camTrans = GameObject.FindGameObjectWithTag("MainCamera").transform;
		oldCamPos = camTrans.position;
		mf = GetComponent<MeshFilter>();
		m = mf.mesh;
		Vector2 [] uvs = m.uv;
		ratio = ratio/10;
	}
	void Update () 
	{
		Vector3 offset = camTrans.position - oldCamPos;
		oldCamPos = camTrans.position;
		Vector2[] uvs = m.uv;

		for(int i = 0; i<uvs.Length;i++)
		{
			uvs[i].x -= ratio*offset.x/transform.localScale.x;
			uvs[i].y -= ratio*offset.y/transform.localScale.z;
		}

		m.uv = uvs;
	}
}
