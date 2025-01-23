using UnityEngine;
using UnityEngine.InputSystem;

public class InheritanceTest : MonoBehaviour
{
    [SerializeField] private GameObject Mage; 
    [SerializeField] private GameObject Warrior;

    private void Update() 
    { 
        var gKey = Keyboard.current.gKey.wasPressedThisFrame; 
        var hKey = Keyboard.current.hKey.wasPressedThisFrame; 
        var jKey = Keyboard.current.jKey.wasPressedThisFrame; 
        var kKey = Keyboard.current.kKey.wasPressedThisFrame; 
        
        if (gKey) 
        { Mage.GetComponent<Mage>().TakeDamage(5); }

        if (hKey) 
        { Warrior.GetComponent<Warrior>().TakeDamage(3); }

        if (jKey) 
        { Mage.GetComponent<Mage>().Attack(); }

        if (kKey) 
        { Warrior.GetComponent<Warrior>().Attack(); } }
}
