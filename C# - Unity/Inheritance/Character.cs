using UnityEngine;

public class Character : MonoBehaviour
{
    [field: SerializeField] protected string Name { get; set; }
    [field: SerializeField] protected float Health { get; set; }

    public void TakeDamage(int damageAmmount) 
    { 
        Health -= damageAmmount; 
        print($"{Name}sai {damageAmmount}vahinkoa! Terveystilanne: {Health}"); 
    }

    public virtual void Attack() 
    {
        Debug.Log($"{Name}hyökkää!"); 
    }
}
