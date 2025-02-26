using UnityEngine;
using static DamageInterface;

public class Taxi : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name);  
        if (other.TryGetComponent<IDamageable>(out var damageable)) 
        {
            damageable.TakeDamage(5);  
            Debug.Log("Mouse took 5 damage");
        }
        else
        {
            Debug.Log("The object is not damageable");
        }
    }
}
