using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.nKey.wasPressedThisFrame)
        {
            PlayerData.instance.SaveData();
        }
        if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            PlayerData.instance.LoadData();
        }
    }
}
