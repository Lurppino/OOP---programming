using Raylib_cs;
using RayGuiCreator;
using System;

namespace Valikkopeli
{
    public class Game
    {
        public GameState currentState;

        private float x = 100;
        private float y = 100;
        private float dx = 3;
        private float dy = 3;

        private OptionsMenu myOptionsMenu;
        private PauseMenu myPauseMenu;

        public Game()
        {
            currentState = GameState.Menu;

            myOptionsMenu = new OptionsMenu();
            myPauseMenu = new PauseMenu();

            myOptionsMenu.BackButtonPressedEvent += OnOptionsBackButtonPressed;
            myPauseMenu.BackButtonPressedEvent += OnPauseBackButtonPressed;
        }

        public void DrawMainMenu()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            MenuCreator creator = new MenuCreator(
                300, 200, 200, 40, 0, 20
            );

            creator.Label("Valikkopeli");
            creator.Label("Use ESC to pause");

            if (creator.Button("Start Game"))
            {
                currentState = GameState.GameLoop;
            }

            if (creator.Button("Options"))
            {
                currentState = GameState.OptionsMenu;
            }

            if (creator.Button("Quit"))
            {
                currentState = GameState.Quit;
            }

            Raylib.EndDrawing();
        }

        public void UpdateGame()
        {
            if (currentState == GameState.GameLoop)
            {
                x += dx;
                y += dy;

                if (x < 0 || x > Raylib.GetScreenWidth()) dx *= -1;
                if (y < 0 || y > Raylib.GetScreenHeight()) dy *= -1;

                if (Raylib.IsKeyPressed(KeyboardKey.Escape))
                {
                    currentState = GameState.PauseMenu;
                }
            }
        }

        public void DrawGame()
        {
            if (currentState == GameState.GameLoop)
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.DarkGray);

                Raylib.DrawText("Game running! Press ESC to pause", 10, 10, 20, Color.Green);
                Raylib.DrawCircle((int)x, (int)y, 20, Color.Red);

                Raylib.EndDrawing();
            }
        }

        private void OnOptionsBackButtonPressed(object sender, EventArgs args)
        {
            currentState = GameState.Menu;
        }

        private void OnPauseBackButtonPressed(object sender, EventArgs args)
        {
            currentState = GameState.GameLoop;
        }

        public void RunFrame()
        {
            switch (currentState)
            {
                case GameState.Menu:
                    DrawMainMenu();
                    break;
                case GameState.GameLoop:
                    UpdateGame();
                    DrawGame();
                    break;
                case GameState.OptionsMenu:
                    myOptionsMenu.DrawMenu();
                    break;
                case GameState.PauseMenu:
                    myPauseMenu.DrawMenu();
                    break;
            }
        }
    }
}
