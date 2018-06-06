using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScoll : MonoBehaviour {

    public float speed = 0.6f;
	
    // Update is called once per frame
	void Update ()
    {
       Vector2 offset = new Vector2(Time.time * speed, 0f);
       this.GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
