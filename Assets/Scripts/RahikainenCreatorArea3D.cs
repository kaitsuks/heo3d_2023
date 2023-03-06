using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RahikainenCreatorArea3D : MonoBehaviour
{
	private BoxCollider boxCollider;
	public bool spawnEnabled = false;
	bool spawned = false;
	public GameObject prefabToSpawn;
	
	// Start is called before the first frame update
	void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
		if(boxCollider != null)
        {
			// UnityEngine.Debug.Log("BoxCollider objektissa " + gameObject);
		}
		//if (spawnEnabled)
		//{
		//	UnityEngine.Debug.Log("Aletaan tuottaa Rahikaisia " + gameObject);
		//	SpawnRahikainen();
		//}
    }

	public void SpawnRahikainen()
    {
		
		if (!spawned)
		{
			spawned = true;
			spawnEnabled = true;
			float randomX = Random.Range(-boxCollider.size.x, boxCollider.size.x) * .5f;
			float randomZ = Random.Range(-boxCollider.size.z, boxCollider.size.z) * .5f;

			// Generate the new object
			GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
			// UnityEngine.Debug.Log("Rahikainen luotu kohteesta " + gameObject);
			newObject.transform.position = new Vector3(randomX + this.transform.position.x, 4f, randomZ + this.transform.position.z);
		}
	}

	public void StopSpawning()
	{

		if (spawned)
		{
			//spawned = false;
			spawnEnabled = false;
			
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }

}
