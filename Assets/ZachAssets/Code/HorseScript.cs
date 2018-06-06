using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseScript : MonoBehaviour {

    Vector3 currentPosition;
    Vector3 finalPosition = new Vector3(-7f, -5.375f, 0);

    float currentDuration, currentFraction, StartTime, TotalDistanceToDestination;

    public bool jumping = false;
    public bool PlayerHasControl = false;
 
   
    void Awake ()
    { 
        currentPosition = this.transform.position;
        StartTime = Time.time;
        TotalDistanceToDestination = Vector3.Distance(currentPosition, finalPosition);
    }

    private void FixedUpdate()
    {
        if (jumping)
        {
            this.GetComponent<Rigidbody>().AddForce(this.transform.up * 4000f);

            if (this.transform.position.y >= -2f)
            {
                jumping = false;
            }
        }

        else
        {
            this.GetComponent<Rigidbody>().AddForce(this.transform.up * -6000f);
        }  
    }
 
    void Update ()
    {
        //Lerps into frame
        if (this.transform.position != finalPosition && !PlayerHasControl)
        {
            currentDuration = Time.time - StartTime;
            currentFraction = (2 *currentDuration) / TotalDistanceToDestination;
            this.transform.position = Vector3.Lerp(currentPosition, finalPosition, currentFraction);
        }

        //Player allowed to jump
        else
        {
            PlayerHasControl = true;

            //Push Horse Up
            if ((Input.GetKeyDown("space") || Input.GetKeyDown("return")) && !jumping && this.gameObject.transform.position.y <= -2f)
            {
                this.gameObject.GetComponent<AudioSource>().Play();
                jumping = true;
            }
        }
     }
}
