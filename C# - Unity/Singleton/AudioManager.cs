using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public static AudioManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySound(AudioClip clip)
    {
        Debug.Log($"Playing {clip.name}");
    }

    public void StopSound()
    {
        Debug.Log("Stopping all sound");
    }
    
}
