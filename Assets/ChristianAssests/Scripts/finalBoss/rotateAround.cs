using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAround : MonoBehaviour {
    Vector3 rotateAxis = new Vector3(0, 0, 1);
    public float speed = 40f;
    public Transform TargetObj;
	// Use this for initialization
	void Start () {
        TargetObj = GameObject.Find("final boss").transform;
	}
    private void Update()
    {
        if(Input.GetKeyDown("left shift") || Input.GetKeyDown("right shift") )
        {
            if (this.tag == "Player")
            {
                speed = speed * -1;
            }

        }
        if (Input.GetKeyDown("a"))
        {
            if(this.tag == "Player")
            {
                speed = speed * -1;
            }
        }
        if (Input.GetKeyDown("d"))
        {
            if(this.tag == "Player")
            {
                speed = speed * -1;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
		if (TargetObj)
        {

            this.transform.RotateAround(TargetObj.transform.position, rotateAxis, speed * Time.deltaTime);
            //this.transform.LookAt(TargetObj);
        }
        else
        {
            transform.Rotate(new Vector3(
            rotateAxis.x * speed * Time.deltaTime,
            rotateAxis.y * speed * Time.deltaTime,
            rotateAxis.z * speed * Time.deltaTime));
        }
    }
}
