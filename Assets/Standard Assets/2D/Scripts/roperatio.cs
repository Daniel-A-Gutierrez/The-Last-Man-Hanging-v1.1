using UnityEngine;
using System.Collections;

public class roperatio : MonoBehaviour
{

    public GameObject player;
    public Vector3 grabPos;
    public float ratio;
    float movement;
    public bool taut;
    // Use this for initialization
    void Start()
    {
        //for (int i = 1; i < 5; i++)
        //{
        //    player = GameObject.Find("Player" + i);
        //    if (player != null)
        //    {
        //        break;
        //    }
        //} that would just always return player one . i made it a child anyway.
        player = transform.parent.gameObject;
        movement = 0;
        taut = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Mathf.Abs(Vector3.Distance(player.transform.position, grabPos));
        GetComponent<LineRenderer>().material.mainTextureScale = new Vector2(.001f, 1f); // so at 2, the wavelength is 1/2 the length and at .5, it is double. 
        //GetComponent<LineRenderer>().material.
        GetComponent<LineRenderer>().material.mainTextureOffset = new Vector2(0, 0);
        if(!taut)
        { 
            float scaleX = ratio;
            movement += .025f;
            GetComponent<LineRenderer>().material.mainTextureScale = new Vector2(scaleX, 1f);
            if (movement >= .5)
            {
                movement = 0;
            }
            GetComponent<LineRenderer>().material.mainTextureOffset = new Vector2(movement, 0);
        }
    }
}