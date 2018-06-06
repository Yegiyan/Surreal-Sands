using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {
    public float speed;
    public GameObject canvas;
    float timeLeft = 3f;
    // Use this for initialization
    void Start () {
        canvas = GameObject.Find("Canvas");
        this.transform.parent = canvas.transform;
        speed = 5;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(this.transform.position.x + speed, this.transform.position.y, this.transform.position.z);
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Collided");
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if(GameObject.Find("player").GetComponent<playerMove>().player_ammo < 4)
        {
            GameObject.Find("player").GetComponent<playerMove>().player_ammo++;
        }
        
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("2dtirgg");
    }

}
