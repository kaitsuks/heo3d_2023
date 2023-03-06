using UnityEngine;
using System.Collections;
using System.Collections.Specialized;

[AddComponentMenu("Kaitsu/Creation/Gun Select Shooter 3D")]
public class GunSelectShooter3D : MonoBehaviour
{
	[Header("Object creation")]
	


	public GameObject prefabToSpawn;

	// The key to press to create the objects/projectiles
	public KeyCode keyToPress = KeyCode.Space;

	[Header("Other options")]

	public GameObject jalusta;
	public GameObject pyssy;

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
		timeOfLastSpawn = -creationRate;

		// Set the player number based on the GameObject tag
		playerNumber = (gameObject.CompareTag("Player")) ? 0 : 1;
	}


	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKey(keyToPress)
		   && Time.time >= timeOfLastSpawn + creationRate)
		{
			UnityEngine.Debug.Log("AMPU TULEE!");
			//Vector3 actualBulletDirection = (relativeToRotation) ? (Vector3)(Quaternion.Euler(15f, transform.eulerAngles.y, 40f) * shootDirection) : shootDirection;
			//Vector3 actualBulletDirection = (relativeToRotation) ? (Vector3)(Quaternion.Euler(0f, transform.eulerAngles.y, 0f) * shootDirection) : shootDirection;
			Vector3 actualBulletDirection = (relativeToRotation) ? (Vector3)(Quaternion.Euler(0f, 0f, pyssy.transform.eulerAngles.z) * shootDirection) : shootDirection;

            //Vector3 actualBulletDirection = (Vector3)(Quaternion.Euler(0f, transform.eulerAngles.y, 0f) * shootDirection);

            //GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
            //newObject.transform.position = this.transform.position; //ohjaimen sijainti
            //newObject.transform.eulerAngles = new Vector3(0f, Utils.Angle(actualBulletDirection), 0f);
			//newObject.transform.eulerAngles = new Vector3(0f, Utils.Angle(actualBulletDirection), 0f);

			GameObject newObject = Instantiate<GameObject>(prefabToSpawn, transform.position, transform.rotation);

			//newObject.transform.eulerAngles = new Vector3(0f, 0f, -Utils.Angle(actualBulletDirection));

			newObject.tag = "Bullet";

			// push the created objects, but only if they have a Rigidbody2D
			Rigidbody rigidbody = newObject.GetComponent<Rigidbody>();
			if(rigidbody != null)
			{
				//näitä kokeiltu
				//rigidbody.AddForce(jalusta.transform.rotation *-actualBulletDirection * shootSpeed, ForceMode.Impulse);
				//rigidbody.AddRelativeForce(jalusta.transform.rotation * actualBulletDirection * shootSpeed, ForceMode.Impulse);
				//rigidbody.AddRelativeForce(actualBulletDirection * shootSpeed, ForceMode.Impulse);
				//rigidbody.AddForce(shootSpeed * (Vector3)(Quaternion.Euler(0f, jalusta.transform.eulerAngles.y, 0f)), ForceMode.Impulse);

				// rigidbody.AddForce((jalusta.transform.forward + actualBulletDirection) * shootSpeed, ForceMode.Impulse); //tätä tutkittava vielä

				//rigidbody.AddForce((jalusta.transform.forward) * shootSpeed, ForceMode.Impulse); // toimii  y-akselin ympäri

				rigidbody.AddForce(-(newObject.transform.forward) * shootSpeed, ForceMode.Impulse);

				//rigidbody.AddForce(-(newObject.transform.forward + actualBulletDirection) * shootSpeed, ForceMode.Impulse); //toimii myös newObjectille asetettujen position ja rotation kanssa


			}

			// add a Bullet component if the prefab doesn't already have one, and assign the player ID
			//BulletAttribute b = newObject.GetComponent<BulletAttribute>();
			//if(b == null)
			//{
			//	b = newObject.AddComponent<BulletAttribute>();
			//}
			//b.playerId = playerNumber;



			timeOfLastSpawn = Time.time;
		}
	}

	void OnDrawGizmosSelected()
	{
		if(this.enabled)
		{
			float extraAngle = (relativeToRotation) ? transform.rotation.eulerAngles.z : 0f;
			Utils.DrawShootArrowGizmo(transform.position, shootDirection, extraAngle, 1f);
		}
	}
}
