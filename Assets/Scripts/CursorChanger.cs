using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour {

	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;

	// Use this for initialization
	void Start () {
		Cursor.SetCursor(cursorTexture, Vector2.zero, cursorMode);
	}

	// Update is called once per frame
	void OnMouseEnter () {

	}
}