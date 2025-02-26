using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private PlayerInput_ playerInput;

    private Rigidbody rb;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput_>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 movement = new Vector3(playerInput.HorizontalInput, 0, playerInput.VerticalInput);
        rb.linearVelocity = movement * speed;
    }
}
