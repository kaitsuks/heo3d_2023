using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Kaitsu3D;

//


//namespace Kaitsu3D
//{
	[AddComponentMenu("Kaitsu/Movement/Move With Arrows 3D")]
	[RequireComponent(typeof(Rigidbody))]
	public class MoveWithArrows3DV2 : MonoBehaviour
	{
		[Header("Input keys")]
		public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;

		[Header("Movement")]
		[Tooltip("Speed of movement")]
		public float speed = 5f;
		public Enums.MovementType movementType = Enums.MovementType.AllDirections;

		[Header("Orientation")]
		public bool orientToDirection = false;
		// The direction that will face the player
		public Enums.Directions lookAxis = Enums.Directions.Up;

		private Vector3 movement, cachedDirection;
		private float moveHorizontal;
		private float moveVertical;


		// Update gets called every frame
		void Update()
		{
			// Moving with the arrow keys
			if (typeOfControl == Enums.KeyGroups.ArrowKeys)
			{
				moveHorizontal = Input.GetAxis("Horizontal");
				moveVertical = Input.GetAxis("Vertical");
			}
			else
			{
				moveHorizontal = Input.GetAxis("Horizontal2");
				moveVertical = Input.GetAxis("Vertical2");
			}

			//zero-out the axes that are not needed, if the movement is constrained
			switch (movementType)
			{
				case Enums.MovementType.OnlyHorizontal:
					moveVertical = 0f;
					break;
				case Enums.MovementType.OnlyVertical:
					moveHorizontal = 0f;
					break;
			}

			movement = new Vector3(moveHorizontal, 0, moveVertical); //move vertical = horizontal z


			//rotate the gameObject towards the direction of movement
			//the axis to look can be decided with the "axis" variable
			if (orientToDirection)
			{
				if (movement.sqrMagnitude >= 0.01f)
				{
					cachedDirection = movement;
				}
				Utils.SetAxisTowards(lookAxis, transform, cachedDirection);
			}
		}



		// FixedUpdate is called every frame when the physics are calculated
		void FixedUpdate()
		{
			// Apply the force to the Rigidbody
			GetComponent<Rigidbody>().AddForce(movement * speed * 10f);
		}
	}

//} // namespace Kaitsu3D loppuu tähän
