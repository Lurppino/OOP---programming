using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact()
    {
        Debug.Log("Olen vuorovaikutteinen perusluokka.");
    }
}
