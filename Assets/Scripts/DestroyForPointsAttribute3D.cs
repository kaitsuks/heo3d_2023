using UnityEngine;
using System.Collections;

[AddComponentMenu("Kaitsu/Attributes/Destroy For Points 3D")]
public class DestroyForPointsAttribute3D : MonoBehaviour
{
	public int pointsWorth = 1;

	private UIScript userInterface;

	private Elamat elamat;

	private void Awake()
	{
		// Find the UI in the scene and store a reference for later use
		userInterface = GameObject.FindObjectOfType<UIScript>();
		elamat = GetComponent<Elamat>();
	}
	

	//This will create a dialog window asking for which dialog to add
	private void Reset()
	{
		//Utils.Collider2DDialogWindow(this.gameObject, false);
	}
	
	//duplication of the following function to accomodate both trigger and non-trigger Colliders
	private void OnCollisionEnter(Collision collisionData)
	{
		OnTriggerEnter(collisionData.collider);
	}

	// This function gets called everytime this object collides with another trigger
	private void OnTriggerEnter(Collider collisionData)
	{
		// is the other object a Bullet?
		if(collisionData.gameObject.CompareTag("Bullet"))
		{
			Debug.Log("Tag = Bullet"); //MIKSI BULLET TAGEJA?

			if (userInterface != null)
			{
				// add one point
				BulletAttribute3D b = collisionData.gameObject.GetComponent<BulletAttribute3D>();
				if(b != null)
				{
					userInterface.AddPoints(b.playerId, pointsWorth);
					elamat.elamia--;
				}
				else
				{
					Debug.Log("Use a BulletAttribute on one of the objects involved in the collision if you want one of the players to receive points for destroying the target.");
				}
			}
			else
			{
				Debug.Log("There is no UI in the scene, hence points can't be displayed.");
			}

			//Jos elämiä ei enää jäljellä
			if (elamat.elamia < 1)
			{
				// then destroy this object
				GameManager.ChangeEnemiesCount(-1);
				Destroy(gameObject);
			}
		}
	}
}
