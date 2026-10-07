using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    [SerializeField] int damage = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out RocketHealth health))
            health.TakeDamage(damage);
    }
}