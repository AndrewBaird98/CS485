using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
        public Rigidbody2D rb;
	public float speed;
	public float maxJump;
	private bool isGrounded = false;

	// Use this for initialization
	void Start () {
		rb.velocity += new Vector2(speed,0);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space") && isGrounded){
			Jump();
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
