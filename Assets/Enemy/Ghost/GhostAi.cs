using Player;
using UnityEngine;

namespace Enemy.Ghost
{
    public class GhostAi : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        [SerializeField]
        private float rotationSpeed;

        private void Update()
        {
            if (PlayerManager.playerTransform == null)
            {
                return;
            }

            var t = transform;
            var ghostPos = t.position;
            var targetPos = PlayerManager.playerTransform.position;
            var diffWithTarget = targetPos - ghostPos;

            var lookAt = Quaternion.LookRotation(diffWithTarget);
            t.rotation = Quaternion.Slerp(t.rotation, lookAt, rotationSpeed * Time.deltaTime);

            t.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
    }
}
