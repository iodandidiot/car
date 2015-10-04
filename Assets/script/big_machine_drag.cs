using UnityEngine;
using System.Collections;

public class big_machine_drag : MonoBehaviour {
    int t = 1000;
    public Vector3 mouseClickPosition;
    public float deltaMouseY;
    public bool notClick=true;
    public int timeCheck;
    
	// Use this for initialization
    void Update () 
    {
        timeCheck -= 5;
        deltaMouseY = Input.mousePosition.y - mouseClickPosition.y;
        print(Input.mousePosition.y);
    }

    void OnMouseDown ()
    {
        if (notClick)
        {
            mouseClickPosition = Input.mousePosition;
            notClick = false;
        }
        
    }
    void OnMouseDrag () 

    {

        if (timeCheck > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + deltaMouseY / 26, transform.position.z);
        }
        
    }


}
