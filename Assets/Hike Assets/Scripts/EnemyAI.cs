using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

	public float moveSpeed;
	SpriteRenderer spriteRenderer;

	void Awake ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	
	void Update ()
	{
		transform.Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Obstacle")
		{
			moveSpeed *= -1;
			if(spriteRenderer.flipX == true)
			{
				spriteRenderer.flipX = false;
			}
			else
			{
				spriteRenderer.flipX = true;
			}
		}
		if (col.gameObject.tag == "Player")
		{
			moveSpeed *= -1;
			if (spriteRenderer.flipX == true)
			{
				spriteRenderer.flipX = false;
			}
			else
			{
				spriteRenderer.flipX = true;
			}
		}
	}

}
