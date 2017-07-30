using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class BunnyController : MonoBehaviour {

    private Rigidbody2D myRigidBody2d;
    private Animator myAnimator;
    public float bunnyJumpForce = 500F;
    private float bunnyHurtTime = -1;
    private Collider2D myCollider;
    public Text scoreText;
    private float startTime;
    private int jumpsLeft = 2;
    public AudioSource jumpSfx;
    public AudioSource deathSfx; 

    // Use this for initialization
    void Start () {
        myRigidBody2d = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("TitleScreen");
        }

        if (bunnyHurtTime == -1)
        {
            if (Input.GetButtonUp("Jump") && jumpsLeft > 0)
            {                

                if(myRigidBody2d.velocity.y > 0)
                {
                    myRigidBody2d.velocity = Vector2.zero;
                }

                myRigidBody2d.AddForce(transform.up * bunnyJumpForce);
                jumpsLeft--;
                jumpSfx.Play();
            }
            myAnimator.SetFloat("vVelocity", myRigidBody2d.velocity.y);
            scoreText.text = (Time.time - startTime).ToString("0.0");
        } else
        {
            if(Time.time > bunnyHurtTime + 4 )
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
	}

    void OnCollisionEnter2D (Collision2D Collision) {
        if (Collision.collider.gameObject.layer == LayerMask.NameToLayer("Obstacles")) {

            foreach(MoveLeft x in FindObjectsOfType<MoveLeft>())
            {
                x.enabled = false;
            }

            foreach (PreFabSpawner spawner in FindObjectsOfType<PreFabSpawner>())
            {
                spawner.enabled = false;
            }

            bunnyHurtTime = Time.time;
            myAnimator.SetBool("bunnyHurt", true);
            myRigidBody2d.velocity = Vector2.zero;
            myRigidBody2d.AddForce(transform.up * bunnyJumpForce);
            myCollider.enabled = false;
            deathSfx.Play();
        }

        if (Collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            jumpsLeft = 2; 
        }
    }
}
