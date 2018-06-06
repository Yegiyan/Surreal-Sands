using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barrelHP : MonoBehaviour {
    public int health = 3;
    public Sprite objImage;
    public Sprite barrel1;
    public Sprite barrel2;
    public Sprite barrel3;
    // Use this for initialization
    void Start()
    {
        objImage = this.gameObject.GetComponent<Image>().sprite;
    }


    private void OnCollisionEnter(Collision collision)
    {
        //print("HERE");
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Sbullettr(Clone)" || other.gameObject.name == "Nbullettr(Clone)" || other.gameObject.name == "playerBull(Clone)")
        {
            
            Destroy(other.gameObject);
            health--;
            if (health == 0)
            {
                this.gameObject.GetComponent<AudioSource>().Play();
                this.gameObject.GetComponent<Image>().enabled = false;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                //Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 3)
        {
            health = 3;
        }
        if (health == 3)
        {
            this.gameObject.GetComponent<Image>().sprite = barrel1;
            this.gameObject.GetComponent<Image>().enabled = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        if (health == 2)
        {
            this.gameObject.GetComponent<Image>().sprite = barrel2;
            this.gameObject.GetComponent<Image>().enabled = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = true;

        }
        if (health == 1)
        {
            this.gameObject.GetComponent<Image>().sprite = barrel3;
            this.gameObject.GetComponent<Image>().enabled = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = true;

        }
    }
}
