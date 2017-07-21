using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour {

    private Rigidbody2D myRigidBody2d;
    private Animator myAnimator;
    public float bunnyJumpForce = 500F; 

	// Use this for initialization
	void Start () {
        myRigidBody2d = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonUp("Jump")) {
            myRigidBody2d.AddForce(transform.up * bunnyJumpForce);
        }
        myAnimator.SetFloat("vVelocity", myRigidBody2d.velocity.y);
	}
}
