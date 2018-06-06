using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdSceneMove : MonoBehaviour {
    public float speed = 7f;

    bool isRight = false;
    bool isLeft = false;
    bool isStill = true;
    public float x;
    public int player_ammo = 1;
    public float timeLeft = .5f;
    public float time = .5f;
    public GameObject bullet;
    public bool gameOver = false;
	// Use this for initialization
	void Start () {
        
	}

    private void OnTriggerEnter(Collider other)
    {
        //print("HERRE" + other.gameObject.name);
        if (other.gameObject.tag == "Snake")
        {
            GameObject.Find("Over_0").GetComponent<mainMenuJump>().BringUpMenu();
            GameObject.Find("Over_0").GetComponent<mainMenuJump>().MasterReset = true;
            gameOver = true;
            //print("OKKK");
        }
    }
    // Update is called once per frame
    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0 && player_ammo < 2)
        {
            player_ammo++;
            timeLeft = time;
        }

        if (Input.GetKeyDown("space") && player_ammo > 0)
        {
            player_ammo--;
            this.GetComponent<AudioSource>().Play();
            Vector3 temp;
            temp = this.transform.position;
            temp.x = temp.x + 5;
            temp.z = 0;
            Instantiate(bullet, temp, this.transform.rotation);
        }


            x = this.transform.position.x;
        if (Input.GetKey("d") && isLeft == false && this.gameObject.transform.position.x < 635)
        {
            isRight = true;
            isLeft = false;

        }
        else if (Input.GetKey("a") && this.gameObject.transform.position.x > -86)
        {
            isRight = false;
            isLeft = true;
        }

        if(this.gameObject.transform.position.x > 635)
        {
            isRight = false;
        }
        if(this.gameObject.transform.position.x < -86)
        {
            isLeft = false;

        }

        if (Input.GetKey("d") == false)
        {
            isRight = false;
        }
        if (Input.GetKey("a") == false)
        {
            isLeft = false;
        }
	}



    private void FixedUpdate()
    {
        if (isRight)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + speed, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }
        if (isLeft)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - speed, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }

    }
}
