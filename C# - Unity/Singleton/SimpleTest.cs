using Unity.VisualScripting;
using UnityEngine;

public class SimpleTest : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.Instance != null)
        {
            Debug.Log("Works!");
        }
        else
        {
            Debug.LogError("Doesnt work!");
        }
    }
}
