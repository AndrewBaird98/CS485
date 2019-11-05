using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	
	Vector2 moveDirection;

	// Start is called before the first frame update
	void Start()
    {
		Object.Destroy(gameObject, 2.0f);
		moveDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
		//moveDirection.z = 0;
		//moveDirection.Normalize();
		GetComponent<Rigidbody2D>().AddForce(moveDirection, ForceMode2D.Impulse);

	}

    // Update is called once per frame
    void Update()
    {
		//transform.position = transform.position + moveDirection * 10f * Time.deltaTime;
	}

	



}
