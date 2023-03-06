using UnityEngine;
using System.Collections;

[AddComponentMenu("Kaitsu/Gameplay/Object Creator Area 3D")]
[RequireComponent(typeof(BoxCollider))]
public class ObjectCreatorArea3DV1 : MonoBehaviour
{
	[Header("Object creation")]

	// The object to spawn
	// WARNING: take if from the Project panel, NOT the Scene/Hierarchy!
	public GameObject prefabToSpawn;

	[Header("Other options")]

	// Configure the spawning pattern
	public float spawnInterval = 5;

	private BoxCollider boxCollider;

	public bool spawnEnabled = true;

	void Start ()
	{
		boxCollider = GetComponent<BoxCollider>();

		//StartCoroutine(SpawnObject());
	}
	
	// This will spawn an object, and then wait some time, then spawn another...
	IEnumerator SpawnObject ()
	{
		while(spawnEnabled)
		{
			// Create some random numbers
			float randomX = Random.Range (-boxCollider.size.x, boxCollider.size.x) *.5f;
			float randomZ = Random.Range (-boxCollider.size.z, boxCollider.size.z) *.5f;

			// Generate the new object
			//GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
			//newObject.transform.position = new Vector3(randomX + this.transform.position.x, 4f, randomZ + this.transform.position.z);

			// Wait for some time before spawning another object
			yield return new WaitForSeconds(spawnInterval);
		}
	}
}
