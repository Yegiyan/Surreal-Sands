using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMasterScript : MonoBehaviour {
   
   public float startinTime = 59f;
   
   public float min;
   public float sec;
   public Text HUD;

	
	void Awake ()
    {
       HUD = GameObject.Find("CountdownTimer").GetComponent<Text>();
      
    }
	
	// Update is called once per frame
	void Update () {
       
        startinTime -= Time.deltaTime;
      
        min = Mathf.Floor(startinTime / 60);
        sec = startinTime % 60;
        
        if (sec < 10)
        {
            HUD.text = "0" + min.ToString() + " : 0" + ((int)sec).ToString();
        }
        else
        {
            HUD.text = "0" + min.ToString() + " : " + ((int)sec).ToString();
        }
        if(startinTime < 1f)
        {
            GameObject.Find("StageIsComplete_0").GetComponent<NextStage>().BringUpMenu();
        }
	}
}
