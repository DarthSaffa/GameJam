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
	float lightLevel;



	// Use this for initialization
	void Start () 

	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		lightLevel = Match.matchLightLevel / 25;
		dontSpawnGhostsHere = new Vector3 (this.gameObject.transform.position.x + lightLevel, this.gameObject.transform.position.y + lightLevel, this.gameObject.transform.position.z + lightLevel);
			

		if(Time.time > nextSpawn)
		{
			nextSpawn = Time.time + spawnRate;
			spawnPosition = new Vector3 (Random.insideUnitSphere.x * 40f + this.gameObject.transform.position.x, Random.Range(-15f, 15f) + this.gameObject.transform.position.y ,Random.insideUnitSphere.z * 40f + + this.gameObject.transform.position.z);

			if (spawnPosition.x < dontSpawnGhostsHere.x || spawnPosition.y < dontSpawnGhostsHere.y || spawnPosition.z < dontSpawnGhostsHere.z) 
			{			
				spawnPosition = new Vector3 (Random.insideUnitSphere.x * 40f + this.gameObject.transform.position.x, Random.Range (-15f, 15f) + this.gameObject.transform.position.y, Random.insideUnitSphere.z * 40f + +this.gameObject.transform.position.z);
			} 
			else 
			{
				Instantiate (Ghost, spawnPosition, Quaternion.identity);
			}
		}

	}
}
