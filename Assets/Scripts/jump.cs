using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
	private bool canJump = true;
	Vector2 myvector = new Vector2(0, 0);
	public GameObject prefabObject;


	



	// Start is called before the first frame update
	void Start()
    {
		
	}



        // Update is called once per frame
    void Update()
    {

       
		//Debug.Log(GameObject.Find("big-crate").transform.position.x);


		//Getting cursor position and place a prefab at the position
		if (Input.GetKeyDown("mouse 0"))
		{
			//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//Instantiate(prefabObject, new Vector2(ray.origin[0], ray.origin[1]), Quaternion.identity);
			Instantiate(prefabObject, new Vector2(GameObject.Find("big-crate").transform.position.x, GameObject.Find("big-crate").transform.position.y), Quaternion.identity);
		}
		

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
