using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuJump : MonoBehaviour {
    public string sceneName;

    public bool MasterReset = false;
    public bool locked = false;

    public GameObject carriedGameMaster;
    public GameObject WholeGame;

    public bool stopMusic = false;

	void Awake ()
    {
        carriedGameMaster = GameObject.Find("CombinationPrefab(Clone)");
        sceneName = "MainMenu";
        WholeGame = GameObject.Find("Game");
	}

    IEnumerator Delay()
    {
        WholeGame.SetActive(false); //turn off scene
        yield return new WaitForSeconds(1.25f);
        MasterReset = true;

    }

    public void BringUpMenu()
    {
        if (!locked)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true; //Turn on Renderer
            if (!stopMusic)
            {
                stopMusic = true;
                this.gameObject.GetComponent<AudioSource>().Play();
            }

           StartCoroutine(Delay()); //Allows for the Jump Back to the Menu
          
        }
    }


	void Update ()
    {
      
		if(Input.GetKeyDown("space") && MasterReset)
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
		// OBJECT REFERENCE NOT SET TO AN INSTANCE OF AN OBJECT YA BLYATS -hike 10:41pm 3/28/18
        carriedGameMaster.GetComponent<FinalCombination>().Reset();
        StartCoroutine(LoadYourAsyncScene());
        // SceneManager.LoadScene(sceneName);
    }
}
