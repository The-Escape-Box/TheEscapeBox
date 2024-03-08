using UnityEngine;

namespace Script
{
    public class Pistol : MonoBehaviour
    {
        public Bullet bullet;
        private AmmunitionHandler _ammunitionHandler;
        private Transform _bulletSpawnPoint;

        // Start is called before the first frame update
        private void Start()
        {
            _ammunitionHandler = AmmunitionHandler.Instance;
            _bulletSpawnPoint = transform.Find("BulletSpawnPoint").transform;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Time.timeScale == 0)
            {
                return;
            }

            if (!Input.GetKeyDown(KeyCode.Mouse0)) return;
            
            var ammunition = _ammunitionHandler.Ammunition;
            if (ammunition == 0)
            {
                return;
            }

            _ammunitionHandler.Ammunition = ammunition - 1;
            var newBullet = Instantiate(bullet, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
            newBullet.ReadyToFly = true;

        }

        // LateUpdate is called once per frame after Update
        private void LateUpdate()
        {
            // Example code using Euler angles
            Vector3 playerViewEulerAngles = Camera.main.transform.eulerAngles;
            transform.localEulerAngles = new Vector3(-playerViewEulerAngles.x, 0f, 0f);
        }
    }
}
