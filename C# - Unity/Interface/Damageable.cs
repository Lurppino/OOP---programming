using UnityEngine;

public interface IDamageable
{
    int Health { get; set; }
    int Defense { get; set; }
    void Die();
    void TakeDamage(int amount);
    void RestoreHealth(int amount);
}


