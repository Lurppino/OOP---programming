using UnityEngine;

public class Train : RailVehicle
{
    private void Update()
    {
        GoForward();
        GoBackward();
    }
}
