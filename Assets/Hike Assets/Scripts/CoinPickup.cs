using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinPickup : MonoBehaviour
{

	private AudioSource audioSource;
	public AudioClip sound;
	public AudioClip scrollSpawn;
	public AudioClip scrollSound;

	public int coinsNeeded = 4;
	public int coinsCollected = 0;

	public GameObject scroll;
	public GameObject Menu;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		scroll = GameObject.Find("Scroll");
		scroll.GetComponent<SpriteRenderer>().enabled = false;
		scroll.GetComponent<BoxCollider2D>().enabled = false;
		Menu = GameObject.Find("StageIsComplete_0");
		GameObject.Find("CountdownTimer").GetComponent<Text>().enabled = false;
		GameObject.Find("Number1").GetComponent<Image>().enabled = false;
		GameObject.Find("Number2").GetComponent<Image>().enabled = false;
		GameObject.Find("Number3").GetComponent<Image>().enabled = false;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Coin")
		{
			coinsCollected++;
			audioSource = GetComponent<AudioSource>();
			audioSource.clip = sound;
			audioSource.Play();
			if (coinsCollected == coinsNeeded)
			{
				audioSource = GetComponent<AudioSource>();
				audioSource.clip = scrollSpawn;
				audioSource.Play();
				scroll.GetComponent<SpriteRenderer>().enabled = true;
				scroll.GetComponent<BoxCollider2D>().enabled = true;
			}
			if (coinsCollected > coinsNeeded)
			{
				audioSource = GetComponent<AudioSource>();
				audioSource.clip = sound;
				audioSource.Play();
				scroll.GetComponent<SpriteRenderer>().enabled = true;
				scroll.GetComponent<BoxCollider2D>().enabled = true;
			}
		}
		if (col.gameObject.tag == "Scroll")
		{
			audioSource = GetComponent<AudioSource>();
			audioSource.clip = scrollSound;
			audioSource.Play();
			GameObject.Find("CombinationPrefab(Clone)").GetComponent<FinalCombination>().SetHasNumberTrue();
			scroll.GetComponent<SpriteRenderer>().enabled = false;
			scroll.GetComponent<BoxCollider2D>().enabled = false;
			//Destroy(GameObject.FindGameObjectWithTag("Scroll"));
		}
		if(col.gameObject.tag == "Door")
		{
			audioSource.mute = !audioSource.mute;
			GameObject.Find("CountdownTimer").GetComponent<Text>().enabled = true;
			Menu.GetComponent<NextStage>().BringUpMenu();
		}
	}
}





