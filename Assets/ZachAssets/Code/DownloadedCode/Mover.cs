using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public Waypoint[] wayPoints = new Waypoint[13];
    private Waypoint currentWaypoint;

    private int currentIndex = 0;
    public float speed = 3f;
    private float speedStorage = 0;

    // Always true at the beginning because the moving object will always move towards the first waypoint
    public bool inReverse = true;
    public bool isCircular = false;
    private bool isWaiting = false;

    public GameObject master;

    void Awake()
    {
        master = GameObject.Find("Level2GameMaster");
        if (this.tag== "Scroll")
        {
            for (int i = 0; i < 13; i++)
            {
                wayPoints[i] = GameObject.Find("sWaypoint" + i).GetComponent<Waypoint>();
            }
        }

        else
        {
            for (int i = 0; i < 13; i++)
            {
                wayPoints[i] = GameObject.Find("bWaypoint" + i).GetComponent<Waypoint>();
            }
        }

        if (wayPoints.Length > 0)
        {
            currentWaypoint = wayPoints[0];
        }
    }



    /**
	 * Update is called once per frame
	 * 
	 */
    void FixedUpdate()
    {
        if (currentWaypoint != null && !isWaiting)
        {
            
            if (this.gameObject.tag == "Scroll")
            {
                if(master.GetComponent<GameMasterScript>().min < 1f && master.GetComponent<GameMasterScript>().sec < 30f)
                MoveTowardsWaypoint();
            }
            else
            {
                MoveTowardsWaypoint();
            }
        }
    }



    /**
	 * Pause the mover
	 * 
	 */
     /*
    void Pause()
    {
        isWaiting = !isWaiting;
    }
    */



    /**
	 * Move the object towards the selected waypoint
	 * 
	 */
    private void MoveTowardsWaypoint()
    {
        // Get the moving objects current position
        Vector3 currentPosition = this.transform.position;

        // Get the target waypoints position
        Vector3 targetPosition = currentWaypoint.transform.position;

        // If the moving object isn't that close to the waypoint
        if (Vector3.Distance(currentPosition, targetPosition) > .1f)
        {

            // Get the direction and normalize
            Vector3 directionOfTravel = targetPosition - currentPosition;
            directionOfTravel.Normalize();

            //scale the movement on each axis by the directionOfTravel vector components
            this.transform.Translate(
                directionOfTravel.x * speed * Time.deltaTime,
                directionOfTravel.y * speed * Time.deltaTime,
                directionOfTravel.z * speed * Time.deltaTime,
                Space.World
            );
        }
        else
        {

            // If the waypoint has a pause amount then wait a bit
            /*
            if (currentWaypoint.waitSeconds > 0)
            {
                Pause();
                Invoke("Pause", currentWaypoint.waitSeconds);
            }
            */

            // If the current waypoint has a speed change then change to it
            if (currentWaypoint.speedOut > 0)
            {
                speedStorage = speed;
                speed = currentWaypoint.speedOut;
            }
            else if (speedStorage != 0)
            {
                speed = speedStorage;
                speedStorage = 0;
            }

            NextWaypoint();
        }
    }


    /**
	 * Work out what the next waypoint is going to be
	 * 
	 */
    private void NextWaypoint()
    {
        if (isCircular)
        {
                if (currentIndex < 12)
                    currentIndex = (currentIndex == 0) ? wayPoints.Length - 1 : currentIndex - 1;
        }
        
        else
        {

            // If at the start or the end then reverse
            if ((!inReverse && currentIndex + 1 >= wayPoints.Length) || (inReverse && currentIndex == 0))
            {
               // inReverse = !inReverse;
            }
            if (currentIndex < 12)
                currentIndex = (!inReverse) ? currentIndex + 1 : currentIndex - 1;

        }
     
        currentWaypoint = wayPoints[currentIndex];
    }
}
