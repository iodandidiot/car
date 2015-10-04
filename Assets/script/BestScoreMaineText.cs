using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BestScoreMaineText : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        Text thisText = GetComponent<Text>();
        thisText.text = string.Format("Max Score {0}", PlayerPrefs.GetInt("Max Score"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
