using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bossBulletSpawn : MonoBehaviour {

    public float time = .2f;
    public float timeLeft = .2f;
    public GameObject bullPref;
    public int bossHP = 2;
    bool madeBarrels = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (bossHP == 0)
        {
            GameObject.Find("YouWin_0").GetComponent<mainMenuJump>().BringUpMenu();
        }
        if (bossHP == 1 && madeBarrels == false)
        {
            this.GetComponent<AudioSource>().Play();
            GameObject.Find("bossHeart2").GetComponent<Image>().enabled = false;
            //print("HERHEH");
            GameObject.Find("final_bos_0 (1)").GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
            GameObject[] barrels = GameObject.FindGameObjectsWithTag("KillMe");
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Coin");
            time = .6f;
            foreach (GameObject temp in barrels)
            {
                temp.GetComponent<barrelHP>().health++;
            }
            foreach(GameObject test in bullets)
            {
                Destroy(test.gameObject);
            }
            madeBarrels = true;
        }
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0)
        {
            Instantiate(bullPref, this.transform);
            timeLeft = time;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
     
        //print("GOT HIT " + other.name);

        if(other.name == "playerBull(Clone)")
        {
            //print("YEGHOOO");
            bossHP--;
           // GameObject.Find("YouWin_0").GetComponent<mainMenuJump>().BringUpMenu();
        }

    }
}
