using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Rotate3DGunEuler : MonoBehaviour
{
    public float speed = 1f;
    private float spin = 0f;

    public float deltaF1 = 0.02f;
    public float deltaF2 = 0.1f;

    public float limit = 0.3f;

    public GameObject jalusta;

    float tiltAroundX;

    float smooth = 5.0f;
    float tiltAngle = 60.0f;

    float origXangle;

    float YForce = 100f;

    float rotationSpeed = 45;
    Vector3 currentEulerAngles;
    float x;
    float y;
    float z;

    float eulerLimit = 0f;

    // Start is called before the first frame update
    void Start()
    {
       // origXangle = this.transform.rotation.x;
    }

   

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.X)) x = 1 - x; //tämän mukaan ase kääntyy
        //if (Input.GetKeyDown(KeyCode.Y)) y = 1 - y;
        //if (Input.GetKeyDown(KeyCode.Z)) z = 1 - z;

        

        if (Input.GetKeyDown(KeyCode.L))
        {
            
            x = -1;
          //  eulerLimit += -0.1f;
            eulerLimit = -10f; //TOIMIVA KULMA
            currentEulerAngles = new Vector3(1, 0, 0) * 10f;
            //apply the change to the gameObject
            transform.eulerAngles = currentEulerAngles;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {

            x = 1;
         //   eulerLimit += 0.1f;
            eulerLimit = 30f; //TOIMIVA KULMA
            currentEulerAngles = new Vector3(1, 0, 0) * 10f;
            //apply the change to the gameObject
            transform.eulerAngles = currentEulerAngles;
        }

        //modifying the Vector3, based on input multiplied by speed and time
        currentEulerAngles += new Vector3(x, y, z) * Time.deltaTime * rotationSpeed;

        if (currentEulerAngles.x < eulerLimit * x && x == 1f)
        {
            //apply the change to the gameObject
            transform.eulerAngles = currentEulerAngles;
        }

        if (currentEulerAngles.x > eulerLimit * x && x == -1f)
        {
            //apply the change to the gameObject
            transform.eulerAngles = currentEulerAngles;
        }
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 24;
        GUI.Label(new Rect(10, 0, 0, 0), "Rotating on X:" + x + " Y:" + y + " Z:" + z, style);

        GUI.Label(new Rect(10, 25, 0, 0), "Transform.eulerAngle: " + transform.eulerAngles, style);
    }


    // Update is called once per frame
    //void Update()
    //{

    //    if (Input.GetKeyDown("o"))
    //    {
    //        if (spin < 0f) spin = 0f; //lopetetaan kierto
    //        UnityEngine.Debug.Log("Käännetään piippua ylös" + spin);
    //        if(spin < limit/2) spin += deltaF1;
    //        else
    //        spin += deltaF2;
    //        if (spin > limit) spin = limit;
    //    }


    //    if (Input.GetKeyDown("l"))
    //    {
    //        if (spin > 0f) spin = 0f; //lopetetaan kierto
    //        UnityEngine.Debug.Log("Käännetään piippua alas" + spin);
    //        if (spin > -limit/2) spin -= deltaF1;
    //        else
    //            spin -= deltaF2;
    //        if (spin < -limit) spin = -limit;
    //    }

    //    if (Input.GetKeyDown("p"))
    //    {
    //        spin = 0f;
    //        float origYangle = this.transform.rotation.y;
    //        float origZangle = this.transform.rotation.z;
    //        this.transform.rotation = new Quaternion(origXangle, origYangle, origZangle, 1);
    //    }

    //        tiltAroundX = jalusta.transform.rotation.x + spin * speed; // spin * speed;
    //     this.transform.Rotate(transform.right, tiltAroundX, Space.World); //TÄMÄ TOIMI!
    //}

    void FixedUpdate()
    {
        // Smoothly tilts a transform towards a target rotation.
        //float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        //float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        // this.transform.rotation  = Quaternion.FromToRotation(Vector3.up, transform.forward);
        //this.transform.rotation = new Quaternion(jalusta.transform.rotation.x, jalusta.transform.rotation.y, jalusta.transform.rotation.z, 1);

        //tiltAroundX = jalusta.transform.rotation.x + spin * speed; // spin * speed;
        ////objectForYaw.Rotate(objectForYaw.up, 1f, Space.World);
        //this.transform.Rotate(transform.right, tiltAroundX, Space.World);

        //float tiltAroundY = jalusta.transform.rotation.y;  // -spin * 1000; // spin * speed;
        //float tiltAroundZ = 180f + jalusta.transform.rotation.z; // -jalusta.transform.rotation.y/18000f; //;  spin * speed;

        //Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
        //Quaternion target = Quaternion.Euler(tiltAroundX, tiltAroundY, tiltAroundZ);
     //   Quaternion target = Quaternion.Euler(tiltAroundX, 0f, 0f);
     //   this.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        // Rotate around Y axis
        //transform.RotateAround(transform.up, Time.deltaTime * -YForce * 100000f);

        //this.transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * smooth);

        // UnityEngine.Debug.Log("Jalustan Y = " + jalusta.transform.rotation.y);

        //GetComponent<Rigidbody>().AddTorque(transform.up * -spin * speed);
    }
}
