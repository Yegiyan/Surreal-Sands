using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{

	List<GameObject> prefabList = new List<GameObject>();
	public GameObject Prefab1;
	public GameObject Prefab2;
	public GameObject Prefab3;

	void Awake()
	{ 
		prefabList.Add(Prefab1);
		prefabList.Add(Prefab2);
		prefabList.Add(Prefab3);

		int prefabIndex = Random.Range(0, 3);
		Instantiate(prefabList[prefabIndex]);
	}
}
