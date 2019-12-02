using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        //var hit = collision.gameObject;
       // var hitPlayer = hit.GetComponent<PlayerMove>();
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("PLayer Hit");
            var combat = collision.gameObject.GetComponent<Combat>();
            combat.TakeDamage(10);

            Destroy(gameObject);
        }
    }
}