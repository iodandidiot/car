using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	//Генерирует препятствия для игрока

    public GameObject velositu;
    public GameObject[] items;
    public GameObject player;
    public GameObject stolNew;


    public void ItemsGenerate(int yItems)
    {
        int RItems = MyRand(items.Length);
        if (items[RItems] == velositu && player.GetComponent<Rigidbody2D>().velocity.y<15)
        {
            Instantiate(items[RItems], new Vector3(MyRand((int)player.transform.position.x - 3, (int)player.transform.position.x + 3), yItems + MyRand(10), transform.position.z), Quaternion.identity);
            return;
        }
        else
        {
            if (items[RItems] != velositu)
            {
                Instantiate(items[RItems], new Vector3(MyRand(13, -10), yItems + MyRand(8), transform.position.z), Quaternion.identity);
            }
           
        }
		
        
	}
	int MyRand(int i,int j)
	{
		return Random.Range (i, j);
	}
    int MyRand(int i)
    {
        return Random.Range(0, i);
    }
}