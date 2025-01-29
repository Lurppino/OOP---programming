using UnityEngine;

public class Kauppias : Interactable
{
    public string ufoName = "Kauppias"; 
    public string[] dialogue = new string[]
    {
        "Tervetuloa! Miten voin auttaa sinua t‰n‰‰n?",
        "Meill‰ on laaja valikoima tavaroita.",
        "Oletko valmis ostamaan jotakin?"
    };


    public override void Interact()
    {
        Debug.Log("Kauppias aloittaa keskustelun!");
        DialogueManager.instance.AddNewDialogue(dialogue, ufoName);
    }
}
