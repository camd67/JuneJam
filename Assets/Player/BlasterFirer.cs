using Player.InputSystem;
using UnityEngine;

namespace Player
{
    public class BlasterFirer : MonoBehaviour
    {
        [SerializeField]
        private GameObject bulletPrefab;

        [SerializeField]
        private Transform muzzleLocation;

        [SerializeField]
        private float fireDelay;

        private PlayerInput playerInput;

        private float timeSinceLastFire;

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
        }

        private void Update()
        {
            if (playerInput.isFiring)
            {
                if (timeSinceLastFire >= fireDelay)
                {
                    FireWeapon();
                    timeSinceLastFire = -Time.deltaTime;
                }
            }

            timeSinceLastFire += Time.deltaTime;
        }

        private void FireWeapon()
        {
            var projectile = Instantiate(bulletPrefab, muzzleLocation.position, muzzleLocation.transform.rotation);
        }
    }
}
