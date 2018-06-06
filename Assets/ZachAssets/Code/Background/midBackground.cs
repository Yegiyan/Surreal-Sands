using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class midBackground : MonoBehaviour {

    public float speed = .45f;

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(Time.time * speed, 0f);
        this.GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
