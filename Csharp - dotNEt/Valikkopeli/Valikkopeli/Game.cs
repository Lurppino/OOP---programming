using RayGuiCreator;
using Raylib_cs;
using System.Collections.Generic;

namespace Valikkopeli
{
    public class Game
    {
        private Stack<GameState> stateStack;

        public Game()
        {
            stateStack = new Stack<GameState>();
            stateStack.Push(GameState.MainMenu);
        }

        public GameState CurrentState => stateStack.Peek();

        private void ChangeState(GameState newState)
        {
            stateStack.Push(newState);
        }

        private void GoBack()
        {
            if (stateStack.Count > 1)
                stateStack.Pop();
        }

        public void DrawMainMenu()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            MenuCreator creator = new MenuCreator(100, 100, 200, 50, 80);
            creator.Label("Valikkopeli");
            creator.Label("Press buttons to continue...");

            if (creator.Button("Start Game"))
            {
                ChangeState(GameState.GameLoop);
            }

            if (creator.Button("Options"))
            {
                ChangeState(GameState.OptionsMenu);
            }

            if (creator.Button("Quit"))
            {
                ChangeState(GameState.Quit);
            }

            Raylib.EndDrawing();
        }

        public void DrawOptionsMenu()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.DarkGray);

            MenuCreator creator = new MenuCreator(100, 100, 200, 50, 80);
            creator.Label("Options");
            creator.Label("Adjust settings here...");

            if (creator.Button("Back"))
            {
                GoBack();
            }

            Raylib.EndDrawing();
        }

        public void DrawPauseMenu()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.DarkBlue);

            MenuCreator creator = new MenuCreator(100, 100, 200, 50, 80);
            creator.Label("Pause Menu");

            if (creator.Button("Resume"))
            {
                GoBack();
            }

            if (creator.Button("Options"))
            {
                ChangeState(GameState.OptionsMenu);
            }

            if (creator.Button("Main Menu"))
            {
                stateStack.Clear();
                stateStack.Push(GameState.MainMenu);
            }

            Raylib.EndDrawing();
        }

        public void UpdateGame()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Escape))
            {
                ChangeState(GameState.PauseMenu);
            }
        }

        public void DrawGame()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.DarkGreen);

            Raylib.DrawText("Game is running!", 100, 100, 24, Color.White);
            Raylib.DrawText("Press ESC to pause", 100, 140, 24, Color.White);

            Raylib.EndDrawing();
        }
    }
}
