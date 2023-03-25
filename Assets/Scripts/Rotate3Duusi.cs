using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Rotate3Duusi : MonoBehaviour
{
    public float speed = 5f;
    private float spin;

    public float deltaF1 = 0.1f;
    public float deltaF2 = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (Input.GetKey("a"))
        //{
        //    //UnityEngine.Debug.Log("Käännetään auto plussaan");
        //    if(spin < 2f) spin += deltaF1;
        //    else
        //    spin += deltaF2;
        //}
        ////if (Input.GetKey("v")) spin = 0f; //huono ratkaisu

        //if (Input.GetKey("d"))
        //{
        //    //UnityEngine.Debug.Log("Käännetään auto  miinukseen");
        //    if (spin > -2f) spin -= deltaF1;
        //    else
        //        spin -= deltaF2;
        //}

        //if (!Input.GetKey("a") && !Input.GetKey("d"))
        //{
        //    //UnityEngine.Debug.Log("Suoristetaan ohjaus");
        //    spin = 0.0f;
        //}

        spin = Input.GetAxis("Horizontal");

    }

    void FixedUpdate()
    {
        // Apply the torque to the Rigidbody
        //malli rb.AddTorque(transform.up * torque * turn);
        //tämänkin pitäisi toimia ? GetComponent<Rigidbody>().AddTorque(-spin * speed, 0f,  0f, ForceMode.Force);
        // vanha GetComponent<Rigidbody>().AddTorque(-spin * speed);
        GetComponent<Rigidbody>().AddTorque(transform.up * spin * speed, ForceMode.Force);
       // UnityEngine.Debug.Log("Y = " + transform.rotation.y);
    }
}
