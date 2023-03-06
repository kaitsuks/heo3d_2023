using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//[AddComponentMenu("")]
public class UIItemScript : MonoBehaviour
{
	public Image resourceIcon;
	public Text resourceAmount;
	//public Sprite s;

	public void ShowNumber(int n)
	{
		resourceAmount.text = n.ToString();
		UnityEngine.Debug.Log("UIitem kertoo " + resourceAmount);
	}

	public void DisplayIcon(Sprite s)
	{
		resourceIcon.sprite = s;
	}

	//public void DisplayIcon()
	//{
	//	resourceIcon.sprite = s;
	//}
}
