using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance { get; private set; }

    public enum GameState
    {
        MainMenu,
        Playing,
        Paused
    }

    private GameState currentState;

    private void Awake()
    {
        currentState = GameState.MainMenu;
        Debug.Log($"Initial game state: {currentState}");

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ChangeState(GameState newState)
    {
        currentState = newState;
        Debug.Log($"Game state changed to: {currentState}");
    }
}
