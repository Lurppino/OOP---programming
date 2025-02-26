using UnityEngine;

public class TruckAudio : MonoBehaviour
{
    private AudioSource bounceSound;
    private void Start() => bounceSound = GetComponent<AudioSource>();

    // Audio
    private void OnTriggerEnter(Collider other)
    {
        bounceSound.Play();
        Destroy(other.gameObject);
    }
}
