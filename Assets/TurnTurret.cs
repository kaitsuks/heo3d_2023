using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTurret : MonoBehaviour
{
    float xFactor;
    float xFinal;
    float xRot;
    float yRot;
    float zRot;
    float wRot;
    float xAngle, yAngle, zAngle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("y")) xFactor += 0.01f;
        if (Input.GetKeyDown("u")) xFactor -= 0.01f;



        xRot = transform.rotation.x;
        yRot = transform.rotation.y;
        zRot = transform.rotation.z;
        wRot = transform.rotation.w;
        xFinal = yRot + xFactor / 20; //Huom. x vaihdettu y:ksi!

        //transform.rotation = new Quaternion(xRot, xFinal, zRot, wRot);
        //sama rotatella
        transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        //Debug.Log("XFACTOR " + xFactor + " YROT  " + yRot);
    }
}
