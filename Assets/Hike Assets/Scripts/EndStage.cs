using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndStage : MonoBehaviour
{

	public string sceneName;
	public bool MasterReset = false;
	public GameObject WholeGame;

	void Awake()
	{
		if (SceneManager.GetActiveScene().name == "CubeLevel")
		{
			sceneName = "ZachScene";
		}
		else if (SceneManager.GetActiveScene().name == "ZachScene")
		{
			sceneName = "MainMenu";
		}

		WholeGame = GameObject.Find("Game");
	}

	public void BringUpMenu()
	{
		GameObject.Find("Over_0").GetComponent<mainMenuJump>().locked = true;
		this.gameObject.GetComponent<SpriteRenderer>().enabled = true; //Turn on Renderer
		if (GameObject.Find("CombinationPrefab(Clone)").GetComponent<FinalCombination>().HasNumber)
		{
			GameObject.Find("CountdownTimer").GetComponent<Text>().text = "Hint: " + GameObject.Find("CombinationPrefab(Clone)").GetComponent<FinalCombination>().number.ToString();
		}
		else
		{
			GameObject.Find("CountdownTimer").GetComponent<Text>().text = "";
		}
		MasterReset = true;
	}

	void Update()
	{
		if (MasterReset)
		{
			WholeGame.SetActive(false); //turn off scene
		}
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
