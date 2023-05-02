using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    private Rigidbody rb;
    float horizontalInput;
    //float verticalInput;
    public float rotationSpeed = 100f; // The speed at which the boat rotates
    public float rotDelta = 0.1f;
    Vector3 direction;
    // The speed at which the character moves
    //public float force = 20f;
    //Vector3 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true; // Est‰‰ torquen.
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown("y")) horizontalInput += rotDelta;
        if (Input.GetKeyDown("u")) horizontalInput -= rotDelta;
        //= Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");
        // Apply the torque to the Rigidbody
        //rb.AddTorque(transform.up * horizontalInput * rotationSpeed, ForceMode.Force);
        //rb.AddTorque(transform.up * horizontalInput * rotationSpeed, ForceMode.Force);
        //Debug.Log("rotationSpeed " + horizontalInput * rotationSpeed);
        // Calculate the rotation
        Quaternion rotationChange = Quaternion.Euler(0, horizontalInput * rotationSpeed * Time.deltaTime, 0);
        //muutetaan rotation
        rb.MoveRotation(rb.rotation * rotationChange);
        //Debug.Log("RigidBody Rotation: " + rb.transform.rotation);
        //direction = transform.forward; // Use the object's forward direction
        //direction.Normalize(); // Normalize the direction vector
        //movement = direction * verticalInput; // 
        //rb.AddRelativeForce(movement * force); // Apply the force in the relative direction
        //rb.AddForce(movement * force); // Apply the force in the  direction
        //rb.AddRelativeForce(movement, ForceMode.Force);
        //force = 1.0f;
        //rb.AddRelativeForce(0, 0, force, ForceMode.Impulse);
        //rb.AddRelativeForce(new Vector3(transform.forward.x, 0, transform.forward.z) * force);
    }
}
