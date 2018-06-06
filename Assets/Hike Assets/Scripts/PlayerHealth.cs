using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int Lives = 3;
	public GameObject Heart1, Heart2, Heart3, Menu;

	private AudioSource audioSource;
	public AudioClip sound;

	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		Heart1 = GameObject.Find("Heart1");
		Heart2 = GameObject.Find("Heart2");
		Heart3 = GameObject.Find("Heart3");
		Menu = GameObject.Find("Over_0");
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Slime" || col.gameObject.tag == "Boot" || col.gameObject.tag == "Snake")
		{
			audioSource = GetComponent<AudioSource>();
			audioSource.clip = sound;
			audioSource.Play();
			Lives--;
			if (Lives < 1)
			{
				Heart1.GetComponent<SpriteRenderer>().enabled = false;
				Menu.GetComponent<mainMenuJump>().BringUpMenu();
			}
			else if (Lives < 2)
			{
				Heart2.GetComponent<SpriteRenderer>().enabled = false;
			}
			else if (Lives < 3)
			{
				Heart3.GetComponent<SpriteRenderer>().enabled = false;
			}
		}
	}
}
