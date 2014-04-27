using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public int sceneToLoad = 2;
	public GameObject winText;
	public GameObject deathText;
	public GameObject playerTorch;
	private int winCounter = 0;
	private int deathCounter = 0;
	public static bool dead = false;
	public AudioSource winSound;

	public void Start()
	{
		dead = false;
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.transform.name == "WinTrigger")
		{
			if (winCounter == 0)
			{
				StartCoroutine(winTimer());
				winCounter++;
			}
		}

		if (col.transform.name == "DeathTrigger")
		{
			Debug.Log("Death");
			StartCoroutine(deathTimer());
		}

		if (col.transform.name == "outsideTrigger")
		{
			Application.LoadLevel("Sc_Outside");
		}
	}

	public void OnCollisionEnter2D(Collision2D col)
	{
		if (col.transform.name == "Enemy")
		{
			if (deathCounter == 0)
			{
				StartCoroutine(deathTimer());
				deathCounter++;
			}
		}
	}

	IEnumerator winTimer()
	{
		Instantiate(winText, new Vector3(this.transform.position.x - 3, this.transform.position.y + 1, -2), Quaternion.identity);
		winSound.Play();
		yield return new WaitForSeconds(3);
		Application.LoadLevel(sceneToLoad);
	}

	IEnumerator deathTimer()
	{
		playerTorch.active = false;
		dead = true;
		Instantiate(deathText, new Vector3(this.transform.position.x - 3, this.transform.position.y + 1, -2), Quaternion.identity);
		yield return new WaitForSeconds(3);
		Application.LoadLevel(sceneToLoad-1);
	}
}
