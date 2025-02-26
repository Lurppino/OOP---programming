using UnityEngine;
using static IMovableScript;
using static ITurnableScript;

public class RailVehicle : MonoBehaviour, IMovable
{
    int speed = 5;
    public void GoForward()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
    public void GoBackward()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
}
