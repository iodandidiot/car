using UnityEngine;
using System.Collections;

public class start : MonoBehaviour {
    public Sprite[] mySkin;
    public GameObject gamemachine;
    public GameObject deleteStol;
    public Camera scaleCamera;
	
        // Use this for initialization
	void Start () {
        SpriteRenderer thisRend = GetComponent<SpriteRenderer>();
        switch (PlayerPrefs.GetString("Car"))
        {
            case "red":
                thisRend.sprite = mySkin[0];
                break;
            case "black":
                thisRend.sprite = mySkin[1];
                break;
            case "gonochnay":
                thisRend.sprite = mySkin[2];
                break;
            case "mini":
                thisRend.sprite = mySkin[3];
                break;
            default:
                thisRend.sprite = mySkin[0];
                break;
        }
	}
    

	// Update is called once per frame
	public void  ScaleMode()
    {
        Destroy(deleteStol.gameObject);
    }
    
    public void startGame () 
    {
        gamemachine.SetActive(true);
        
        Destroy(gameObject);

	}
}
