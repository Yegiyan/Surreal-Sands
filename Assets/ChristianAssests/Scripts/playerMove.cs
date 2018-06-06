using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour {
    public GameObject top;
    public GameObject mid;
    public GameObject bot;
    public Vector3[] pos;
    public GameObject bullet;
    public int player_pos = 0;
    GameObject ammotext;
    public int player_ammo = 3;
    float time = 5f;
    float timeLeft = 5f;
    public GameObject temp;
    // Use this for initialization
    public GameObject fires;
    public GameObject prefabthingy;
    void trytomake()
    {
        try {
            temp = GameObject.Find("CombinationPrefab(Clone)");
            float test = temp.GetComponent<FinalCombination>().volume;
            //print("DID IT");
        }
        catch
        {
            Instantiate(prefabthingy, new Vector3(0, 0, 0),new Quaternion(0,0,0,0));
        }
    }


    void Start () {
        
        PlayerPrefs.SetInt("Screenmanager Resolution Width", 1024);
        PlayerPrefs.SetInt("Screenmanager Resolution Height", 576);
        PlayerPrefs.SetInt("Screenmanager Is Fullscreen mode", 0);
        fires = GameObject.Find("fires");
        fires.SetActive(false);
        ammotext = GameObject.Find("ammoText");
        pos = new Vector3[3];
        pos[0] = bot.transform.position;
        pos[1] = mid.transform.position;
        pos[2] = top.transform.position;
        this.transform.position = pos[0];
        trytomake();
    }
	
	// Update is called once per frame
	void Update () {
        ammotext.GetComponent<Text>().text = "Ammo : " + player_ammo;
        timeLeft -= Time.deltaTime;
        if(timeLeft< 0 && player_ammo < 4)
        {
            player_ammo++;
            timeLeft = time;
        }
        if (Input.GetKeyDown("w") && player_pos < 2)
        {
            this.transform.position = pos[player_pos + 1];
            player_pos++;
        }
        if (Input.GetKeyDown("s") && player_pos > 0)
        {
            this.transform.position = pos[player_pos - 1];
            player_pos--;
        }
        if (Input.GetKeyDown("space") && player_ammo >0)
        {
            player_ammo--;
            Vector3 temp;
            temp = this.transform.position;
            temp.x = temp.x + 5;
            temp.z = 0;
            Instantiate(bullet, temp, this.transform.rotation);
        }
	}
}
