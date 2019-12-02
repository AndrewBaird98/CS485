using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public class Projectile : MonoBehaviour
{
    [FormerlySerializedAs("lifetime")] [NotNull] public float lifetime = 0;
    [FormerlySerializedAs("missile")] [NotNull] public bool missile;
    [FormerlySerializedAs("angle ajustement")] [NotNull] public float angleAjust;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }

        if (missile) {
            Vector3 v = GetComponent<Rigidbody2D>().velocity;
            float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - angleAjust, Vector3.forward);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
