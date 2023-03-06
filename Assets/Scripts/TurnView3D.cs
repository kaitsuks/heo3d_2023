using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

[AddComponentMenu("Kaitsu/Movement/Turn View 3D")]
public class TurnView3D : MonoBehaviour
{
    public float speed = 5f;
    private float spin = 0f;
    private float smooth = 5.0f;
    private float tiltAngle = 0.0f;
    public float tiltAroundZ = 0f;
    public float tiltAroundX = 0f;
    public float tiltAroundY = 0f;
    Quaternion target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spin = 1f;
        if (Input.GetKey("n"))
        {
            UnityEngine.Debug.Log("Käännetään kamera plussaan");
            //spin += 0.2f;
            //rotate the object about the Y axis in the positive direction
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * speed * spin, Space.World);
        }

        if (Input.GetKey("m"))
        {
            UnityEngine.Debug.Log("Käännetään kamera miinukseen");
            //spin -= 0.2f;
            //rotate the object about the Y axis in the negative direction
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * speed * spin, Space.World);
        }
        
        //tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        //tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
        //Turn180();

        if (Input.GetKey("b"))
        {
            Turn180();
        }

        if (Input.GetKey("c"))
        {
            TurnBack();
        }

        if (Input.GetKey("x"))
        {
            TurnAround();
        }
    }

    void Turn180()
    {
        tiltAroundZ = 0f;
        tiltAroundX = 30f;
        tiltAroundY = 0f;
        UnityEngine.Debug.Log("Käännetään kamera xxx astetta");
        // Smoothly tilts a transform towards a target rotation.
        // Rotate the cube by converting the angles into a quaternion.
        target = Quaternion.Euler(tiltAroundX, tiltAroundY, tiltAroundZ);
        // Dampen towards the target rotation
       transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        //tämä toimii pyörien ympäri
        //transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
    }

    void TurnBack()
    {
     tiltAroundZ = 0f;
     tiltAroundX = 30f;
     tiltAroundY = 180f;
    UnityEngine.Debug.Log("Käännetään kamera takaisin eteen");
        // Smoothly tilts a transform towards a target rotation.
        // Rotate the cube by converting the angles into a quaternion.
        target = Quaternion.Euler(tiltAroundX, tiltAroundY, tiltAroundZ);
        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        //tämä toimii pyörien ympäri
        //transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
    }

    void TurnAround()
    {
        //tämä toimii pyörien ympäri
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
    }
}
