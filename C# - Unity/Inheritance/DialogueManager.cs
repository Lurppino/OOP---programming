using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance { get; private set; }

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

    public void AddNewDialogue(string[] lines, string name)
    {
        Debug.Log("Starting dialogue with " + name);
        foreach (string line in lines)
        {
            Debug.Log(line);
        }
    }
}
