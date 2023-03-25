using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderController : MonoBehaviour
{
    //public Rigidbody rbGreenCylinder;
    private Rigidbody rbGreenCylinder;
    public Rigidbody rbRedCylinder;
    public Rigidbody rbYellowCylinder;

    // Start is called before the first frame update
    void Start()
    {
        rbGreenCylinder = GameObject.Find("CylinderGreen").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
