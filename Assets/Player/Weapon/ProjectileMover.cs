using UnityEngine;

namespace Player.Weapon
{
    public class ProjectileMover : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        private void Awake()
        {
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }
    }
}
