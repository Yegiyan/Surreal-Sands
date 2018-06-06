using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class awesomeBar : MonoBehaviour {
    public int health = 3;
    public Sprite objImage;
    public Sprite barrel1;
    public Sprite barrel2;
    public Sprite barrel3;
	// Use this for initialization
	void Start () {
        objImage = this.gameObject.GetComponent<Image>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
		if(health == 3)
        {
            objImage = barrel1;
        }
        if(health == 2)
        {
            objImage = barrel2;
        }
        if(health == 1)
        {
            objImage = barrel3;
        }
	}
}
