using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyMove : MonoBehaviour {
    public float speed;
    public GameObject canvas;
    public Sprite deadsaloon;
    public GameObject fires;
    public Sprite en1;
    public Sprite en2;
    public Sprite en3;
    public Sprite[] spriteList;
    // Use this for initialization
    void Start () {
        spriteList = new Sprite[3];
        spriteList[0] = en1;
        spriteList[1] = en2;
        spriteList[2] = en3;
        int ranSprite = Random.Range(0, 3);
        this.gameObject.GetComponent<Image>().sprite = spriteList[ranSprite];
        fires = GameObject.Find("player").GetComponent<playerMove>().fires;
        int random = Random.Range(-6, -2);
        canvas = GameObject.Find("Canvas");
        this.transform.parent = canvas.transform;
        speed = random;
        this.transform.localScale = new Vector3(1, 1, 1);
        fires.SetActive(false);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.position = new Vector3(this.transform.position.x + speed, this.transform.position.y, this.transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "saloon")
        {
            //other.gameObject.GetComponent<AudioSource>().Play();
            Destroy(GameObject.Find("player"));
            fires.SetActive(true);
            Destroy(GameObject.Find("enemySpawner"));
            GameObject[] ene;
            ene = GameObject.FindGameObjectsWithTag("bat");
            foreach (GameObject temp in ene)
            {
                Destroy(temp);
            }
        }
    }
}
