using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thirdSceneDone : MonoBehaviour {
    public Sprite red;
    public Sprite blue;
    public Sprite green;
    public GameObject hintText;
    public GameObject hintimage;
    // Use this for initialization
    void Start () {
		
	}
	
    public void BringUpMenu()
    {
        if(GameObject.Find("CombinationPrefab(Clone)").GetComponent<FinalCombination>().HasColor == true)
        {
            hintText.SetActive(true);
            hintimage.SetActive(true);
            if(GameObject.Find("CombinationPrefab(Clone)").GetComponent<FinalCombination>().color == "Red")
            {
                GameObject.Find("hintImage").GetComponent<Image>().sprite = red;
            }
            if (GameObject.Find("CombinationPrefab(Clone)").GetComponent<FinalCombination>().color == "Green")
            {
                GameObject.Find("hintImage").GetComponent<Image>().sprite = green;
            }
            if (GameObject.Find("CombinationPrefab(Clone)").GetComponent<FinalCombination>().color == "Blue")
            {
                GameObject.Find("hintImage").GetComponent<Image>().sprite = blue;
            }
        }
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        this.gameObject.GetComponent<NextStage>().MasterReset = true;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
