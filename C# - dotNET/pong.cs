using Raylib_cs;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace PONG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector2 player1Position, player2Position;
            int player1Score, player2Score;
            Vector2 player1ScorePosition, player2ScorePosition;
            float paddleSpeed, paddleWidth, paddleHeight;
            Vector2 ballPosition, ballDirection;
            float ballSpeed;

            Raylib.InitWindow(600, 400, "PONG");
            Raylib.SetTargetFPS(60);
            int screenWidth = Raylib.GetScreenWidth();
            int screenHeight = Raylib.GetScreenHeight();

            paddleWidth = 10;
            paddleHeight = 100;
            paddleSpeed = 300;

            ballDirection = new Vector2(1, 1);
            ballSpeed = 200.0f;

            player1Position = new Vector2(50, 0);
            player2Position = new Vector2(550, 0);

            ballPosition = new Vector2(screenWidth / 2, screenHeight / 2);
            


            while (Raylib.WindowShouldClose() == false)
            {
                float deltaTime = Raylib.GetFrameTime();

                ballPosition += ballDirection * ballSpeed * deltaTime;



                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);
                Raylib.DrawRectangle((int)ballPosition.X, (int)ballPosition.Y, 10, 10, Color.White);
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }

    }
}
