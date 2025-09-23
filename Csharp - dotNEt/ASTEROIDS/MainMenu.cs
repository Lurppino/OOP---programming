using Raylib_cs;
using RayGuiCreator;
using System.Collections.Generic;

namespace ASTEROIDS
{
    public static class MainMenuScreen
    {
        public static void Draw(MenuCreator mainMenu, Stack<GameState> stateStack, System.Action restartGame)
        {
            Raylib.ClearBackground(Color.Black);

            mainMenu.ResetPosition();

            mainMenu.Label("ASTEROIDS", true);
            mainMenu.Label("Use arrows to move, Space to shoott", true);

            if (mainMenu.Button("Start Game"))
            {
                restartGame();
                stateStack.Push(GameState.GameLoop);
            }

            if (mainMenu.Button("Options"))
            {
                stateStack.Push(GameState.OptionsMenu);
            }

            if (mainMenu.Button("Quit"))
            {
                stateStack.Push(GameState.Quit);
            }
        }
    }
}
