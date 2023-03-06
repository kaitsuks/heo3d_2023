using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[AddComponentMenu("Kaitsu/Movement/Rotate3D_AI1")]
[RequireComponent(typeof(Rigidbody))]
public class Rotate3D_AI1 : Physics3DObject
{
    public float turnSpeed = 1f;
    private float spin;
    private int turn;
    private Vector3 pushVector;

    [Header("Direction and strength")]
    // strength of the push, and the axis on which it is applied (can be X or Z)
    public float pushStrength = 30f;
    public Enums.Axes axis = Enums.Axes.Z;
    public bool relativeAxis = true;

    public float deltaF1 = 0.1f;
    public float deltaF2 = 0.5f;

    [Header("Movement")]
    public float speed = 1f;
    public float directionChangeInterval = 3f;
    public bool keepNearStartingPoint = true;

    private Vector3 direction;
    private Vector3 startingPoint;

    [Header("Orientation")]
    public bool orientToDirection = true;
    // The direction that the GameObject will be oriented to
    public Enums.Directions lookAxis = Enums.Directions.Forward;

    // Start is called before the first frame update
    void Start()
    {
        // we note down the initial position of the GameObject in case it has to hover around that (see keepNearStartingPoint)
        startingPoint = transform.position;

        StartCoroutine(ChangeDirection());
    }

    // Update is called once per frame
    void Update()
    {

        
        if (turn == 1 )
        {
            //UnityEngine.Debug.Log("Käännetään hahmo plussaan");
            if(spin < 2f) spin += deltaF1;
            else
            spin += deltaF2;
        }
        //if (Input.GetKey("v")) spin = 0f; //huono ratkaisu

        if (turn == 2)
        {
            //UnityEngine.Debug.Log("Käännetään hahmo  miinukseen");
            if (spin > -2f) spin -= deltaF1;
            else
                spin -= deltaF2;
        }

        if (turn == 0)
        {
            //UnityEngine.Debug.Log("Suoristetaan ohjaus");
            spin = 0.0f;
        }
    }

    // Calculates a new direction
    private IEnumerator ChangeDirection()
    {
        while (true)
        {
            direction = UnityEngine.Random.insideUnitSphere; //change the direction the player is going
            direction.y = 0;
            turn = UnityEngine.Random.Range(0, 3);
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

    void FixedUpdate()
    {
        // Apply the torque to the Rigidbody
        rigidbody.AddTorque(transform.up * -spin * turnSpeed);

        //Calculate pushVector
        pushVector = new Vector3(1.0f, 0.0f, 1.0f) * pushStrength;

        //Apply the push
        if (relativeAxis)
        {
            rigidbody.AddRelativeForce(pushVector);
        }
        else
        {
            rigidbody.AddForce(pushVector);
        }
    }
}
