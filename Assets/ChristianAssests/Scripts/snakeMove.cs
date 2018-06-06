using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeMove : MonoBehaviour {
    public float maxTime = .5f;
    public float timeLeft = .5f;
    public float speed = 15f;
    public float downSpeed = 30f;
    public float xPos;
    int snakeCount;
    public float shootTime = 2;
    public float shootTimeLeft = 2;
    public GameObject bullet;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        snakeCount = this.gameObject.transform.childCount;

        shootTimeLeft -= Time.deltaTime;
        if(shootTimeLeft < 0)
        {
         
            int snake = Random.Range(0, snakeCount);
            Vector3 temp;
            temp = this.transform.GetChild(snake).position;
            temp.x = temp.x + 5;
            temp.z = 0;
            Instantiate(bullet, temp, this.transform.rotation);
            shootTimeLeft = shootTime;
        }
        if (snakeCount == 1 && GameObject.Find("CombinationPrefab(Clone)").GetComponent<FinalCombination>().HasColor == false)
        {
            GameObject.Find("StageIsComplete_0").GetComponent<thirdSceneDone>().BringUpMenu();
        }

        if(snakeCount == 0)
        {
            GameObject.Find("StageIsComplete_0").GetComponent<thirdSceneDone>().BringUpMenu();
        }
        xPos = this.gameObject.transform.position.x;
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0f)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + speed, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            timeLeft = maxTime;
        }
        if(this.gameObject.transform.position.x >= 596)
        {
            speed = speed * -1;
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x , this.gameObject.transform.position.y - downSpeed, this.gameObject.transform.position.z);
            this.gameObject.transform.position = new Vector3(595, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }
        if (this.gameObject.transform.position.x <= 130)
        {
            speed = speed * -1;
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - downSpeed, this.gameObject.transform.position.z);
            this.gameObject.transform.position = new Vector3(131, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }
    }
}
