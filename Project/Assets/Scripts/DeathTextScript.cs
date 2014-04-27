using UnityEngine;
using System.Collections;

public class DeathTextScript : MonoBehaviour 
{
	GameObject player;

	public void Start()
	{
		player = GameObject.Find("Player");
	}

	public void Update()
	{
		this.transform.position = new Vector3(player.transform.position.x - 3, player.transform.position.y, -2);
	}
}
