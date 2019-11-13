using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{

	private int _life;
	
	private static readonly int Color = Shader.PropertyToID("_Color");
    // Start is called before the first frame update
    void Start()
    {
        _life = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter(Collision other) {
		_life -= 1;
		gameObject.GetComponent<Renderer>().material.SetColor(Color, new Color(0f, (_life / 10f), 0f));

		if (_life <= 0) {
			Destroy(gameObject);
		}
	}
}
