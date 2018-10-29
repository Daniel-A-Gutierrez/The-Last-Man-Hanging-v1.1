using UnityEngine;
using System.Collections;
/*so i need a few numbers . i need the width of the layer in pixels and in gamespace, i need the leftmost 
 coordinate of it and the left and rightmost coordinates of the camera view, and i need the coordinates of the
 leftmost part of the layer and 1/3 way through the layer in gamespace. once i have these things this is what ill do
 set all left borders equal to the left camera border. record the initial position of the transform of the layer
 at this position. once the camera's right border has reached the 2/3 or full point of the image, reset it to 
 that initial x position*/





public class Parralax : MonoBehaviour {

    // Use this for initialization
    GameObject[] layers;
    float[] sets;
    float[] speeds;
    float[] initialx;
    float[] widths;
     public    float width0;
    float width1;
    float width2;
    public float width3;
    float width4;
    float width5;

    public float speed0;
    public float speed1;
    public float speed2;
    public float speed3;
    public float speed4;
    public float speed5;

    float set0;
    float set1;
    float set2;
    float set3;
    float set4;
    float set5;

    GameObject mainCamera;

    int I;
    void Start()
    {
        int childCount = transform.childCount;
        Vector3 mc = GameObject.FindWithTag("MainCamera").transform.position;
        transform.position = new Vector3(mc.x, mc.y, transform.position.z);
        widths = new float[] { width0, width1, width2, width3, width4, width5 };
        speeds = new float[] { speed0, speed1, speed2, speed3, speed4, speed5 };
        layers = new GameObject[childCount];
        initialx = new float[childCount];
        sets = sets = new float[childCount];
        I = 0;
        layers = GameObject.FindGameObjectsWithTag("BackgroundLayer");
        GameObject[] placeholder = new GameObject[layers.Length];
        for (int i = 0; i < layers.Length; i++)
        {
            initialx[I] = transform.GetChild(I).localPosition.x;
            I++;
            string lastChar = layers[i].transform.name.Substring(layers[i].transform.name.Length - 1); // for some reason the order is 3 2 0 1
            int place = int.Parse(lastChar);
            placeholder[place] = layers[i];
        }
        layers = placeholder;

        I--;
        //print("Object name " + layers[I].gameObject.ToString());
        //print("sprite is null " + layers[I].GetComponent<SpriteRenderer>().sprite == null);
        //print("pixel width output " + layers[I].GetComponent<SpriteRenderer>().sprite.rect.width/ layers[I].GetComponent<SpriteRenderer>().sprite.pixelsPerUnit);
        //print("world width output " + layers[I].GetComponent<BoxCollider2D>().size * layers[I].transform.localScale.x);
        //print("Rect output " + layers[I].GetComponent<SpriteRenderer>().sprite.rect);
        //print("Rect output " + layers[I].GetComponent<SpriteRenderer>().sprite.rect);
        //print("Pixels per unity output " + layers[I].GetComponent<SpriteRenderer>().sprite.pixelsPerUnit);
        //print("Camera rect " + GameObject.FindWithTag("MainCamera").GetComponent<Camera>().rect);
        //print("Camera ortho size " + GameObject.FindWithTag("MainCamera").GetComponent<Camera>().orthographicSize);
        //print("Camera aspect ratio " + GameObject.FindWithTag("MainCamera").GetComponent<Camera>().aspect);
        //print("Camera true borders in world space " + -GameObject.FindWithTag("MainCamera").GetComponent<Camera>().orthographicSize *
        //    GameObject.FindWithTag("MainCamera").GetComponent<Camera>().rect.width/2 );


        I = 0;
        foreach (GameObject go in layers)
        {
            //print(go.GetComponent<BoxCollider2D>().size.x);

            widths[I] = go.GetComponent<BoxCollider2D>().size.x * go.transform.localScale.x;// THIS CAN CAUSE PROBLEMS
            sets[I] = widths[I] * 1 / 2;
            I++;
        }
        I--;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
	void Awake()
    {
        int childCount = transform.childCount;
        Vector3 mc = GameObject.FindWithTag("MainCamera").transform.position;
        transform.position = new Vector3(mc.x, mc.y, transform.position.z);
        widths = new float[childCount];
        speeds = new float[] { speed0, speed1, speed2, speed3, speed4, speed5 };
        layers = new GameObject[childCount];
        initialx = new float[childCount];
        sets = sets = new float[childCount];
        layers = GameObject.FindGameObjectsWithTag("BackgroundLayer");
        GameObject[] placeholder = new GameObject[layers.Length];
        for (int i = 0; i < layers.Length; i++)
        {
            initialx[i] = transform.GetChild(i).localPosition.x;
            string lastChar = layers[i].transform.name.Substring(layers[i].transform.name.Length - 1); // for some reason the order is 3 2 0 1
            int place = int.Parse(lastChar);
            placeholder[place] = layers[i];
        }
        layers = placeholder;

        for(int i = 0; i < layers.Length; i ++)
        {

            widths[i] = layers[i].GetComponent<BoxCollider2D>().size.x * layers[i].transform.localScale.x;// THIS CAN CAUSE PROBLEMS
            sets[i] = widths[i] * 1 / 2;
        }
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
	// Update is called once per frame
	void Update ()
    {
        GameObject mc = mainCamera;
        transform.position = new Vector3(mc.transform.position.x, mc.transform.position.y, transform.position.z);
        for (int i = 0; i < layers.Length; i++)
        {
            
            layers[i].transform.localPosition = new Vector2(layers[i].transform.localPosition.x -
                speeds[i] * mc.GetComponent<CameraScroll>().speed * Time.deltaTime, layers[i].transform.localPosition.y);
            if(initialx[i] - layers[i].transform.localPosition.x  >= sets[i])
            {
                layers[i].transform.localPosition = new Vector2(initialx[i],0);
            }
        }

    }
}
