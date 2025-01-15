using UnityEngine;
using UnityEngine.InputSystem;  

public class ScoreController : MonoBehaviour
{
    void Update()
    {
        
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            ScoreManager.Instance.score += 10;

            Debug.Log("New Score: " + ScoreManager.Instance.score);
        }
    }
}