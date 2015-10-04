using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadNewLevel : MonoBehaviour {


    void OnMouseDown() 
    {
        ClickNewLevel();
    }

    public void ClickNewLevel()
    {
        Application.LoadLevel("scene1");
    }
}
