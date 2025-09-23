using Raylib_cs;
using RayGuiCreator;

namespace ASTEROIDS
{
    public static class PauseMenuScreen
    {
        public static void Draw(MenuCreator pauseMenu, Stack<GameState> stateStack)
        {
            pauseMenu.ResetPosition();

            pauseMenu.Label("PAUSE MENU");

            if (pauseMenu.Button("Resume"))
            {
                stateStack.Pop();
            }

            if (pauseMenu.Button("Options"))
            {
                stateStack.Push(GameState.OptionsMenu);
            }

            if (pauseMenu.Button("Main Menu"))
            {
                stateStack.Clear();
                stateStack.Push(GameState.MainMenu);
            }

            pauseMenu.EndMenu();
        }
    }
}
