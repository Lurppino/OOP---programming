using UnityEngine;
using UnityEngine.InputSystem;
using static GameStateManager;

public class GameStateController : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            GameStateManager.instance.ChangeState(GameState.MainMenu);
        }

        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            GameStateManager.instance.ChangeState(GameState.Playing);
        }

        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            GameStateManager.instance.ChangeState(GameState.Paused);
        }
    }
}
