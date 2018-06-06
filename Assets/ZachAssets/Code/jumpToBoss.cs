using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class jumpToBoss : MonoBehaviour
{

    public string bossFight;
    public bool MasterReset = false;
    public GameObject WholeGame;
    // Use this for initialization
    void Awake()
    {
        WholeGame = GameObject.Find("Game");
        bossFight = "bossFight";
    }

    IEnumerator Delay()
    {
        WholeGame.SetActive(false); //turn off scene
        yield return new WaitForSeconds(1.25f);
        MasterReset = true;

    }

    public void BringUpMenu()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true; //Turn on Renderer
        this.gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(Delay()); //Allows for the Jump Back to the Menu
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
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(bossFight);

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
