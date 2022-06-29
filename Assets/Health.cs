using System;
using UnityEngine;

/// <summary>
///     Maintains the health of a given entity.
///     If you don't want your entity to be destroyed, set its
///     damage receiver to nothing.
/// </summary>
public class Health : MonoBehaviour
{
    [Flags, Serializable]
    public enum DamageSource
    {
        Nothing = 0,
        All = 1 << 0,
        Player = 1 << 1,
        Enemies = 1 << 2,
    }

    [SerializeField]
    private DamageSource takesDamageFrom;

    [SerializeField, Min(0f)]
    private float maxHealth;

    [SerializeField, Tooltip("Don't set this, it will be auto-initialized in the script")]
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public event Action OnDeath;

    public void ApplyDamageFrom(float amount, DamageSource source)
    {
        if (!takesDamageFrom.HasFlag(source))
        {
            return;
        }

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
