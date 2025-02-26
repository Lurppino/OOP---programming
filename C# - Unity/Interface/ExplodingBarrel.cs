using UnityEngine;
using static Explodable;

public class ExplodingBarrel : MonoBehaviour, IExplodable, IDamageable
{
    
    // IDamageable
    public int Health { get; set; }
    public int Defense { get; set; }
    public void Die()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int amount)
    {
        Health -=amount;
        if (Health <= 0)
        {
            Die();
        }
    }
    public void RestoreHealth(int amount)
    {
        Health += amount;
    }

    // IExplodable
    public float Mass { get; set; }
    public float ExplosiveForce { get; set; }
    public float FuseDelay { get; set; }

    private float fuseTimer;

    private void Start()
    {
        Health = 100;
        Defense = 10;

        FuseDelay = 5f;
        fuseTimer = FuseDelay;
    }

    public void Explode()
    {
        Debug.Log("BOOM!");
        Destroy(gameObject);
    }

    private void Update()
    {
        if (fuseTimer > 0)
        {
            fuseTimer -= Time.deltaTime;
            if (fuseTimer <= 0)
            {
                Explode();
            }
        }
    }
}

