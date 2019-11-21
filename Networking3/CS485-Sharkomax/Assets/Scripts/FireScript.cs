using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Networking;
namespace Script
{
    public class FireScript : NetworkBehaviour
    {
        public float speed = 30f;
	    public GameObject bulletPrefab;
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


	[Command]
        void CmdFire()
        {
            // This [Command] code is run on the server!

            // create the bullet object locally
            var bullet = (GameObject)Instantiate(
                 bulletPrefab,
                 transform.position - transform.forward,
                 Quaternion.identity);

            bullet.GetComponent<Rigidbody>().AddForce(new Vector3(speed, 0, 0), ForceMode.VelocityChange);
            // spawn the bullet on the clients
            NetworkServer.Spawn(bullet);

            // when the bullet is destroyed on the server it will automaticaly be destroyed on clients
            Destroy(bullet, 2.0f);
        }


        // Update is called once per frame
        private void Update()
        {
			//moveCharacter();

		     if (!isLocalPlayer)
               return;

            if (Input.GetKeyDown("mouse 0"))
               {
            // Command function is called from the client, but invoked on the server
                 CmdFire();
               }

		//		var angleInput = Input.GetAxis("Horizontal");
				//            float power = Input.GetAxis("Vertical");
		//		var rotation = cannon.transform.eulerAngles;

		//		rotation.z = -angleInput * rotationSpeed;
		//		cannon.transform.Rotate(rotation);

//				_timer += Time.deltaTime;
  //              if (!Input.GetKeyDown("mouse 0") || !(_timer >= 0.2)) return;

//				var angle = cannon.transform.eulerAngles;
//				_timer = 0;
//				var shotPosition = spawnPoint.transform.position;
//				var newBullet = Instantiate(bullet, shotPosition, cannon.transform.rotation);
//				Debug.Log(angle);
//				newBullet.GetComponent<Rigidbody2D>()
//					.AddForce((shotPosition - cannon.transform.position) * powerScale);


			



        }

        
		void moveCharacter()
		{
			if (Input.GetKey("a"))
			{
				//faaaloat horizontal = Input.GetAxis("Horizontal");
				Vector2 position = transform.position;
				position.x = position.x + 0.1f * -1;
				transform.position = position;
			}
			if (Input.GetKey("d"))
			{
				//faaaloat horizontal = Input.GetAxis("Horizontal");
				Vector2 position = transform.position;
				position.x = position.x + 0.1f * +1;
				transform.position = position;
			}
		}
	}
}

    