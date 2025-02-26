using UnityEngine;
using static IMovableScript;
using static ITurnableScript;
using static UnitStats;

public class EnemyUnit : MonoBehaviour, IUnitStats, IMovable, ITurnable, IDamageable
{
    // Variables for IMoveable, ITurnable
    int speed = 5;
    int turnSpeed = 5;

    // IUnitStats
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Endurance { get; set; }

    // IDamageable
    public int Health { get; set; }
    public int Defense { get; set; }
    public void Die()
    {
        if (Health >= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Health = 20;
        Defense = 5;

        Strength = 15;
        Dexterity = 5;
        Endurance = 10;
    }
    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health < 0)
        {
            Die();
        }
    }
    public void RestoreHealth(int amount)
    {
        Health += amount;
    }

    // IMoveable and ITurnable
    public void GoForward()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
    public void GoBackward()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
    public void TurnLeft()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector3.left * turnSpeed * Time.deltaTime);
        }
    }
    public void TurnRight()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector3.right * turnSpeed * Time.deltaTime);
        }
    }
}
