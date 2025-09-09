using Raylib_cs;
using Valikkopeli;

class Program
{
    static void Main()
    {
        Raylib.InitWindow(800, 600, "Valikkopeli");
        Raylib.SetTargetFPS(60);

        Game game = new Game();

        while (!Raylib.WindowShouldClose() && game.CurrentState != GameState.Quit)
        {
            switch (game.CurrentState)
            {
                case GameState.MainMenu:
                    game.DrawMainMenu();
                    break;
                case GameState.GameLoop:
                    game.UpdateGame();
                    game.DrawGame();
                    break;
                case GameState.OptionsMenu:
                    game.DrawOptionsMenu();
                    break;
                case GameState.PauseMenu:
                    game.DrawPauseMenu();
                    break;
            }
        }

        Raylib.CloseWindow();
    }
}
