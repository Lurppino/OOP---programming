using UnityEngine;
using UnityEngine.InputSystem;

public class AudioController : MonoBehaviour
{
    public AudioClip testClip;
    void Update()
    {
        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            AudioManager.instance.PlaySound(testClip);
        }

        if (Keyboard.current.uKey.wasPressedThisFrame)
        {
            AudioManager.instance.StopSound();
        }
    }
}
