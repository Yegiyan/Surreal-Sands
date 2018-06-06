using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCombination : MonoBehaviour {

    public string number;
    public string symbol;
    public string color;
   

    public bool HasNumber = false;
    public bool HasColor = false;
    public bool HasSymbol = false;

    public bool HasBeenCreated = false;

    public float volume = .5f;
    private void Update()
    {
        AudioListener.volume = volume;
    }
    void Awake()
    {
        if (!HasBeenCreated)
        {
            HasBeenCreated = true;
            DontDestroyOnLoad(this.gameObject);

            number = KeyGeneratorNumber();
            color = KeyGeneratorColor();
            symbol = KeyGeneratorSymbol();
        }
    }

    public void Reset()
    {
        number = KeyGeneratorNumber();
        color = KeyGeneratorColor();
        symbol = KeyGeneratorSymbol();

        HasNumber = false;
        HasColor = false;
        HasSymbol = false;
} 

    string KeyGeneratorNumber()
    {
        string x = "";
        int y = Random.Range(0, 3);
        x = y.ToString();
        return x;
      
    }
    string KeyGeneratorColor()
    {

        string x = "";
        int y = Random.Range(0, 3);
        if (y == 0) x = "Blue";
        else if (y == 1) x = "Green";
        else x = "Red";
        return x;
    }
    string KeyGeneratorSymbol()
    {
        string x = "";
        int y = Random.Range(0, 3);
        if (y == 0) x = "Hieroglyphic1";
        else if (y == 1) x = "Hieroglyphic2";
        else x = "Hieroglyphic3";
        return x;
    }

   public void SetHasNumberTrue()
    {
        HasNumber = true;
    }
    public void SetHasNumberFalse()
    {
        HasNumber = false;
    }
    public void SetHasColorTrue()
    {
        HasColor = true;
    }
    public void SetHasColorFalse()
    {
        HasColor = false;
    }
    public void SetHasSymbolTrue()
    {
        HasSymbol = true;
    }
    public void SetHasSymbolFalse()
    {
        HasSymbol = false;
    }
}
