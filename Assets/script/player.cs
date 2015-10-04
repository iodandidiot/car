using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player : MonoBehaviour {
    public Sprite[] mySkin;
    public float VelosityY=10;
    float VelosityX;
    float delta;
    float deltaAngl;
    public GameObject stol;
    public GameObject finishImage;
    public float stolPos = 11.76f;
    public Text text;
    public Text textFinish;
    public Text textMaxScore;
    public bool right = false;
    public bool left = false;
	// Use this for initialization
	void Start () {
        textMaxScore.text = string.Format("Max Score {0}", PlayerPrefs.GetInt("Max Score"));
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
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !left)
        {
            Left();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && !right)
        {
            Right();
        }
        text.text = string.Format("{0:.#}", transform.position.y-6.15);
    }

    void FixedUpdate()
    {
       

        if (VelosityY > 0)

        {
            VelosityY -= Time.deltaTime / 2;// уменьшаем скорость со временем
            
            //if (VelosityY > VelosityX)
            //{
            //    rigidbody2D.velocity = new Vector2(VelosityX, VelosityY);//передаём скорость по осям
            //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, - deltaAngl * 12), Time.time * 10); // поворачиваем
            //}
            //else
            //{
            //    rigidbody2D.velocity = new Vector2(VelosityY, VelosityY);//передаём скорость по осям
            //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, - deltaAngl * 12), Time.time );
            //}
            GetComponent<Rigidbody2D>().velocity = new Vector2(VelosityX, VelosityY);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -deltaAngl * 12), Time.time * 10);
        }
        
        else
        {
            FinishGame();
        }
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        print("OnTriggerEnter");//finish
        if (coll.gameObject.tag == "Finish")
        {
            FinishGame();
        }
		if (coll.gameObject.tag == "Velosity") 
		{
			VelosityY+=3;
			Destroy(coll.gameObject);
		}
    }

    public void Left()//поворот налево
    {
        
        StopAllCoroutines();
        //StartCoroutine(changeVelosity(-1));
        //print("set Left");
        //left = true;
        //right = false;
        StartCoroutine(Rotate(-4));
    }

    public void Right()// поворот направо
    {
        
        StopAllCoroutines();        
        //StartCoroutine(changeVelosity(1));
        //print("set right");
        //right = true;
        //left = false;
        StartCoroutine(Rotate(4));
        
    }

    public void FinishGame()
    {
        VelosityX = 0;
        VelosityY = 0;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); //тормозим 
        finishImage.SetActive(true);
        textFinish.text = string.Format("Ваш результат - {0:.#}", transform.position.y - 6.15);
        print("Finish");
        if (PlayerPrefs.GetInt("Max Score") < (int)transform.position.y)
        {
            PlayerPrefs.SetInt("Max Score", (int)transform.position.y);
        }
        
    }
    
    //IEnumerator changeVelosity(int Ch,bool nChDist=true)
    //{
    //    float endCheck=4 - Mathf.Abs(delta);
    //    for (float i = 0; i < 4f /*&& VelosityX < 7.5 && VelosityX > -7.5*/; i += 0.1f)
    //    {
    //        VelosityX += (Ch * 0.1f);
    //        deltaAngl += (Ch * 0.1f);
    //        delta += (Ch * 0.1f);
    //        yield return new WaitForFixedUpdate();   
    //    }
        
    //    if (nChDist)
    //    {
    //        StartCoroutine(changeDistanse(Ch * (-1)));
    //    }
        
    //}
    IEnumerator changeDistanse()
    {
        float startX = transform.position.x;
        float endX = transform.position.x;
        float dX = 1.5f;

        while (Mathf.Abs(startX - endX) < dX)
        {
            endX = transform.position.x;
            yield return new WaitForFixedUpdate();
        }
        left = right = false;
        StartCoroutine(Rotate(-VelosityX));
    }
    IEnumerator Rotate(float delta)
    {
        for (int i = 0; i < Mathf.Abs(delta)*10; i++)
        {
            if (delta > 0)
            {
                right = true;
                VelosityX += 0.1f;
                deltaAngl += 0.1f;
                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0,-deltaAngl * 12), Time.time * 10);

            }
            else
            {
                left = true;
                VelosityX -= 0.1f;
                deltaAngl -= 0.1f;
                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0,-deltaAngl * 12), Time.time * 10);
            }
            yield return new WaitForFixedUpdate();
        }

        if (VelosityX != 0) StartCoroutine(changeDistanse());

        if (left) left = false;
        if (right) right = false;
    }
    
}
