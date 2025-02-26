using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private AudioSource collisionSound;

    private void Start()
    {
        collisionSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {

        collisionSound.Play();


        if (other.CompareTag("Interactable Object"))
        {
            Destroy(other.gameObject);
        }
    }
}
