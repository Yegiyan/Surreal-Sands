using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GroundObjectSpawner : MonoBehaviour {

    public List<GameObject> movingObject = new List<GameObject>(); //Object to be throw at the player
    
    // Grabs prefab in the editor
    public GameObject RockPrefab;
    public GameObject CactusPrefab;
    public GameObject WeedPrefab;
    public GameObject BombPrefab;
    public GameObject horse;

    public Animator anim;

    //checks if object is moving towards player
    public bool ObjectSpawned = false; 
    public bool BombisMoving = false;
    public bool timeON = false;
       
    Vector3 target = new Vector3(-30f, -6f, -1.5f); //Where the Objects are moving towards
    
    public int randomSpawn;

    public float step, speed;
    public float time = 1.7f;
    public float timeLeft = 1.7f;

    // Use this for initialization
    void Awake ()
    {
        horse = GameObject.Find("HorseStand");
        speed = 18f;
	}



	// Update is called once per frame
	void Update ()
    {
        if (timeON == true)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                movingObject.Add(Instantiate(BombPrefab, new Vector3(12f, 1f, -1.5f), Quaternion.identity)); //Spawns Bomb thrown at player ************
                timeLeft = time;
                timeON = false;
            }

        }

        step = speed * Time.deltaTime;

        if (!ObjectSpawned && horse.GetComponent<HorseScript>().PlayerHasControl)
        {
            if (movingObject.Count < 1)
            {
                randomSpawn = Random.Range(0, 4);

                if (randomSpawn == 0) movingObject.Add(Instantiate(RockPrefab, new Vector3(17, -6, -1.5f), Quaternion.identity)); //Spawns Object to be moved on Plane
                else if (randomSpawn == 1) movingObject.Add(Instantiate(WeedPrefab, new Vector3(17, -6, -1.5f), Quaternion.identity)); //Spawns Object to be moved on Plane
                else if (randomSpawn == 2) //Bomb
                {
                    anim.SetTrigger("PlayingBomb");
                    BombisMoving = true;
                }
                else movingObject.Add(Instantiate(CactusPrefab, new Vector3(17, -6, -1.5f), Quaternion.identity)); //Spawns Object to be moved on Plane

                ObjectSpawned = true;
            }
        }

        if (horse.GetComponent<HorseScript>().PlayerHasControl == true && ObjectSpawned && randomSpawn != 2)
        {
            movingObject.ElementAt(movingObject.Count - 1).transform.position = Vector3.MoveTowards(movingObject.ElementAt(movingObject.Count - 1).transform.position, target, step); //Moves the spawned Object
        }
    }

   void LateUpdate()
    {
        if(randomSpawn == 2)
        {
            if ((anim.GetCurrentAnimatorStateInfo(0).IsName("BanditDefault")) && BombisMoving == true)
            {
                BombisMoving = false;
                timeON = true;
            }
        }
    }
}

