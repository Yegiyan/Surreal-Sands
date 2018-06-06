using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalScript : MonoBehaviour {

    public int startingX = 0;
    public int startingY = 0;
    public int currentX, currentY;
    public GameObject selector;
    public bool moving = false;
    int selectionArea = 0;

    public enterPressed enterWasPressed;
	// Use this for initialization
	void Awake() {
        enterWasPressed = GameObject.Find("ChosenOnes").GetComponent<enterPressed>();
        currentX = startingX;
        currentY = startingY;
	}
	
    //I'm so sorry Kerney
    void MoveSelector()
    {
        if (currentX == 0)
        {
            if (currentY == 0) //Bottom Left
            {
                selectionArea = 0;
                selector.transform.position = new Vector3(-40f, -(20f), 87f);
            }
            else if (currentY == 1)//Mid Left
            {
                selectionArea = 1;
                selector.transform.position = new Vector3(-40f, 0f, 87f);
            }

            else//Top Left
            {
                selectionArea = 2;
                selector.transform.position = new Vector3(-40f, 20f, 87f);
            }
        }
        else if (currentX == 1)
        {
            if (currentY == 0) //Bottom Mid
            {
                selectionArea = 3;
                selector.transform.position = new Vector3(0f, -(20f), 87f);
            }
            else if (currentY == 1)//Mid Mid
            {
                selectionArea = 4;
                selector.transform.position = new Vector3(0f, 0f, 87f);
            }
            else if (currentY == 2)//Top Mid
            {
                selectionArea = 5;
                selector.transform.position = new Vector3(0f, (20f), 87f);
            }
            else //Enter Code Area
            {
                selectionArea = 10;
                selector.transform.position = new Vector3(0f, -40f, 87f);
            }
        }
        else
        {
             if (currentY == 0)//Bottom Right
            {
                selectionArea = 6;
                selector.transform.position = new Vector3(40f, -(20f), 87f);
            }
            else if (currentY == 1)//Mid Right
            {
                selectionArea = 7;
                selector.transform.position = new Vector3(40f, 0f, 87f);
            }
            else //Top Right
            {
                selectionArea = 8;
                selector.transform.position = new Vector3(40f, 20f, 87f);
            }

        }
        moving = false;
    }
	// Update is called once per frame
	void Update () {
        if (!moving)
        {
            if (Input.GetKeyDown("return") || Input.GetKeyDown("space"))
            {
                enterWasPressed.SwitchChoice(selectionArea);
            }
            if ((Input.GetKeyDown("a")) && currentX > 0)
            {
                moving = true;
                currentX--;
                if (currentY == -1) currentY++;
                MoveSelector();
            }
            else if ((Input.GetKeyDown("d")) && currentX < 2)
            {
                moving = true;
                currentX++;
                if (currentY == -1) currentY++;
                MoveSelector();
            }
            else if ((Input.GetKeyDown("s")) && currentY > -1)
            {
                moving = true;
                currentY--;
                if (currentY < 0)
                {
                    currentX = 1;
                    MoveSelector();
                }
                else
                {
                    MoveSelector();
                }

            }
            else if ((Input.GetKeyDown("w")) && currentY < 2)
            {
                moving = true;
                currentY++;
                MoveSelector();
            }

        }
    }
}
