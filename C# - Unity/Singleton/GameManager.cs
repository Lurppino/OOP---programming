using TMPro.EditorUtilities;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogError("Too many GameManager objects!");
            Destroy(gameObject);
            return;
        }
        
            Instance = this;
            DontDestroyOnLoad(gameObject);
        
    }
}
