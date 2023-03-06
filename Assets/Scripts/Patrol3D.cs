using UnityEngine;
using System.Collections;

[AddComponentMenu("Kaitsu/Movement/Patrol 3D")]
[RequireComponent(typeof(Rigidbody))]
public class Patrol3D : Physics3DObject
{
	[Header("Movement")]
	public float speed = 5f;
	public float directionChangeInterval = 3f;

	public Transform target;
	public float viewDistance = 2;

	[Header("Orientation")]
	public bool orientToDirection = false;
	public Enums.Directions lookAxis = Enums.Directions.Up;

	[Header("Stops")]
	public Vector3[] waypoints;

	private Vector3[] newWaypoints;
	private int currentTargetIndex;

	void Start ()
	{
		currentTargetIndex = 0;

		newWaypoints = new Vector3[waypoints.Length+1];
		int w = 0;
		for(int i=0; i<waypoints.Length; i++)
		{
			newWaypoints[i] = waypoints[i];
			w = i;
		}

		//Add the starting position at the end, only if there is at least another point in the queue - otherwise it's on index 0
		int v = (newWaypoints.Length > 1) ? w+1 : 0;
		newWaypoints[v] = transform.position;
		//waypoints = newWaypoints;

		if(orientToDirection)
		{
			Utils.SetAxisTowards(lookAxis, transform, ((Vector3)newWaypoints[1] - transform.position).normalized);
		}
	}
	
	public void FixedUpdate ()
	{
		if (Vector3.Distance(transform.position, target.position) > viewDistance)
		{
			Vector3 currentTarget = newWaypoints[currentTargetIndex];

			rigidbody.MovePosition(transform.position + ((Vector3)currentTarget - transform.position).normalized * speed * Time.fixedDeltaTime);

			if (Vector3.Distance(transform.position, currentTarget) <= .1f)
			{
				//new waypoint has been reached
				currentTargetIndex = (currentTargetIndex < newWaypoints.Length - 1) ? currentTargetIndex + 1 : 0;
				if (orientToDirection)
				{
					currentTarget = newWaypoints[currentTargetIndex];
					Utils.SetAxisTowards(lookAxis, transform, ((Vector3)currentTarget - transform.position).normalized);
				}
			}
		}
	}

	public void Reset()
	{
		
		waypoints = new Vector3[1];
		Vector3 thisPosition = transform.position;
		waypoints [0] = new Vector3 (2f, 0f, 0.5f) + thisPosition;
	}
}