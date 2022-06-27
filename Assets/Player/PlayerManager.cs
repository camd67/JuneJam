using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static Transform playerTransform;

        private void Awake()
        {
            playerTransform = transform;
        }
    }
}
