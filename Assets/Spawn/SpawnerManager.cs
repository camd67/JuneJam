using UnityEngine;

namespace Spawn
{
    public class SpawnerManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject toSpawn;

        [SerializeField]
        private float spawnRatePerSecond;

        [SerializeField]
        private int maxSpawnCount = -1;

        private int totalSpawnCount;

        private void Awake()
        {
            InvokeRepeating(nameof(SpawnGhost), 0, 1 / spawnRatePerSecond);
        }

        private void OnDestroy()
        {
            CancelInvoke(nameof(SpawnGhost));
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.2f);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, 0.5f);
        }
#endif

        private void SpawnGhost()
        {
            if (maxSpawnCount != -1 && totalSpawnCount >= maxSpawnCount)
            {
                CancelInvoke(nameof(SpawnGhost));
                return;
            }

            Instantiate(toSpawn, transform.position, Quaternion.identity);
            totalSpawnCount++;
        }
    }
}
