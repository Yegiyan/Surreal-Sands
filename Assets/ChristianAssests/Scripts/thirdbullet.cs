using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdbullet : MonoBehaviour {
    public float speed;
    public GameObject canvas;
    float timeLeft = 3f;
    // Use this for initialization
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        this.transform.parent = canvas.transform;
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x , this.transform.position.y + speed, this.transform.position.z);
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //print("Collided");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Snake")
        {
            Destroy(other.gameObject);
            if (other.name == "scroll")
            {
                GameObject.Find("rip").GetComponent<AudioSource>().Play();
                GameObject.Find("CombinationPrefab(Clone)").GetComponent<FinalCombination>().SetHasColorTrue();
            }
            GameObject.Find("snakes").GetComponent<snakeMove>().speed = GameObject.Find("snakes").GetComponent<snakeMove>().speed * 1.04f;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("2dtirgg");
    }

}
