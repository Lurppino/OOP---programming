using System.Runtime.InteropServices;
using UnityEngine;

public class DamageInterface : MonoBehaviour
{
    public interface IDamageableMouse
    {
        void TakeDamage(int amount);
    }
}

