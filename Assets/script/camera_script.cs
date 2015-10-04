using UnityEngine;
using System.Collections;

public class camera_script : MonoBehaviour {

	
    public GameObject player;

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x , player.transform.position.y,-35);
    }
}
