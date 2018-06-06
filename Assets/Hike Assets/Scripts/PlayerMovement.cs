using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed;
	public float jumpSpeed;
	public bool isGrounded;
	public bool canJump;

	Rigidbody2D rb;

	public Animator anim;
	SpriteRenderer spriteRenderer;
	private AudioSource audioSource;
	public AudioClip sound;
	public AudioClip hitSound;

	public int Lives = 3;
	public GameObject Heart1, Heart2, Heart3, Menu;

	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
		audioSource = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();

		Heart1 = GameObject.Find("Heart1");
		Heart2 = GameObject.Find("Heart2");
		Heart3 = GameObject.Find("Heart3");
	}

	 public void OnTriggerEnter(Collider col)
	{
        
        if(col.gameObject.tag == "Slime" || col.gameObject.tag == "Snake" || col.gameObject.tag == "Boot")
        {
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
            else if( Lives < 3)
            {
                Heart3.GetComponent<SpriteRenderer>().enabled = false;
			}
        }

    }

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.transform.tag == "Grass" || col.transform.tag == "Dirt" || col.transform.name == "Grass" || col.transform.name == "Dirt")
		{
			isGrounded = true;
			canJump = true;
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.transform.tag == "Grass" || col.transform.tag == "Dirt" || col.transform.name == "Grass" || col.transform.name == "Dirt")
		{
			isGrounded = false;
			canJump = false;
		}
	}

	void LateUpdate ()
	{

		// Move Left
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			if (spriteRenderer.flipX == false)
			{
				spriteRenderer.flipX = true;
			}
			rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
			anim.SetFloat("Speed", 1);
		}

		// Move Right
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			if (spriteRenderer.flipX == true)
			{
				spriteRenderer.flipX = false;
			}
			rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
			anim.SetFloat("Speed", 1);
		}

		// Stop moving once A is released
		if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
		{
			rb.velocity = new Vector2(0, rb.velocity.y);
			anim.SetFloat("Speed", 0);
		}

		// Stop moving once D is released
		if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
		{
			rb.velocity = new Vector2(0, rb.velocity.y);
			anim.SetFloat("Speed", 0);
		}
	}

	void Update()
	{
		// Jump
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
			audioSource = GetComponent<AudioSource>();
			audioSource.clip = sound;
			audioSource.Play();
		}
	}
}
