using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BunnyController : MonoBehaviour {

    private Rigidbody2D myRigidBody2d;
    private Animator myAnimator;
    public float bunnyJumpForce = 500F;
    private float bunnyHurtTime = -1;

    // Use this for initialization
    void Start () {
        myRigidBody2d = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (bunnyHurtTime == -1)
        {
            if (Input.GetButtonUp("Jump"))
            {
                myRigidBody2d.AddForce(transform.up * bunnyJumpForce);
            }
            myAnimator.SetFloat("vVelocity", myRigidBody2d.velocity.y);
        } else
        {
            if(Time.time > bunnyHurtTime + 2 )
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
	}

    void OnCollisionEnter2D (Collision2D Collision) {
        if (Collision.collider.gameObject.layer == LayerMask.NameToLayer("Obstacles")) {

            foreach(MoveLeft x in FindObjectsOfType<MoveLeft>())
            {

            }

            bunnyHurtTime = Time.time;
            myAnimator.SetBool("bunnyHUrt", true);
        }
    }
}
