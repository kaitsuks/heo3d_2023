using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//In this script, the maxTiltAngle variable controls the maximum angle that the
// character can tilt, and the fallDelay and uprightDelay variables control the
// delay before falling or returning to upright position after the corresponding
//trigger is activated.

//The Start() method initializes some variables, including the character's 
//initial rotation, and the Update() method checks for input and applies tilt and
// skew to the character if not falling or returning to upright position.The
//StartFalling() method is invoked after the falling trigger is activated and
//sets the character's rigidbody to be affected by physics, causing it to fall to
// the ground. The ReturnToUpright() method is invoked after the returning
//trigger is activated and sets the character's rigidbody to be kinematic again,
// and resets the character's rotation to its initial upright position.

public class PlayerController : MonoBehaviour
{
    public float maxTiltAngle = 0.5f; // Maximum angle the character can tilt
    public float maxAllowedAngle = 0.6f; // Maximum angle before falling
    public float fallDelay = 1f; // Delay before falling after trigger is activated
    public float uprightDelay = 1f; // Delay before returning to upright position after trigger is activated

    private Rigidbody rb;
    private Quaternion initialRotation;
    private float tiltX;
    private float tiltY;
    private float tiltZ;
    private bool isFalling;
    private bool isReturning;

    Quaternion targetRotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialRotation = transform.rotation;
        isFalling = false;
        isReturning = false;
        Debug.Log("Character is starting x " + transform.rotation.x + " z " + transform.rotation.z);
    }

    private void Update()
    {
        if(transform.rotation.x > maxAllowedAngle || transform.rotation.z > maxAllowedAngle)
        {
            isFalling = true;
            Debug.Log("Character is falling x " + transform.rotation.x + " z " + transform.rotation.z);
        }

        if (!isFalling && !isReturning)
        {
            rb.isKinematic = false;
            // tiltY = transform.rotation.eulerAngles.y;
            // initialRotation = transform.rotation;

            //Invoke("StartFalling", fallDelay);
            //Invoke("ReturnToUpright", uprightDelay);
        }


            // Check for falling trigger
            //if (Input.GetKeyDown(KeyCode.F) && !isFalling && !isReturning)
            if (Input.GetKeyDown(KeyCode.F) )
            {
            isFalling = true;
            Invoke("StartFalling", fallDelay);
        }

        // Check for returning trigger
        //if (Input.GetKeyDown(KeyCode.R) && !isFalling && !isReturning)
            if (Input.GetKeyDown(KeyCode.R) )
            {
            isReturning = true;
            Invoke("ReturnToUpright", uprightDelay);
        }

            // Apply tilt and skew to the character
            if (!isFalling && !isReturning)
            {
                float horizontal = Input.GetAxis("Horizontal");
                //float horizontal = transform.rotation.y;
                float vertical = Input.GetAxis("Vertical");
               // tiltX = Mathf.Lerp(tiltX, -vertical * maxTiltAngle, Time.deltaTime * 10f);
               // tiltZ = Mathf.Lerp(tiltZ, vertical * maxTiltAngle, Time.deltaTime * 10f);
            //tiltY = Mathf.Lerp(tiltY, horizontal * maxTiltAngle, Time.deltaTime * 10f);
            //tiltY = transform.rotation.y;
            //tiltY = horizontal;

            //tiltX = transform.rotation.x;
            //tiltY = transform.rotation.y * 90f;
            //tiltZ = transform.rotation.z;
            //Quaternion targetRotation = Quaternion.Euler(tiltX, transform.rotation.eulerAngles.y, tiltZ);
            //Quaternion targetRotation = Quaternion.Euler(tiltX, transform.rotation.eulerAngles.y * tiltY, tiltZ);
            //Quaternion targetRotation = Quaternion.Euler(tiltX, transform.rotation.eulerAngles.y, tiltZ);
            if (!isFalling)
            {
                targetRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            }
            if (isFalling)
            {
                targetRotation = Quaternion.Euler(-1, transform.rotation.eulerAngles.y, -1);
            }
            // A rotation 
            Quaternion rotation = Quaternion.Euler(0, horizontal * 360, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 20f);
                //transform.Rotate(new Vector3(tiltX, horizontal, tiltZ));
                transform.Rotate(new Vector3(tiltX, horizontal, tiltZ));
                //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);

            
            
        }
    }

    private void StartFalling()
    {
        //isFalling = false;
        rb.isKinematic = false;
    }

    private void ReturnToUpright()
    {
        isFalling = false;
        isReturning = false;
        rb.isKinematic = true;
        transform.rotation = initialRotation;
        rb.isKinematic = false;
    }
}
