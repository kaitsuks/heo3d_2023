using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://gist.github.com/HuM4NoiD
class MovementController : MonoBehaviour
{

    private Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 dir = transform.forward; // Choose direction by user input or randomly generate a direction
        // Ensure that the dir passed to MoveTo is normalized
        MoveTo(dir, 5f, 4f);
    }

    void MoveTo(Vector3 dir, float steerSpeed, float turnSpeed)
    {
        if (dir.sqrMagnitude > 0f)
        {
            var rotation = Quaternion.LookRotation(dir, transform.up);
            body.MoveRotation(Quaternion.Lerp(body.rotation, rotation, Time.deltaTime * turnSpeed));
            var velocity = dir * steerSpeed;
            body.MovePosition(transform.position + velocity * Time.deltaTime);
        }
    }
}