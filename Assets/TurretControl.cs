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
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true; // Est‰‰ torquen.
    }

    //Controls the rotation of the turret
    void FixedUpdate()
    {
        if (Input.GetKeyDown("y")) horizontalInput += rotDelta;
        if (Input.GetKeyDown("u")) horizontalInput -= rotDelta;
        
        // Calculate the rotation
        Quaternion rotationChange = Quaternion.Euler(0, horizontalInput * rotationSpeed * Time.deltaTime, 0);
        //muutetaan rotation
        rb.MoveRotation(rb.rotation * rotationChange);
        //Debug.Log("RigidBody Rotation: " + rb.transform.rotation);
        
    }
}
