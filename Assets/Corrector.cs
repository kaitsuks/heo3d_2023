using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corrector : MonoBehaviour
{
   
    Rigidbody rb;
    Quaternion qStand;
    float rotationSpeed = 10f;
    float horizontalInput;
    float verticalInput;
    float yRot;
    bool tilted;
    float orgX;
    float orgY;
    float orgZ;


    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    private Quaternion _lastRotation;

    void LookAtMove()
    {
        //var newRot = Quaternion.LookRotation(target.position - transform.position, hit.normal);
        //_lastRotation = Quaternion.Lerp(transform.rotation, newRot, 50 * Time.deltaTime);
        transform.rotation = _lastRotation;
    }

    void LookAtStill()
    {
        transform.rotation = _lastRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!tilted)
        {
            orgX = transform.rotation.x;
            orgY = transform.rotation.y;
            orgZ = transform.rotation.z;
            //orgX = transform.localRotation.x;
            //orgY = transform.localRotation.y;
            //orgZ = transform.localRotation.z;

            //Debug.Log("Rotation angle! x:  " + rb.transform.localRotation.x);
            //Debug.Log("Rotation angle! z:  " + rb.transform.localRotation.z);
            Debug.Log("Rotation angle! y:  " + rb.transform.localRotation.y);

            //_lastRotation = transform.localRotation;
            _lastRotation = transform.rotation;
            //yRot = transform.localRotation.y;
            yRot = transform.rotation.y;
        }
        if ((rb.transform.rotation.x > 0.3f || rb.transform.rotation.z > 0.3f) && !tilted)
        //if ((rb.transform.localRotation.x > 0.3f || rb.transform.localRotation.z > 0.3f) && !tilted)
        {
            tilted = true;
            //Debug.Log("Rotation angle! x:  " + rb.transform.localRotation.x);
            //Debug.Log("Rotation angle! z:  " + rb.transform.localRotation.z);
            Debug.Log("Rotation ORIGINAL angle! y:  " + yRot);
        }
        //LookAtMove();
        // Debug.Log("Rotation angle! x:  " + rb.transform.localRotation.x);
        //qStand = rb.transform.localRotation;
        //yRot = rb.transform.rotation.y;
        //Debug.Log("Rotation angle! y:  " + yRot);
        // Debug.Log("Rotation angle! x:  " + rb.transform.localRotation.x);

        if (Input.GetKey("p") && tilted)
        {
            tilted = false;
            //rb.transform.localRotation = new Quaternion(0f, yRot, 0f, 1f);
           // transform.rotation = Quaternion.Euler(orgX, yRot, orgZ);
            //rb.transform.rotation = new Quaternion(0f, yRot, orgZ, 0f);
            //transform.rotation = _lastRotation;
            //yRot = transform.rotation.y;
            Debug.Log("Rotation angle! y:  " + yRot);
            //rb.transform.rotation = new Quaternion(0f, rb.transform.rotation.y, 0f, 0f);
            rb.transform.rotation = new Quaternion(0f, yRot, 0f, 0f);
            //rb.transform.localRotation = new Quaternion(0f, rb.transform.localRotation.y, 0f, 0f);
            //Quaternion rotationChange = Quaternion.Euler(0, yRot * Time.deltaTime, 0);
            //muutetaan rotation
            //rb.MoveRotation(rb.rotation * rotationChange);
        }

        //if (rb.transform.localRotation.x > 0.1f || rb.transform.localRotation.z > 0.1f)            
        //{
        //    // Debug.Log("Wrong rotation angle! " + rb.transform.localRotation.x);
        //    //start correcting rotation x
        //    // Calculate the rotation
        //    Quaternion rotationChange = Quaternion.Euler(1, -rb.transform.localRotation.z * rotationSpeed * Time.deltaTime, 0);
        //    horizontalInput = Input.GetAxis("Horizontal");
        //    //Quaternion rotationChange = Quaternion.Euler(0, horizontalInput * rotationSpeed * Time.deltaTime, 0);
        //    //muutetaan rotation
        //     rb.MoveRotation(rb.rotation * rotationChange);
        //    //Debug.Log("ROTATION CHANGE " + rotationChange + " time " + Time.deltaTime + " rotationSpeed " + rotationSpeed);
        //    Debug.Log("ROTATION CHANGE " + rotationChange);
        //    //Debug.Log("Horizontal input  " + horizontalInput);
        //}
    }
}
