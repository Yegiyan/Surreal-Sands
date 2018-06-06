using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBullet : MonoBehaviour {
    public float speed;
    public GameObject canvas;
    float timeLeft = 7f;
    public float xBool;
    public float yBool;
    int zBool;
    public Vector3 playerCurrentPos;
    public GameObject player;
    Transform test;
    public int rotateSpeed = 10;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("target");
        playerCurrentPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        this.gameObject.transform.parent = GameObject.Find("Canvas").transform;
        this.gameObject.transform.position = GameObject.Find("final boss").transform.position;
        xBool = Random.Range(-500f, 500f);
        yBool = Random.Range(-500f, 500f);
        canvas = GameObject.Find("Canvas");
        this.transform.parent = canvas.transform;
        //this.transform.rotation = new Quaternion(0,0,90,0);
        speed = 0;
        playerCurrentPos = new Vector3(playerCurrentPos.x + xBool, playerCurrentPos.y + yBool, playerCurrentPos.z);
    }
    void rotate()
    {
        rotateSpeed += 10;
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, (this.transform.rotation.z + rotateSpeed));
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //this.transform.rotation.Set(this.transform.rotation.x, this.transform.rotation.y, (this.transform.rotation.z + 50), this.transform.rotation.w);
        rotate();
        /*
        float finalx = speed + xBool;
        float finaly = speed + yBool;
        if(finalx < 2 && finalx > -2)
        {
            if (finalx > 0)
            {
                finalx = Random.Range(2f,5f);
            }
            if (finalx < 0)
            {
                finalx = Random.Range(-2f, -5f);
            }
        }
        else if (finaly < 2 && finaly > -2)
        {
            if (finaly > 0)
            {
                finaly = Random.Range(2f, 5f);
            }
            if (finaly < 0)
            {
                finaly = Random.Range(-2f, -5f);
            }
        }
        //this.transform.rotation = new Quaternion(0, 0, 90, 0);
        this.transform.position = new Vector3(this.transform.position.x + finalx, this.transform.position.y + finaly, this.transform.position.z);
        */
        speed = 4.5f;
        Vector3 temp = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
        this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, playerCurrentPos, speed);
        Vector3 temp2 = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        if (temp == temp2)
        {
            Destroy(this.gameObject);
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Destroy(gameObject);
        }

    }

}