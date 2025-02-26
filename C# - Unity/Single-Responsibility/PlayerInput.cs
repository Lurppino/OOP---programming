using UnityEngine;

public class PlayerInput_ : MonoBehaviour
{
    public float HorizontalInput {  get; private set; }
    public float VerticalInput { get; private set; }

    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
    }
}
