using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyToggle : MonoBehaviour {

    public Toggle a;
    public Toggle b;
    public bool l = false;
	// Use this for initialization
	void Start () {
		
	}
	public void ImTRIGGERED()
    {
        a.isOn = false; b.isOn = false;
    }
	// Update is called once per frame
	void Update () {
        if (this.gameObject.GetComponent<Toggle>().isOn && !l)
        {
            l = true;
            a.isOn = false;
            b.isOn = false;

        }
        else
        {
            l = false;
        }
	}
}
