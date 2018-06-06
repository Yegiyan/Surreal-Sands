using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

	void Awake ()
	{
		this.gameObject.transform.parent = GameObject.Find("Grid").transform;
	}
}
