using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour 
{
	public AudioSource buttonHoverSound;

	public void OnMouseEnter()
	{
		renderer.material.color = Color.red;
		buttonHoverSound.Play();
	}

	public void OnMouseExit()
	{
		renderer.material.color = Color.white;
	}

	public void OnMouseDown()
	{
		buttonHoverSound.Play();
		if (this.gameObject.name == "PlayButton")
		{
			Application.LoadLevel("Sc_01");
		}

		if (this.gameObject.name == "QuitButton")
		{
			Application.Quit();
		}
	}
}
