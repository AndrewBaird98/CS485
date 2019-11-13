using System;
using UnityEngine;

namespace Script
{
    public class BulletScript : MonoBehaviour
    {
        private float _lifeTime;

        private static readonly int Color = Shader.PropertyToID("_Color");

        // Start is called before the first frame update
        void Start()
        {
            _lifeTime = 5;

        }

        // Update is called once per frame
        void Update()
        {
            _lifeTime -= Time.deltaTime;
            if (_lifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter(Collision other) {
            gameObject.GetComponent<Renderer>().material.SetColor(Color, new Color(0.58f, 0f, 0f));
            var rb = gameObject.GetComponent<Rigidbody2D>();
            
        }
    }
}
