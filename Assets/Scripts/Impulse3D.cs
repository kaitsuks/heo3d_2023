using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Impulse3D : Physics3DObject

{
    Vector3 shootVector3D;
    public float shootSpeed = 5f;
    float x, y, z;

    // Start is called before the first frame update
    void Start()
    {
        ///Voidaan tehdä myös näin
        x = UnityEngine.Random.Range(0, 1);
        y = UnityEngine.Random.Range(0, 1);
        z = UnityEngine.Random.Range(0, 1);
        shootVector3D = new Vector3(x, y, z);

        ///Voidaan tehdä myös näin
        //shootVector3D = UnityEngine.Random.insideUnitSphere;
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(shootVector3D * shootSpeed, ForceMode.Impulse);
    }
}
