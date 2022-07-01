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
    public float maxHealth;

    [SerializeField, Tooltip("Don't set this, it will be auto-initialized in the script")]
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    ///     Event firing upon death (aka health drops at or below 0)
    /// </summary>
    public event Action OnDeath;

    /// <summary>
    ///     Event firing whenever health changes.
    ///     Provides the current health to the event.
    /// </summary>
    public event Action<float> OnHealthChange;

    public bool ApplyDamageFrom(float amount, DamageSource source)
    {
        if (!takesDamageFrom.HasFlag(source))
        {
            return false;
        }

        currentHealth -= amount;

        OnHealthChange?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }

        return true;
    }
}
