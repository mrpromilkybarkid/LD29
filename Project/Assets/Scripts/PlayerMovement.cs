using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float moveSpeed = 10f;
	public bool facingRight = true;
	public bool grounded = false;
	public Transform groundCheck;
	public float groundRadius = 0.5f;
	public LayerMask ground;
	public float jumpForce = 700f;
	public bool doubleJump = false;
	public Animator anim;
	public AudioSource jumpSound;

	public void Start()
	{
		Animator anim = this.GetComponent<Animator>();
	}

	public void FixedUpdate() 
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground);

		if (grounded)
		{
			doubleJump = false;
		}

		float move = Input.GetAxis("Horizontal");

		anim.SetFloat("speed", Mathf.Abs(move));
		anim.SetBool("grounded", grounded);

		rigidbody2D.velocity = new Vector2(move * moveSpeed, rigidbody2D.velocity.y);

		if (move > 0 && !facingRight)
		{
			Flip();
		}
		else if (move < 0 && facingRight)
		{
			Flip();
		}

		if (PlayerController.dead)
		{
			jumpSound.volume = 0;
		}
	}

	public void Update()
	{
		if ((grounded || !doubleJump) && Input.GetButtonDown("Jump"))
		{
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
			jumpSound.Play();

			if (!doubleJump && !grounded)
			{
				doubleJump = true;
			}
		}
	}

	public void Flip()
	{
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
