using UnityEngine;
using System.Collections;

public class button_up_2 : MonoBehaviour
{

    public GameObject player;
    void FixedUpdate() 
    { 
        if (Input.GetKeyDown(KeyCode.RightArrow) )
        {
            Mouse();
        }
    } 

    public void Mouse()
    {
        print("Is click");
        
        player.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, player.transform.rotation.eulerAngles.z + 15), Time.time * 10);
        

        
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, player.GetComponent<Rigidbody2D>().velocity.y);
        
    
    }

}
