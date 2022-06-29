using UnityEngine;

public class DamageOnCollide : MonoBehaviour
{
    [SerializeField]
    public float damageAmount;

    [SerializeField]
    private Health.DamageSource damageType;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            health.ApplyDamageFrom(damageAmount, damageType);
        }

        Destroy(gameObject);
    }
}
