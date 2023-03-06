using UnityEngine;
using System.Collections;

[AddComponentMenu("Kaitsu/Attributes/Bullet 3D")]
public class BulletAttribute3D : MonoBehaviour
{
	[HideInInspector]
	public int playerId;

	//This will create a dialog window asking for which dialog to add
	private void Reset()
	{
		//Utils.Collider2DDialogWindow(this.gameObject, true);
	}
}
