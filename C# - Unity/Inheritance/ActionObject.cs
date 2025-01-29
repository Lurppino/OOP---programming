using UnityEngine;

public class Ufo : Interactable
{
    public string ufoName; 
    public string[] dialogue;

    public override void Interact()
    {
        Debug.Log("Ufo aloittaa keskustelun!");
        DialogueManager.instance.AddNewDialogue(dialogue, ufoName);
    }
}
