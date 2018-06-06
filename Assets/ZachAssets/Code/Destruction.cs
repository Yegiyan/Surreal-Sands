using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Destruction : MonoBehaviour {

    GroundObjectSpawner reference;
    public Animator bomb;

 

	
	void Awake ()
    {
        bomb = GameObject.Find("Explosion_0").GetComponent<Animator>();
        reference = GameObject.Find("GroundSpawner").GetComponent<GroundObjectSpawner>();
	}
	
    public void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Destroy")
        {
            if (reference.movingObject.Count > 0)
            {
                Destroy(reference.movingObject.ElementAt(reference.movingObject.Count - 1));
            }
            reference.movingObject.RemoveAt(reference.movingObject.Count - 1);
            reference.ObjectSpawned = false;
        }

        // Bomb Destruction
        if (this.gameObject.tag == "Bomb") 
        {       
            if (col.tag == "floor" || col.tag == "Finish")
            {
               bomb.SetTrigger("RunningBomb");
               bomb.GetComponent<AudioSource>().Play();
               Destroy(reference.movingObject.ElementAt(reference.movingObject.Count - 1));
               reference.movingObject.RemoveAt(reference.movingObject.Count - 1);
               reference.ObjectSpawned = false;
            }
        }

        if(this.gameObject.tag == "Scroll")
        {
            if(col.tag == "GiantHorse")
            {
                GameObject.Find("CombinationPrefab(Clone)").GetComponent<FinalCombination>().SetHasSymbolTrue();
                GameObject.Find("Level2GameMaster").GetComponent<AudioSource>().Play();
                Destroy(GameObject.Find("Scroll"));
            }
        }
    }
}
