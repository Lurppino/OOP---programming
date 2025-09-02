using Raylib_cs;
using System;
using Valikkopeli;

class Program
{
    static void Main(string[] args)
    {
        Raylib.InitWindow(800, 600, "Valikkopeli");
        Raylib.SetTargetFPS(60);

        Game peli = new Game();

        while (!Raylib.WindowShouldClose())
        {
            peli.UpdateGame();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            peli.DrawGame();

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
