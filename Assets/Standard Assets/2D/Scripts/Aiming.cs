using UnityEngine;
using System.Collections;

public class Aiming : MonoBehaviour
{
    float h = 0f;
    float v = 0f;
    GameObject player;
    Platformer2DUserControl control;
    // Use this for initialization
    void Start()
    {
        player = transform.parent.gameObject;
        control = player.GetComponent<Platformer2DUserControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (control.hAim != 0f)
        {
            h = control.hAim;
        }
        if (control.vAim != 0f)
        {
            v = control.vAim;
        }

        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, Mathf.Atan2(-h, -v) * Mathf.Rad2Deg);

        if (Input.GetKeyDown("joystick 1 button 0"))
        {
            print("Horizontal:" + h);
            print("Vertical: " + v);
        }
    }
    void LateUpdate()
    {
        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, Mathf.Atan2(-h, -v) * Mathf.Rad2Deg);

    }
    public Vector2 getAimVector()
    {
        return new Vector2(h, -v);
    }
}