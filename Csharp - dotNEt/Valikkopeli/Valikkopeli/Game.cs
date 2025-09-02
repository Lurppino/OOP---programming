using Raylib_cs;
using RayGuiCreator;

namespace Valikkopeli
{
    public class Game
    {
        public GameState currentState;
        private MenuCreator menu;

        // Example game variables
        private float x = 100;
        private float y = 100;
        private float dx = 3;
        private float dy = 3;

        public Game()
        {
            currentState = GameState.Menu;
            menu = new MenuCreator(
                300,
                200, 
                200,
                40,
                0,  
                20  
            );

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
                    currentState = GameState.Menu;
            }
        }

        public void DrawGame()
        {
            Raylib.BeginDrawing();

            if (currentState == GameState.Menu)
            {
                Raylib.ClearBackground(Color.Black);

                menu.Label("Valikkopeli"); 
                menu.Label("Use arrow keys and Enter to play");

                if (menu.Button("Start Game"))
                    currentState = GameState.GameLoop;

                if (menu.Button("Quit"))
                    currentState = GameState.Quit;
            }
            else if (currentState == GameState.GameLoop)
            {
                Raylib.ClearBackground(Color.DarkGray);
                Raylib.DrawText("Game running! Press ESC to return to menu", 10, 10, 20, Color.Green);
                Raylib.DrawCircle((int)x, (int)y, 20, Color.Red);
            }

            Raylib.EndDrawing();
        }
    }
}
