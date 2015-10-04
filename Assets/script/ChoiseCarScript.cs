using UnityEngine;
using System.Collections;

public class ChoiseCarScript : MonoBehaviour {

    public string carName;
    public GameObject[] other;
    void Awake() 
    {
        if (!PlayerPrefs.HasKey("Car"))
        {
            PlayerPrefs.SetString("Car", "red");
            if(carName=="red")
            {
                Scale();
            }
        }
        if (PlayerPrefs.GetString("Car") == carName )
        {
            Scale();
        }
    }
    void OnMouseDown() 
    {
        PlayerPrefs.SetString("Car", carName);
        Scale();
    }
    void Scale()
    {
        for (int i = 0; i < other.Length; i++)
        {
            other[i].transform.localScale = new Vector3(10, 20, other[i].transform.localScale.z);
        }
        transform.localScale=new Vector3 (15,30,transform.localScale.z);
    }


}
