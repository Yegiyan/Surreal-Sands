using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseHealth : MonoBehaviour {

    public int Lives = 3;
    public GameObject Heart1, Heart2, Heart3, Menu;

   void Awake()
    {
        Heart1 = GameObject.Find("Heart1");
        Heart2 = GameObject.Find("Heart2");
        Heart3 = GameObject.Find("Heart3");
    }

    public void OnTriggerEnter(Collider col)
    {
        
        if(col.tag == "Obstacle" || col.tag == "Bomb")
        {
            Lives--;
            this.gameObject.GetComponent<AudioSource>().Play();
            if(Lives < 1)
            {
                Heart1.GetComponent<SpriteRenderer>().enabled = false;
                Menu.GetComponent<mainMenuJump>().BringUpMenu();
            }
            else if (Lives < 2)
            {
                Heart2.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if( Lives < 3)
            {
                Heart3.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

    }
}
