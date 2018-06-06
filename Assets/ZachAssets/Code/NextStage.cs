using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NextStage : MonoBehaviour {

    public string sceneName;
    public bool MasterReset = false;
    public GameObject WholeGame;
  
    
    void Awake()
    {
        if(SceneManager.GetActiveScene().name == "CubeLevel")
        {
            sceneName = "ZachScene";
        }
        else if(SceneManager.GetActiveScene().name == "ZachScene")
        {
            sceneName = "ThirdScene";
        }
       
     
        WholeGame = GameObject.Find("Game");
    }


    IEnumerator DelaySceneChange()
    {
        WholeGame.SetActive(false); //turn off scene
        yield return new WaitForSeconds(1.25f);
        MasterReset = true;

    }

    public void BringUpMenu()
    {
        GameObject.Find("Over_0").GetComponent<mainMenuJump>().locked = true;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true; //Turn on Renderer
            if (GameObject.Find("CombinationPrefab(Clone)").GetComponent<FinalCombination>().HasSymbol && SceneManager.GetActiveScene().name == "ZachScene")
            {

            GameObject.Find("CountdownTimer").GetComponent<Text>().text = "Hint:"; //GameObject.Find("CombinationPrefab(Clone)").GetComponent<FinalCombination>().color.ToString();
            GameObject.Find("CountdownTimer").GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            if (GameObject.Find("CombinationPrefab(Clone)").GetComponent<FinalCombination>().symbol == "Hieroglyphic1")
            {
                GameObject.Find("Symbol1").GetComponent<Image>().enabled = true;
            }
            else if (GameObject.Find("CombinationPrefab(Clone)").GetComponent<FinalCombination>().symbol == "Hieroglyphic2")
            {
                GameObject.Find("Symbol2").GetComponent<Image>().enabled = true;
            }
            else if (GameObject.Find("CombinationPrefab(Clone)").GetComponent<FinalCombination>().symbol == "Hieroglyphic3")
            {
                GameObject.Find("Symbol3").GetComponent<Image>().enabled = true;
            }

        }
            else if(GameObject.Find("CombinationPrefab(Clone)").GetComponent<FinalCombination>().HasNumber && SceneManager.GetActiveScene().name == "CubeLevel")
        {

            GameObject.Find("CountdownTimer").GetComponent<Text>().text = "Hint:"; //GameObject.Find("CombinationPrefab(Clone)").GetComponent<FinalCombination>().color.ToString();
            GameObject.Find("CountdownTimer").GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            if (GameObject.Find("CombinationPrefab(Clone)").GetComponent<FinalCombination>().number == "0")
            {
                GameObject.Find("Number3").GetComponent<Image>().enabled = true;
            }
            else if (GameObject.Find("CombinationPrefab(Clone)").GetComponent<FinalCombination>().number == "1")
            {
                GameObject.Find("Number2").GetComponent<Image>().enabled = true;
            }
            else if (GameObject.Find("CombinationPrefab(Clone)").GetComponent<FinalCombination>().number == "2")
            {
                GameObject.Find("Number1").GetComponent<Image>().enabled = true;
            }

        }
			
		    else
              {
                GameObject.Find("CountdownTimer").GetComponent<Text>().text = "";
              }
        StartCoroutine(DelaySceneChange());
       
              }

    void Update()
    {
      
        if (Input.GetKeyDown("space") && MasterReset)
        {
            change();
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background at the same time as the current Scene.
        //This is particularly good for creating loading screens. You could also load the Scene by build //number.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        //Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }


    public void change()
    {
        StartCoroutine(LoadYourAsyncScene());
        // SceneManager.LoadScene(sceneName);
    }
}
