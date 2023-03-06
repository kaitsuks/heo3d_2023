using UnityEngine;
using System.Collections;
using System.Diagnostics;

[AddComponentMenu("Kaitsu/Attributes/Modify Health Attribute 3D")]
public class ModifyHealthAttribute3D : MonoBehaviour
{

	public bool destroyWhenActivated = false;
	public int healthChange = -1;
    public GameObject tuhottava;

    private void Start()
    {

    }

        //This will create a dialog window asking for which dialog to add
        private void Reset()
	{
		//Utils.Collider2DDialogWindow(this.gameObject, true);
	}

	// This function gets called everytime this object collides with another
	private void OnCollisionEnter(Collision collisionData)
	{
		OnTriggerEnter(collisionData.collider);
	}

	private void OnTriggerEnter(Collider colliderData)
	{
		// UnityEngine.Debug.Log(colliderData);
		//UnityEngine.Debug.Log("OSUI!");
		HealthSystemAttribute healthScript = colliderData.gameObject.GetComponent<HealthSystemAttribute>();
		if(healthScript != null)
		{
			// UnityEngine.Debug.Log("OSUI KYLLÄ!");
			// subtract health from the player
			healthScript.ModifyHealth(healthChange);
			//healthScript.Testi();

			if (destroyWhenActivated)
			{
				Destroy(this.gameObject);
			}
		}
	}

    public void DestroyHealth()
    {
        HealthSystemAttribute healthScript = tuhottava.GetComponent<HealthSystemAttribute>();
        if (healthScript != null)
        {
            // subtract health from the player
            healthScript.ModifyHealth(healthChange);
        }
    }
}
