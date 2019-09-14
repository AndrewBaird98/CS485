using UnityEngine;
using System.Collections;

public class ProjController : MonoBehaviour
{


    void Start()
    {

       
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = (Input.mousePosition - sp).normalized;
            Debug.Log("Click registered.");
        
        }
    }


}