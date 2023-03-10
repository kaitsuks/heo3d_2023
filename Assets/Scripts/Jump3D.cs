using UnityEngine;
using System.Collections;

[AddComponentMenu("Kaitsu/Movement/Jump3D")]
[RequireComponent(typeof(Rigidbody))]
public class Jump3D : Physics3DObject
{	
	[Header("Jump setup")]
	// the key used to activate the push
	public KeyCode key = KeyCode.Space;

	// strength of the push
	public float jumpStrength = 10f;

	[Header("Ground setup")]
	//if the object collides with another object tagged as this, it can jump again
	public string groundTag = "Ground";

	//this determines if the script has to check for when the player touches the ground to enable him to jump again
	//if not, the player can jump even while in the air
	public bool checkGround = true;

	private bool canJump = true;

   // Animator animator;

    private void Start()
    {
      //  animator = GetComponentInChildren<Animator>();
    }


    // Read the input from the player
    void Update()
	{
        if (Input.GetKeyDown("space"))
        //v?lily?nti - tai muu n?pp?in
        {
            // animator.SetTrigger("Trigger1");
            Debug.Log("I am alive!");
        }

        if (canJump
			&& Input.GetKeyDown(key))
		{
			// Apply an instantaneous upwards force
			rigidbody.AddForce(Vector2.up * jumpStrength, ForceMode.Impulse);
			canJump = !checkGround;
		}
	}

	private void OnCollisionEnter(Collision collisionData)
	{
		if(checkGround
			&& collisionData.gameObject.CompareTag(groundTag))
		{
			canJump = true;
          //  animator.SetTrigger("Trigger2");
        }
	}

    private void LateUpdate()
    {
        
    }
}