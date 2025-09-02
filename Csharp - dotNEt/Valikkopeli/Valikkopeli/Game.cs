using Raylib_cs;
using RayGuiCreator;

namespace Valikkopeli
{
    public class Game
    {
        public GameState currentState;

        private float x = 100;
        private float y = 100;
        private float dx = 3;
        private float dy = 3;

        public Game()
        {
            currentState = GameState.Menu;
        }

        public void DrawMainMenu()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            // Create a MenuCreator
            MenuCreator creator = new MenuCreator(
                300, // startX
                200, // startY
                200, // buttonWidth
                40,  // buttonHeight
                0,   // spacingX
                20   // spacingY
            );

            creator.Label("Valikkopeli");
            creator.Label("Use arrow keys and Enter to play");

            if (creator.Button("Start Game"))
            {
                currentState = GameState.GameLoop;
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
                    currentState = GameState.Menu;
                }
            }
        }

        public void DrawGame()
        {
            if (currentState == GameState.GameLoop)
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.DarkGray);

                Raylib.DrawText("Game running! Press ESC to return to menu", 10, 10, 20, Color.Green);
                Raylib.DrawCircle((int)x, (int)y, 20, Color.Red);

                Raylib.EndDrawing();
            }
        }
    }
}
