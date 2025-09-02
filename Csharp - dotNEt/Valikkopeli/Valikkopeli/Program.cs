using Raylib_cs;
using Valikkopeli;

class Program
{
    static void Main(string[] args)
    {
        Raylib.InitWindow(800, 600, "Valikkopeli");
        Raylib.SetTargetFPS(60);

        Game peli = new Game();

        while (!Raylib.WindowShouldClose() && peli.currentState != GameState.Quit)
        {
            // Menu
            if (peli.currentState == GameState.Menu)
            {
                peli.DrawMainMenu();
            }
            // Game loop
            else if (peli.currentState == GameState.GameLoop)
            {
                peli.UpdateGame();
                peli.DrawGame();
            }
        }

        Raylib.CloseWindow();
    }
}
