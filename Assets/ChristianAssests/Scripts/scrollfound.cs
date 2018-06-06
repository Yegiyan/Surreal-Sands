using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollfound : MonoBehaviour {
    public GameObject combo;
	// Use this for initialization
	void Start () {

	}
	void foundScroll()
    {
        combo.GetComponent<FinalCombination>().SetHasColorTrue();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
