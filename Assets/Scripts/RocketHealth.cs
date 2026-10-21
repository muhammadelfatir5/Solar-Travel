using UnityEngine;
using UnityEngine.Events;

public class RocketHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
    [SerializeField] float invincibleTime = 1f; // biar ga langsung kena damage beruntun

    public int CurrentHealth { get; private set; }
    public UnityEvent<int, int> onHealthChanged; // (current, max)
    public UnityEvent onDeath;

    float lastHitTime = -999f;
    bool isDead;

    void Start()
    {
        CurrentHealth = maxHealth;
        onHealthChanged?.Invoke(CurrentHealth, maxHealth);
    }

    public void TakeDamage(int amount)
    {
        if (isDead || Time.time < lastHitTime + invincibleTime) return;

        lastHitTime = Time.time;
        CurrentHealth = Mathf.Max(CurrentHealth - amount, 0);
        onHealthChanged?.Invoke(CurrentHealth, maxHealth);

        if (CurrentHealth <= 0) Die();
    }

    void Die()
    {
        isDead = true;
        onDeath?.Invoke();
        gameObject.SetActive(false); // atau Instantiate efek ledakan dulu
    }
}