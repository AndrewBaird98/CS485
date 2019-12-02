using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour
{
	private bool canJump = true;
	Vector2 myvector = new Vector2(0, 0);
	//public GameObject prefabObject;

        public float speed = 30f;
	    public GameObject bulletPrefab;
	



	// Start is called before the first frame update
	void Start()
    {
		
	}

    [Command]
    void CmdFire()
    {
        // This [Command] code is run on the server!

        // create the bullet object locally
        var bullet = (GameObject)Instantiate(
             bulletPrefab,
                          transform.position - transform.forward,
                          //transform.position - new Vector3 (5,0,0),

             Quaternion.identity);

        //var worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.x, this.transform.position.z));
        //var pz = worldMousePosition - this.transform.position;
        //pz.Normalize();


        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pz = worldMousePosition - this.transform.position;
        pz.z = 0;
        pz.x *= speed;
        pz.y *= speed;
        bullet.GetComponent<Rigidbody>().AddForce(pz, ForceMode.VelocityChange);
        // spawn the bullet on the clients
        NetworkServer.Spawn(bullet);

        // when the bullet is destroyed on the server it will automaticaly be destroyed on clients
        Destroy(bullet, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {

   	 	   if (!isLocalPlayer)
        		    return;

        if (Input.GetKeyDown("mouse 0"))
        {
            // Command function is called from the client, but invoked on the server
            CmdFire();
        }
        //Debug.Log(GameObject.Find("big-crate").transform.position.x);


        //Getting cursor position and place a prefab at the position
        //if (Input.GetKeyDown("mouse 0"))
        //{
        //	//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //	//Instantiate(prefabObject, new Vector2(ray.origin[0], ray.origin[1]), Quaternion.identity);
        //	Instantiate(prefabObject, new Vector2(GameObject.Find("big-crate").transform.position.x, GameObject.Find("big-crate").transform.position.y), Quaternion.identity);
        //}


        //Prevents an object from double jumping
        if (GetComponent<Rigidbody2D>().velocity == myvector){
			canJump = true;
		}


		if (canJump && Input.GetKeyDown("space"))
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
			canJump = false;
		}


        
		if (Input.GetKey("a"))
		{
			Vector2 position = transform.position;
			position.x = position.x - 0.05f;
			transform.position = position;
		}

        if (Input.GetKey("d"))
		{
			Vector2 position = transform.position;
			position.x = position.x + 0.05f;
			transform.position = position;
		}
        

	}	

}
