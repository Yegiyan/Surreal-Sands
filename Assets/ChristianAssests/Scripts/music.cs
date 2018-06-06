using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour {

    float starting;
    bool startedLoop = false;
	// Use this for initialization
	void Awake () {
        starting = .25f;
	}
	
	// Update is called once per frame
	void Update () {
        starting -= Time.deltaTime;
            
            if( starting <= 0.0f && !startedLoop)
            {
            startedLoop = true;
            this.gameObject.GetComponent<AudioSource>().Play();
            }    
            
	}
}
