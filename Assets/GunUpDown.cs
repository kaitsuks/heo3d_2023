using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUpDown : MonoBehaviour
{
    float xFactor;
    float xFinal;
    float xRot;
    float yRot;
    float zRot;
    float wRot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i")) xFactor += 0.01f;
        if (Input.GetKeyDown("k")) xFactor -= 0.01f;

        

        xRot = transform.rotation.x;
        yRot = transform.rotation.y;
        zRot = transform.rotation.z;
        wRot = transform.rotation.w;
        xFinal = xRot + xFactor / 20;

        transform.rotation = new Quaternion(xFinal, yRot, zRot, wRot );
        Debug.Log("XFACTOR " + xFactor + " XROT  " + xRot);
    }
}
