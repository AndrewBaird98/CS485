using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Shoot : NetworkBehaviour
{

    private float range = 200;
    private float dmg = 15;
    [SerializeField] private Transform camTransform;
    private RaycastHit hit;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        CheckifShooting();

    }


    void CheckifShooting()
    {

        if (!isLocalPlayer)
            return;

        //shots pressing the left mouse click
        if (Input.GetKeyDown(KeyCode.Mouse0))
            shooting();


    }


    void shooting()
    {

        if (Physics.Raycast(camTransform.TransformPoint(0, 0, 0.5f), camTransform.forward, out hit, range))
            Debug.Log(hit.transform.tag);

        if(hit.transform.tag=="Player")
        {
            string id = hit.transform.name;

            CmdTellServerWhoWasShot(id, dmg);

        }

    }

    [Command]
    void CmdTellServerWhoWasShot(string id2, float damage)
    {

        GameObject go = GameObject.Find(id2);

        //Apply the damage and health

    }
}
