using UnityEngine;
using System.Collections;

// All component that require physics inherit from this class, for easy access to the Rigidbody2D component

[RequireComponent(typeof(Rigidbody))]
public abstract class Physics3DObject : MonoBehaviour
{
	[HideInInspector]
	public new Rigidbody rigidbody;

	void Awake ()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

}
