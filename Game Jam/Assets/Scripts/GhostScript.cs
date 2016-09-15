using UnityEngine;
using System.Collections;

public class GhostScript : MonoBehaviour {

	float ghostDistance;
	float darknessLevel;
	Vector3 spawnPosition;
	Vector3 playerLocation;
	public GameObject Player;
	public GameObject Ghost;
	Vector3 dontSpawnGhostsHere;
	float spawnRate = 0.5f;
	float nextSpawn = 0;



	// Use this for initialization
	void Start () 

	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		dontSpawnGhostsHere = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
			
		if(Time.time > nextSpawn)
		{
			nextSpawn = Time.time + spawnRate;
			spawnPosition = new Vector3 (Random.insideUnitSphere.x * 40f + this.gameObject.transform.position.x, Random.Range(-15f, 15f) + this.gameObject.transform.position.y ,Random.insideUnitSphere.z * 40f + + this.gameObject.transform.position.z);

			Instantiate (Ghost, spawnPosition, Quaternion.identity);
		}

	}
}
