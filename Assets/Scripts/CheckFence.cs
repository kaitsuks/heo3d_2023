using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFence : MonoBehaviour
{
    Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Controlled"))
           
        {
            GameManager.DetectPC(true);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Controlled"))

        {
            GameManager.DetectPC(true);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
