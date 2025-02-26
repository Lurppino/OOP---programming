using UnityEngine;
using static DamageInterface;

public class Mouse : MonoBehaviour, IDamageableMouse
{
    public int MouseHP = 20;
    public GameObject Explosion;
    public void TakeDamage(int amount)
    {
        MouseHP -= amount;
        Debug.Log($"Mouse HP: {MouseHP}");
        if ( MouseHP <= 0 )
        {
            Explode();
        }
    }

    private void Explode()
    {
        if ( Explosion != null )
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
        }
        Destroy(gameObject, 0.2f);
    }
}
