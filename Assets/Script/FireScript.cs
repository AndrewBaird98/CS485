using UnityEngine;
using UnityEngine.Serialization;

namespace Script
{
    public class FireScript : MonoBehaviour
    {

        [FormerlySerializedAs("SpawnPoint")] public GameObject spawnPoint;
        [FormerlySerializedAs("Cannon")] public GameObject cannon;
        [FormerlySerializedAs("Bullet")] public GameObject bullet;

        [FormerlySerializedAs("Rotation Speed")]
        public float rotationSpeed;
        [FormerlySerializedAs("Power Scale")]
        public float powerScale;


        private float _timer;
        // Start is called before the first frame update
        private void Start()
        {
            _timer = 0.0f;
        }

        // Update is called once per frame
        private void Update()
        {
            var angleInput = Input.GetAxis("Horizontal");
//            float power = Input.GetAxis("Vertical");
            var rotation = cannon.transform.eulerAngles;

            rotation.z = -angleInput * rotationSpeed;
            cannon.transform.Rotate(rotation);

            _timer += Time.deltaTime;
            if (!Input.GetKey("space") || !(_timer >= 0.2)) return;

            var angle = cannon.transform.eulerAngles;
            _timer = 0;
            var shotPosition = spawnPoint.transform.position;
            var newBullet = Instantiate(bullet, shotPosition, cannon.transform.rotation);
            Debug.Log(angle);
            newBullet.GetComponent<Rigidbody>()
                .AddForce((shotPosition - cannon.transform.position)  * powerScale);
        }
    }
}
