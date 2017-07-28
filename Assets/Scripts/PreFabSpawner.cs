using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreFabSpawner : MonoBehaviour {

    private float nextSpawn = 0;
    public Transform preFabToSpawn;
    public AnimationCurve spawnCurve;
    public float curveLengthInSeconds = 30;
    private float startTime;
    public float jitter = 0.25f;

	// Use this for initialization
	void Start () {
        startTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawn)
        {
            // Spawns a new cactus 
            var theClone = Instantiate(preFabToSpawn, transform.position, Quaternion.identity);
            // nextSpawn = Time.time + spawnRate + Random.Range(0, randomDelay);
            // Cast the clone to transform to be sure you're destroying the instansiated object and not the prefab itself
            //Destroy((theClone as Transform).gameObject, 5);

            float curvePos = (Time.time - startTime) / curveLengthInSeconds; 

            if (curvePos < 1F)
            {
                curvePos = 1F;
                startTime = Time.time;
            }

            nextSpawn = Time.time + spawnCurve.Evaluate(curvePos) + Random.Range(-jitter, jitter);

        }
	}

}
