using UnityEngine;
using System.Collections;

public class deleteThisBox : MonoBehaviour {

    GameObject playerFind;
    void Awake()
    {
        playerFind = GameObject.Find("machine");
        
    }
    /*void OnCollisionEnter2D(Collision2D coll) 
    {
        if (coll.collider.tag == "box")
        {
            transform.position = new Vector2(transform.position.x+Random.Range(-5, 5), transform.position.y);
            print("Move");
            //Destroy(gameObject);
        }
    }*/
	// Update is called once per frame
	void Update () {

        if (playerFind.transform.position.y > transform.position.y + 12)
        {
            Destroy(gameObject);
        }
	}
}
