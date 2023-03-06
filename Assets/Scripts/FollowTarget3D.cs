using UnityEngine;
using System.Collections;

[AddComponentMenu("Kaitsu/Movement/Follow Target 3D")]
[RequireComponent(typeof(Rigidbody))]
public class FollowTarget3D : Physics3DObject
{
	// This is the target the object is going to move towards
	private GameObject gameObject;
	private Transform target;
	public float followDistance = 2;

	[HideInInspector]
	public bool attackEnabled;

	

	[Header("Movement")]
	// Speed used to move towards the target
	public float followSpeed = 1f;

	// Used to decide if the object will look at the target while pursuing it
	public bool followLookAtTarget = false;

	// The direction that will face the target
	public Enums.Directions useSide = Enums.Directions.Up;

	void Start()
    {
		//GameObject.Find(“first_person_controller”)
		//gameObject = GameObject.Find("Soldier2");
		gameObject = GameObject.FindWithTag("Player");
		target = gameObject.transform;
    }

	
	
	// FixedUpdate is called once per frame
	void FixedUpdate ()
	{
		//do nothing if the target hasn't been assigned or it was detroyed for some reason
		if(target == null)
			return;
		
		
			//look towards the target
			if (followLookAtTarget)
			{
				Utils3D.SetAxisTowards(useSide, transform, target.position - transform.position);
			}

			if (Vector3.Distance(transform.position, target.position) < followDistance || attackEnabled)
				//Move towards the target
				rigidbody.MovePosition(Vector3.Lerp(transform.position, target.position, Time.fixedDeltaTime * followSpeed));
		
	}
}
