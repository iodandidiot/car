using UnityEngine;
using System.Collections;

public class deletThis : MonoBehaviour {

    public GameObject player;
    public GameObject stolNew;
    public GameObject gener;
   
	
	// Update is called once per frame
    void LateUpdate()
    {

        if (player.transform.position.y > transform.position.y + 12)
        {
            Instantiate(stolNew, new Vector3(transform.position.x, transform.position.y + 9f * 3, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
            Generator generate=gener.GetComponent<Generator>();// Вызвали генератор препятствий
            generate.ItemsGenerate((int)transform.position.y + 9 * 3);
            
        }
	
	}

}
