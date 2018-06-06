using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeBullet : MonoBehaviour {
    public float speed;
    public GameObject canvas;
    float timeLeft = 3f;
    // Use this for initialization
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        this.transform.parent = canvas.transform;
        //this.transform.rotation = new Quaternion(0,0,90,0);
        speed = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //this.transform.rotation = new Quaternion(0, 0, 90, 0);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - speed, this.transform.position.z);

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Destroy(gameObject);
        }

    }

}
