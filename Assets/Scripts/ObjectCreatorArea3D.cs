using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreatorArea3D : MonoBehaviour
{
	private BoxCollider boxCollider;
	public float spawnInterval = 5;
	public bool spawnEnabled = false;
	bool spawned = false;
	public GameObject prefabToSpawn;
	public int maxEnemies = 100;

	// Start is called before the first frame update
	void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
		if (spawnEnabled)
		{
			UnityEngine.Debug.Log("Aletaan tuottaa vihollisia " + gameObject);
			StartCoroutine(SpawnObject());
		}
    }

	public void StartSpawning()
    {
		
		if (!spawned)
		{
			spawned = true;
			spawnEnabled = true;
			StartCoroutine(SpawnObject());
		}
	}

	public void StopSpawning()
	{

		if (spawned)
		{
			//spawned = false;
			spawnEnabled = false;
			StopCoroutine("SpawnObject");
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }

	// This will spawn an object, and then wait some time, then spawn another...
	IEnumerator SpawnObject()
	{
		while (spawnEnabled && GameManager.enemiesNumber < GameManager.maxEnemies)
		{
			// Create some random numbers
			float randomX = Random.Range(-boxCollider.size.x, boxCollider.size.x) * .5f;
			float randomZ = Random.Range(-boxCollider.size.z, boxCollider.size.z) * .5f;

			// Generate the new object
			GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
			// UnityEngine.Debug.Log("Vihollinen kohteesta " + gameObject + " , numerolla " + GameManager.enemiesNumber);
			newObject.transform.position = new Vector3(randomX + this.transform.position.x, 4f, randomZ + this.transform.position.z);
			//GameManager.enemiesNumber++;
			GameManager.ChangeEnemiesCount(1);
			// Wait for some time before spawning another object
			yield return new WaitForSeconds(spawnInterval);
		}
	}
}
