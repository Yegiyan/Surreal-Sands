using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour {

    public string sceneName;

    float time;
    float change;

    bool played = false;
	// Use this for initialization
	void Awake() {
        sceneName = "MainMenu";
        time = Time.deltaTime;
        change = 3f;
	}
	
	// Update is called once per frame
	void Update () {
        change -= Time.deltaTime;
        if(change <= 1.25f && played)
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            played = true;
        }
        if(change <= 0.0f)
        {
            Change();
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


    public void Change()
    {
        StartCoroutine(LoadYourAsyncScene());
        // SceneManager.LoadScene(sceneName);
    }
}
