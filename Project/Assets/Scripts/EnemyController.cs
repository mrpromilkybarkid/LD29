using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
	public GameObject player;
	public float moveSpeed = 3f;
	public float maxDist = 5f;
	public bool seenPlayer = false;

	public void Update()
	{
		if (Vector2.Distance(this.transform.position, player.transform.position) <= maxDist || seenPlayer)
		{
			seenPlayer = true;
			this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
		}
	}
}
