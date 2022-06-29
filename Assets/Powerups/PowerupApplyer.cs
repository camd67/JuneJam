using Player;
using UnityEngine;

namespace Powerups
{
    public class PowerupApplyer : MonoBehaviour
    {
        [SerializeField]
        private float damageMultiplierPerPickup;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.TryGetComponent(out BlasterFirer blasterFirer))
            {
                blasterFirer.damageMultiplier *= damageMultiplierPerPickup;
                Destroy(gameObject);
            }
        }
    }
}
