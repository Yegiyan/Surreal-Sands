using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {
    public GameObject top;
    public GameObject mid;
    public GameObject bot;
    public Vector3[] pos;
    public GameObject[] badi;
    float time = .4f;
    float timeLeft = 3f;
    public GameObject enemy;
    // Use this for initialization
    void Start () {
        pos = new Vector3[3];
        pos[0] = bot.transform.position;
        pos[1] = mid.transform.position;
        pos[2] = top.transform.position;
        badi = new GameObject[5];
    }

    void spawnEnemy(int num)
    {
        Vector3 temp = pos[num];
        temp.z = 0;
        Instantiate(enemy, temp, this.transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0)
        {
            //spawnBad();
            int random = Random.Range(0, 3);
            spawnEnemy(random);
           // print("spawnmed" + random);
            timeLeft = time;
        }
	}
}
