using UnityEngine;

public class Explodable : MonoBehaviour
{
    public interface IExplodable
    {
        float Mass { get; set; }
        float ExplosiveForce { get; set; }
        float FuseDelay { get; set; }

        void Explode();
    }
}
