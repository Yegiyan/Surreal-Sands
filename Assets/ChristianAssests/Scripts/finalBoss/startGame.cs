using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startGame : MonoBehaviour {
    public float timeLeft = 8;
    public float time = 8; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            int temp = (int)timeLeft;
            this.GetComponent<Text>().text = "Starts in: " + temp.ToString();
        }
        if(timeLeft <= 0)
        {
            GameObject.Find("final boss").GetComponent<bossBulletSpawn>().enabled = true;
            GameObject.Find("player").GetComponent<bossPlayer>().enabled = true;
            //GameObject.Find("player").GetComponent<rotateAround>().enabled = true;
        }
    }
}
