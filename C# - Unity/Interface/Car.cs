using UnityEngine;

public class Car : RoadVehicle
{
    private void Update()
    {
        GoForward();
        GoBackward();
        TurnLeft();
        TurnRight();
    }
}
