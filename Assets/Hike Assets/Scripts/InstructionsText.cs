using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsText : MonoBehaviour
{

	public float lifeTime;

	void Start()
	{
		StartCoroutine(FadeTime());
	}

	IEnumerator FadeTime ()
	{
		yield return new WaitForSeconds(5);
		yield return new WaitForSeconds(lifeTime);
		this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1f);
		yield return new WaitForSeconds(lifeTime);
		this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.9f);
		yield return new WaitForSeconds(lifeTime);
		this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.8f);
		yield return new WaitForSeconds(lifeTime);
		this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.7f);
		yield return new WaitForSeconds(lifeTime);
		this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.6f);
		yield return new WaitForSeconds(lifeTime);
		this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
		yield return new WaitForSeconds(lifeTime);
		this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
		yield return new WaitForSeconds(lifeTime);
		this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
		yield return new WaitForSeconds(lifeTime);
		this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
		yield return new WaitForSeconds(lifeTime);
		this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.1f);
		yield return new WaitForSeconds(lifeTime);
		this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
		yield return new WaitForSeconds(lifeTime);
		Destroy(gameObject);
	}
}
