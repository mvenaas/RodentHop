using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreFabSpawner : MonoBehaviour {

    private float nextSpawn = 0;
    public Transform preFabToSpawn;
    public float spawnRate = 1;
    public float randomDelay = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawn)
        {
            // Spawns a new cactus 
            var theClone = Instantiate(preFabToSpawn, transform.position, Quaternion.identity);
            nextSpawn = Time.time + spawnRate + Random.Range(0, randomDelay);
            // Cast the clone to transform to be sure you're destroying the instansiated object and not the prefab itself
            Destroy((theClone as Transform).gameObject, 5);
        }
	}
}
