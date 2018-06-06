using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeChanger : MonoBehaviour {
    public GameObject volume;
	// Use this for initialization
	void Start () {
        
        volume = GameObject.Find("CombinationPrefab(Clone)");
        this.gameObject.GetComponent<Slider>().value = volume.GetComponent<FinalCombination>().volume;
	}
	
	// Update is called once per frame
	void Update () {
        volume.GetComponent<FinalCombination>().volume = this.gameObject.GetComponent<Slider>().value;
	}
}
