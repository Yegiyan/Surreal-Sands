using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bossPlayer : MonoBehaviour {
    public float timeLeft = .1f;
    public float time = .1f;
    public GameObject bulletPre;
    public int health = 5;
	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Snake")
        {
            Destroy(other.gameObject);
            this.GetComponent<AudioSource>().Play();
            health--;
           
        }
    }
    // Update is called once per frame
    void Update () {

        if (health == 4)
        {
            GameObject.Find("heart5").GetComponent<Image>().enabled = false;
        }
        if (health == 3)
        {
            GameObject.Find("heart4").GetComponent<Image>().enabled = false;
        }
        if (health == 2)
        {
            GameObject.Find("heart3").GetComponent<Image>().enabled = false;
        }
        if (health == 1)
        {
            GameObject.Find("heart2").GetComponent<Image>().enabled = false;
        }


        if (health <= 0)
        {
            GameObject.Find("Over_0").GetComponent<mainMenuJump>().BringUpMenu();
        }
        timeLeft -= Time.deltaTime;
        if (Input.GetKey("space") && timeLeft < 0)
        {
            timeLeft = time;
            Instantiate(bulletPre, this.transform);
        }
	}
}
