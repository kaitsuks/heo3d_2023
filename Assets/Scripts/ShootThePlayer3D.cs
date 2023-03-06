using UnityEngine;
using System.Collections;
using System.Collections.Specialized;

[AddComponentMenu("Kaitsu/Creation/Shoot The Player 3D")]
public class ShootThePlayer3D : MonoBehaviour
{
	[Header("Object creation")]
	
	public GameObject prefabToSpawn;

	// The key to press to create the objects/projectiles
	public KeyCode keyToPress = KeyCode.E;

	[Header("Other options")]

	// This is the target the object is going to move towards
	private GameObject gameObject;
	private Transform target;


	//public float followDistance = 2f;
	public float shootDistance = 10f;

	private bool shootEnabled = false;

	// The direction that will face the target
	public Enums.Directions useSide = Enums.Directions.Up;

	public GameObject jalusta;
	//public GameObject pyssy;

	// The rate of creation, as long as the key is pressed
	public float creationRate = .5f;

	// The speed at which the object are shot along the Y axis
	public float shootSpeed = 5f;

	public Vector3 shootDirection = new Vector3(1f, 1f, 1f);

	public bool relativeToRotation = true;

	private float timeOfLastSpawn;

	// Will be set to 0 or 1 depending on how the GameObject is tagged
	private int playerNumber;


	// Use this for initialization
	void Start ()
	{
		gameObject = GameObject.FindWithTag("Player");
		target = gameObject.transform;
		timeOfLastSpawn = -creationRate;

		// Set the player number based on the GameObject tag
		playerNumber = (gameObject.CompareTag("Player")) ? 0 : 1;
	}

	public void EnableShooting(bool enabled)
	{
		shootEnabled = enabled;
	}


	// Update is called once per frame
	void Update ()
	{
		
	}

	void FixedUpdate()
	{
		//do nothing if the target hasn't been assigned or it was detroyed for some reason
		if (target == null)
			return;
		if (shootEnabled 
		   && Time.time >= timeOfLastSpawn + creationRate
		   && Vector3.Distance(jalusta.transform.position, target.position) < shootDistance || Input.GetKey(keyToPress))
		{
			GameObject newObject = Instantiate<GameObject>(prefabToSpawn, transform.position, jalusta.transform.rotation);
			// newObject.tag = "Bullet"; //TÄSSÄ VIKA


            //add a Bullet component if the prefab doesn't already have one, and assign the player ID
			//BULLETATTRIBUTEA EI VIHOLLISLUODEILLE!
            //BulletAttribute3D b = newObject.GetComponent<BulletAttribute3D>();
            //if (b == null)
            //{
            //    b = newObject.AddComponent<BulletAttribute3D>();
            //}
            //b.playerId = playerNumber;

            timeOfLastSpawn = Time.time;

			Rigidbody rigidbody = newObject.GetComponent<Rigidbody>();
			if (rigidbody != null)
			{
				rigidbody.AddForce((newObject.transform.forward) * shootSpeed, ForceMode.Impulse);
			}
		}
	}

}
