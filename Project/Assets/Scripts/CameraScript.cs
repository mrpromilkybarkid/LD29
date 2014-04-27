using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{
	public GameObject player;

	public void Update()
	{
		this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
	}
}
