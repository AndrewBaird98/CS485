using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Character_Behavior : NetworkBehaviour
{
    private bool canJump = true;
    public Rigidbody2D rb;
	public SpriteRenderer rend;
	public float speed = 5;
	public float maxJump;
	private bool isGrounded = false;
	public Animator animator;

	// Use this for initialization
	void Start () {
        if (!isLocalPlayer)
            return;
        rend = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
	}

    Vector2 myvector = new Vector2(0, 0);
    // Update is called once per frame
    void Update () {
        if (!isLocalPlayer)
            return;

        if (GetComponent<Rigidbody2D>().velocity == myvector)
        {
            canJump = true;
        }


        if (canJump && Input.GetKeyDown("space"))
        {
            Jump();
           // GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
            canJump = false;
        }


  //      if (Input.GetKeyDown("space") && isGrounded){
		//	Jump();
		//}
                float h = Input.GetAxis("Horizontal") * speed;
		rb.velocity = new Vector2(h, rb.velocity.y);
		if (Input.GetKey("a") || Input.GetKey("d"))
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
       // Debug.Log("jumping");
		rb.velocity += new Vector2(0, maxJump);
	}

    //void OnCollisionEnter2D(Collision2D col){
    //if(col.gameObject.CompareTag("Ground")){
    //		isGrounded = true;
    //	}
    //}

    //void OnCollisionExit2D(Collision2D col){
    //	if(col.gameObject.CompareTag("Ground")){
    //		isGrounded = false;
    //	}
    //}

    public static void Shoot(GameObject bullet)
    {
       
      Character_Behavior Instance = new Character_Behavior();
      Instance.CmdDoShoot(bullet);

    }

    [Command]
    void CmdDoShoot(GameObject bullet)
    {
       
        Destroy(bullet, 5f);
        NetworkServer.Spawn(bullet);

    }
   


}

