using UnityEngine;
using System.Collections;

[AddComponentMenu("Kaitsu/Movement/Push3D")]
[RequireComponent(typeof(Rigidbody))]
public class Push3D : Physics3DObject
{
	[Header("Input key")]

	// the key used to activate the push
	//public KeyCode key = KeyCode.Space;
	public KeyCode keyForward = KeyCode.UpArrow;
	public KeyCode keyBackward = KeyCode.DownArrow;

	[Header("Direction and strength")]

	// strength of the push, and the axis on which it is applied (can be X or Y)
	public float pushStrength = 5f;
	public Enums.Axes axis = Enums.Axes.Y;
	public bool relativeAxis = true;
	public bool orientToDirection = true;

	private Vector3 direction;
	public Enums.Directions lookAxis = Enums.Directions.Forward;


	private bool keyForwardPressed = false;
	private bool keyBackwardPressed = false;
	private Vector3 pushVector;

	public GameObject backmotor;

	public GameObject jalusta;



	// Read the input from the player
	void Update()
	{
		keyForwardPressed = Input.GetKey(keyForward);
		keyBackwardPressed = Input.GetKey(keyBackward);
	}


	// FixedUpdate is called every frame when the physics are calculated
	void FixedUpdate()
	{

		//if the object has to look in the direction of movement
		if (orientToDirection)
		{
		//	Utils3D.SetAxisTowards(lookAxis, transform, direction); // EI VÄKISIN
		}

		if (keyForwardPressed)
		{
			//UnityEngine.Debug.Log("Annetaan potkua!");
			// pushVector = Utils3D.GetVectorFromAxis(axis) * pushStrength;

			// pushVector = new Vector3(1.0f, 0.0f, 1.0f) * pushStrength;
			pushVector = Vector3.forward * pushStrength;

			//Apply the push
			if (relativeAxis)
			{
				jalusta.GetComponent<Rigidbody>().AddRelativeForce(pushVector);
			}
			else
			{
				jalusta.GetComponent<Rigidbody>().AddForce(pushVector);
			}
		}

		if (keyBackwardPressed)
		{
			UnityEngine.Debug.Log("Peruutetaan!");
			//pushVector = Utils.GetVectorFromAxis(axis) * pushStrength;

			pushVector = new Vector3(1.0f, 0.0f, 1.0f) * pushStrength * 1f;
			pushVector = pushVector * -1;

			//Apply the push
			if (relativeAxis)
			{
				jalusta.GetComponent<Rigidbody>().AddRelativeForce(pushVector);
				//backmotor.GetComponent<Rigidbody>().AddRelativeForce(pushVector);
				//GetComponent<Rigidbody>().AddForce (-transform.forward * 10000f * Time.deltaTime);
			//	GetComponent<Rigidbody>().AddRelativeForce(-transform.forward * 10000f * Time.deltaTime);
				//GetComponent<Rigidbody>().AddForce(-transform.forward * pushStrength, ForceMode.Impulse);
			}
			else
			{
				jalusta.GetComponent<Rigidbody>().AddForce(pushVector);
			}
		}
		//keyForwardPressed = false;
		//keyBackwardPressed = false;
	}

	//Draw an arrow to show the direction in which the object will move
	void OnDrawGizmosSelected()
	{
		if(this.enabled)
		{
			float extraAngle = (relativeAxis) ? transform.rotation.eulerAngles.z : 0f;
			pushVector = Utils.GetVectorFromAxis(axis) * pushStrength;
			Utils.DrawMoveArrowGizmo(transform.position, pushVector, extraAngle, pushStrength * .5f);
		}
	}
}
