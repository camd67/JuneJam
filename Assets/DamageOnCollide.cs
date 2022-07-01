using UnityEngine;

public class DamageOnCollide : MonoBehaviour
{
    [SerializeField]
    public float damageAmount;

    [SerializeField]
    private Health.DamageSource damageType;

    [SerializeField]
    private bool destroyOnAnyCollision;


    private void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleCollision(other.gameObject);
    }

    private void HandleCollision(GameObject other)
    {
        if (other.TryGetComponent(out Health health))
        {
            if (health.ApplyDamageFrom(damageAmount, damageType))
            {
                Destroy(gameObject);
            }
        }
        else if (destroyOnAnyCollision)
        {
            Destroy(gameObject);
        }
    }
}
