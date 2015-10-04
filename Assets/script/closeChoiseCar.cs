using UnityEngine;
using System.Collections;

public class closeChoiseCar : MonoBehaviour {

    public GameObject disableThis;
    
    
    
    public void OnDisable() 
    {
        disableThis.SetActive(false);
    }
}
