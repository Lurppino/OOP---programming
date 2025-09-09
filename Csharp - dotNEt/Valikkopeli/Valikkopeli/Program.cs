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
            peli.RunFrame();
        }

        Raylib.CloseWindow();
    }
}
