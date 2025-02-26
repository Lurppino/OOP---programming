using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    private float speed = 3.0f;
    private float turnSpeed = 45.0f;

    private TruckInput truckInput;
    void Start()
    {
        truckInput = GetComponent<TruckInput>();
    }
    void Update()
    {
        MoveTruck();
    }
    private void MoveTruck()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed * truckInput.VerticalInput);
        transform.Rotate(Vector3.up, turnSpeed * truckInput.HorizontalInput * Time.deltaTime);
    }
}
