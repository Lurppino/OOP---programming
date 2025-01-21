using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance { get; private set; }

    public double volume = 0.5f;
    public double brightness = 0.5f;

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

    public void ChangeVolume(float newVolume)
    {
        volume = newVolume;
    }

    public void ChangeBrightness(float newBrightness)
    {
        brightness = newBrightness;
    }

    public void SaveSettings()
    {
        Debug.Log("Saved: Volume " + volume + " Brightness " + brightness);
    }

    public void LoadSettings()
    {
        Debug.Log("Loaded: Volume " + volume + " Brightness " + brightness);
    }
}
