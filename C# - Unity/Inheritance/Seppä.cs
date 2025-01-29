using UnityEngine;

public class Seppa : Interactable
{
    public string ufoName = "Seppä"; 
    public string[] dialogue = new string[]
    {
        "Hei, miten voin auttaa sinua?",
        "Tarvitsetko uuden miekan tai haarniskan?",
        "Olen täällä valmistelemassa mitä tahansa teräksestä."
    };

    public override void Interact()
    {
        Debug.Log("Seppä aloittaa keskustelun!");
        DialogueManager.instance.AddNewDialogue(dialogue, ufoName);
    }
}
