using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Behavior : MonoBehaviour {

	public Rigidbody2D rb;
	public SpriteRenderer rend;
	public float speed = 5;
	public float maxJump;
	private bool isGrounded = false;
	public Animator animator;

	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space") && isGrounded){
			Jump();
		}
                float h = Input.GetAxis("Horizontal") * speed;
		rb.velocity = new Vector2(h, rb.velocity.y);
		if (Input.GetKey("left") || Input.GetKey("right"))
		{
			animator.SetBool("direction", true);
		}
		else
			animator.SetBool("direction", false);
		if (h > 0)
		{
			rend.flipX = false;
		}
		if (h < 0)
		{
			rend.flipX = true;
		}
	}

	void Jump() {
		rb.velocity += new Vector2(0, maxJump);
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.CompareTag("Ground")){
			isGrounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D col){
		if(col.gameObject.CompareTag("Ground")){
			isGrounded = false;
		}
	}
}

