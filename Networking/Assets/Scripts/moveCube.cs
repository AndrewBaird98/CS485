using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class moveCube : NetworkBehaviour
{
   
    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
    // Update is called once per frame

    public float speed = 20f;

    void Update()
    {
        if (!isLocalPlayer)
            return;

        Vector2 pos = this.transform.position;

        if (Input.GetKey("w"))
        {
            Debug.Log("pressed w");

            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }


        this.transform.position = pos;
    }

}
