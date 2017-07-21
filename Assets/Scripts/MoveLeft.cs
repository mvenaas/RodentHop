using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {

    public float speed = 10;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        // Takes current position of object and moves left "speed" units per deltatime. 
        // Deltatime is how many seconds last frame used to render. ideally 1 frame/sec?
        transform.position += Vector3.left * speed * Time.deltaTime;
	}
}
