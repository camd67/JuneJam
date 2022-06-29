using UnityEngine;

namespace Enemy.Ghost
{
    public class OnGhostDeath : MonoBehaviour
    {
        [SerializeField]
        private GameObject powerupPrefab;

        [SerializeField, Range(0, 1f)]
        private float dropChance;

        private void Awake()
        {
            GetComponent<Health>().OnDeath += () =>
            {
                if (Random.value <= dropChance)
                {
                    Instantiate(powerupPrefab, transform.position, Quaternion.identity);
                }
            };
        }
    }
}
