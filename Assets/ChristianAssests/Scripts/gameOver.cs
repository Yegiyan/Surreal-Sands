using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        //print("COLLIDED");
        //print("HERRE" + other.gameObject.name);
        if (other.gameObject.name == "snake")
        {
            GameObject.Find("Over_0").GetComponent<mainMenuJump>().BringUpMenu();
            GameObject.Find("Over_0").GetComponent<mainMenuJump>().MasterReset = true;
            //gameOver = true;
            //print("OKKK");
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
