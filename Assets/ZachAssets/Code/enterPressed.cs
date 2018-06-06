using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class enterPressed : MonoBehaviour {

    public List<GameObject> pressed = new List<GameObject>();
    public FinalCombination God;

    public List<int> chosenNumber = new List<int>();
    public List<int> chosenSymbol = new List<int>();
    public List<int> chosenColor = new List<int>();

    public GameObject Heart1, Heart2, Heart3,Menu,WinnerMenu;

    public string SymbolCheck;
    public string ColorCheck;

    public int Lives = 3;

    // Use this for initialization
    void Awake () {
        God = GameObject.Find("CombinationPrefab(Clone)").GetComponent<FinalCombination>();
		for(int i = 0; i < 9; i++)
        {
            pressed.Add(GameObject.Find("Marked" + i));
            pressed.ElementAt(i).GetComponent<SpriteRenderer>().enabled = false;
        }
	}
	public string conversion(int x)
    {
       // print("color Number:" + x);
        string colorString;
            if(x == 6)
        {
            colorString = "Blue";
        }
            else if(x == 7)
        {
            colorString = "Green";
        }
        else
        {
            colorString = "Red";
        }

       
        return colorString;
    }

    public string conversionSymbol(int x)
    {
     //   print("symbol Number:" + x);
        string colorString;
        if (x == 3)
        {
            colorString = "Hieroglyphic3";
        }
        else if (x == 4)
        {
            colorString = "Hieroglyphic2";
        }
        else
        {
            colorString = "Hieroglyphic1";
        }


        return colorString;
    }

    public void SwitchChoice(int x)
    {
   
       if(x == 10) //Enter
        {
            if(chosenNumber.Count > 0 && chosenSymbol.Count > 0 && chosenColor.Count > 0) //make sure they arent empty
            {
              //  print(conversion(chosenColor.ElementAt(0)));
               // print(conversionSymbol(chosenSymbol.ElementAt(0)));
                if ((chosenNumber.ElementAt(0)).ToString() == God.number && conversion(chosenColor.ElementAt(0)) == God.color && conversionSymbol(chosenSymbol.ElementAt(0)) == God.symbol) 
                {
                    WinnerMenu.GetComponent<jumpToBoss>().BringUpMenu();
                  
                }
                else
                {
                    Lives--;
                    if (Lives < 1)
                    {
                        GameObject.Find("Directional Light").GetComponent<AudioSource>().Play();
                        Heart1.GetComponent<SpriteRenderer>().enabled = false;
                       Menu.GetComponent<mainMenuJump>().BringUpMenu();
                        return;
                    }
                    else if (Lives < 2)
                    {
                        GameObject.Find("Directional Light").GetComponent<AudioSource>().Play();
                        Heart2.GetComponent<SpriteRenderer>().enabled = false;
                        return;
                    }
                    else if (Lives < 3)
                    {
                        GameObject.Find("Directional Light").GetComponent<AudioSource>().Play();
                        Heart3.GetComponent<SpriteRenderer>().enabled = false;
                        return;
                    }
                }


            }
            else
            {
               // print("retuned");
                return;
            }
            GameObject.Find("ChosenOnes").GetComponent<AudioSource>().Play();

            /*
            if(chosenNumber.Count > 0)
            {
                chosenNumber.RemoveAt(chosenNumber.Count - 1);
            }
            if(chosenSymbol.Count > 0)
            {
                chosenSymbol.RemoveAt(chosenSymbol.Count - 1);
            }
            if(chosenColor.Count > 0)
            {
                chosenColor.RemoveAt(chosenColor.Count - 1);
            }
            */
        }
        else if(x < 3) //Left Column
        {
            for(int i = 0; i < 3; i++)
            {
                pressed.ElementAt(i).GetComponent<SpriteRenderer>().enabled = false;
                if (chosenNumber.Count > 0) chosenNumber.RemoveAt(chosenNumber.Count - 1);
            }
            pressed.ElementAt(x).GetComponent<SpriteRenderer>().enabled = true;
            chosenNumber.Add(x);
        }
        else if(x >= 3 && x <= 5) //Middle Column
        {
            for (int i = 3; i <= 5; i++)
            {
                pressed.ElementAt(i).GetComponent<SpriteRenderer>().enabled = false;
                if (chosenSymbol.Count > 0) chosenSymbol.RemoveAt(chosenSymbol.Count - 1);
            }
            pressed.ElementAt(x).GetComponent<SpriteRenderer>().enabled = true;
            chosenSymbol.Add(x);
        }
        else
        {
            for (int i = 6; i < 9; i++) //Right Column
            {
                pressed.ElementAt(i).GetComponent<SpriteRenderer>().enabled = false;
                if (chosenColor.Count > 0)  chosenColor.RemoveAt(chosenColor.Count - 1);
            }
            pressed.ElementAt(x).GetComponent<SpriteRenderer>().enabled = true;
            chosenColor.Add(x);
        }
    }
}
