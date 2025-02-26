using UnityEngine;
using static IMovableScript;
using static ITurnableScript;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class RoadVehicle : MonoBehaviour, IMovable, ITurnable
{
    int speed = 5;
    int turnSpeed = 5;
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
    public void TurnLeft()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector3.left * turnSpeed * Time.deltaTime);
        }
    }
    public void TurnRight()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector3.right * turnSpeed * Time.deltaTime);
        }
    }
}
