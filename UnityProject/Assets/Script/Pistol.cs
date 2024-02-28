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
            _bulletSpawnPoint = transform.Find("Barrel").transform;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                var ammunition = _ammunitionHandler.Ammunition;
                if (ammunition == 0)
                {
                    return;
                }

                _ammunitionHandler.Ammunition = ammunition - 1;
                var newBullet = Instantiate(bullet, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
                newBullet.ReadyToFly = true;
            }

        }

        // LateUpdate is called once per frame after Update
        private void LateUpdate()
        {
            // Update the rotation of the bullet spawn point to match the rotation of the camera
            _bulletSpawnPoint.rotation = Camera.main.transform.rotation;
        }
    }
}
