using UnityEngine;
using System.Collections;
using System.Collections.Specialized;

//This script has been suggested by Bryan Livingston (@BryanLivingston). Thanks Bryan!
//Modified to 3D from Unity Playground 2D original by Kaitsu
//Force and no-force versions
//If you want to use force version, comment out Update() and in FixedUpdate() /Kaitsu

[AddComponentMenu("Kaitsu/Movement/Wander3DB")]
[RequireComponent(typeof(Rigidbody))]
public class Wander3DB : Physics3DObject
{
	[Header("Movement")]
	public float speed = 5f;
	public float directionChangeInterval = 3f;
	public bool keepNearStartingPoint = true;

	[Header("Orientation")]
	public bool orientToDirection = true;
	// The direction that the GameObject will be oriented to
	public Enums.Directions lookAxis = Enums.Directions.Right;

	private Vector3 direction;
	private Vector3 startingPoint;

	// Start is called at the beginning of the game
	private void Start()
	{
		//we don't want directionChangeInterval to be 0, so we force it to a minimum value ;)
		if (directionChangeInterval < 0.1f)
		{
			directionChangeInterval = 0.1f;
		}

		// we note down the initial position of the GameObject in case it has to hover around that (see keepNearStartingPoint)
		startingPoint = transform.position;

		StartCoroutine(ChangeDirection());
	}

	// Calculates a new direction
	private IEnumerator ChangeDirection()
	{
		while (true)
		{
			direction = Random.insideUnitSphere * 5; //change the direction the player is going
			direction.y = 0;

			// if we need to keep near the starting point...
			if (keepNearStartingPoint)
			{
				// we measure the distance from it...
				float distanceFromStart = Vector3.Distance(startingPoint, transform.position);
				if (distanceFromStart > 1f + (speed * 0.1f)) // and if it's too much...
				{
					//... we get a direction that points back to the starting point
					direction = (startingPoint - transform.position).normalized;
				}
			}

			//if the object has to look in the direction of movement
			if (orientToDirection)
			{
				Utils3D.SetAxisTowards(lookAxis, transform, direction);
			}

			// this will make Unity wait for some time before continuing the execution of the code
			yield return new WaitForSeconds(directionChangeInterval);
		}
	}

    private void Update()
    {
		//No physics force version

		//You've already calculated and stored the movement direction, so all you need to do is transform
		//	that into a quaternion and assign it in your Update function and you're done;
		//alien.transform.rotation = Quaternion.LookRotation(movementDirection);
		//If you want the transition to be smoother, you can interpolate the rotation as well;
		//alien.transform.rotation = Quaternion.Slerp(alien.transform.rotation, Quaternion.LookRotation(movementDirection), Time.deltaTime * 40f);

		transform.rotation = Quaternion.LookRotation(direction);

		// Move the object forward along its z axis, speed units/second.
		transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}


    // FixedUpdate is called every frame when the physics are calculated
    private void FixedUpdate()
	{	//Physics version with force
		//rigidbody.AddForce(direction * speed);
	}
}
