using Raylib_cs;
using System.Drawing;
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
            float paddleSpeed, paddleWidth, paddleHeight;
            Vector2 ballPosition, ballDirection;
            float ballSpeed;

            Raylib.InitWindow(800, 500, "PONG");
            Raylib.SetTargetFPS(60);
            int screenWidth = Raylib.GetScreenWidth();
            int screenHeight = Raylib.GetScreenHeight();

            paddleWidth = 25;
            paddleHeight = 125;
            paddleSpeed = 150;

            player1Score = 0;
            player2Score = 0;

            ballDirection = new Vector2(1, 1);
            ballSpeed = 200.0f;
            player1Position = new Vector2(50, screenHeight / 2 - paddleHeight / 2);
            player2Position = new Vector2(screenWidth - 50 - paddleWidth, screenHeight / 2 - paddleHeight / 2);


            ballPosition = new Vector2(screenWidth / 2, screenHeight / 2);



            while (Raylib.WindowShouldClose() == false)
            {
                float deltaTime = Raylib.GetFrameTime();

                ballPosition += ballDirection * ballSpeed * deltaTime;

                // Make sure ball doesnt go out of bounds
                if (ballPosition.X >= screenWidth || ballPosition.X <= 0)
                {
                    ballDirection.X *= -1;
                }
                else if (ballPosition.Y >= screenHeight || ballPosition.Y <= 0)
                {
                    ballDirection.Y *= -1;
                }

                // Paddle movements (Player 1 Up (W) Down (S) // Player 2 Up (O) Down (L)
                if (Raylib.IsKeyDown(KeyboardKey.S)) player1Position.Y += paddleSpeed * deltaTime;
                else if (Raylib.IsKeyDown(KeyboardKey.W)) player1Position.Y -= paddleSpeed * deltaTime;
                if (Raylib.IsKeyDown(KeyboardKey.L)) player2Position.Y += paddleSpeed * deltaTime;
                else if (Raylib.IsKeyDown(KeyboardKey.O)) player2Position.Y -= paddleSpeed * deltaTime;

                if (player1Position.Y < 0) player1Position.Y = 0;
                if (player1Position.Y + paddleHeight > screenHeight) player1Position.Y = screenHeight - paddleHeight;

                if (Raylib.IsKeyDown(KeyboardKey.Down)) player2Position.Y += paddleSpeed * deltaTime;
                else if (Raylib.IsKeyDown(KeyboardKey.Up)) player2Position.Y -= paddleSpeed * deltaTime;

                // Makes sure paddle doesnt go out of bounds
                if (player2Position.Y < 0) player2Position.Y = 0;
                if (player2Position.Y + paddleHeight > screenHeight) player2Position.Y = screenHeight - paddleHeight;

                // Paddle collisions with ball
                if (ballPosition.X <= player1Position.X + paddleWidth &&
                    ballPosition.X >= player1Position.X &&
                    ballPosition.Y >= player1Position.Y &&
                    ballPosition.Y <= player1Position.Y + paddleHeight)
                {
                    ballDirection.X *= -1;
                    ballSpeed *= 1.05f;

                    if (ballPosition.Y < player1Position.Y)
                    {
                        ballPosition.Y = player1Position.Y - 10;
                    }
                    else if (ballPosition.Y > player1Position.Y + paddleHeight)
                    {
                        ballPosition.Y = player1Position.Y + paddleHeight + 10;
                    }
                }
                //Player 2 collisions
                if (ballPosition.X >= player2Position.X &&
                    ballPosition.X <= player2Position.X + paddleWidth &&
                    ballPosition.Y >= player2Position.Y &&
                    ballPosition.Y <= player2Position.Y + paddleHeight)
                {

                    ballDirection.X *= -1;
                    ballSpeed *= 1.05f;

                    if (ballPosition.Y < player2Position.Y)
                    {
                        ballPosition.Y = player2Position.Y - 10;
                    }
                    else if (ballPosition.Y > player2Position.Y + paddleHeight)
                    {
                        ballPosition.Y = player2Position.Y + paddleHeight + 10;
                    }
                }
                // Player scores
                if (ballPosition.X >= screenWidth)
                {
                    player1Score++;
                    ballSpeed = 200.0f;
                    ballPosition = new Vector2(screenWidth / 2, screenHeight / 2);
                    ballDirection = new Vector2(-1, 1);
                }

                if (ballPosition.X <= 0)
                {
                    player2Score++;
                    ballSpeed = 200.0f;
                    ballPosition = new Vector2(screenWidth / 2, screenHeight / 2);
                    ballDirection = new Vector2(1, 1);
                }


                Raylib.BeginDrawing();
                Raylib.ClearBackground(Raylib_cs.Color.DarkBlue);

                Raylib.DrawCircleV(ballPosition, 10, Raylib_cs.Color.White);
                Raylib.DrawRectangle((int)player1Position.X, (int)player1Position.Y, (int)paddleWidth, (int)paddleHeight, Raylib_cs.Color.Red);
                Raylib.DrawRectangle((int)player2Position.X, (int)player2Position.Y, (int)paddleWidth, (int)paddleHeight, Raylib_cs.Color.Green);

                Raylib.DrawText($"Player 1: {player1Score}", 100, 20, 25, Raylib_cs.Color.White);
                Raylib.DrawText($"Player 2: {player2Score}", screenWidth - 250, 20, 25, Raylib_cs.Color.White);

                Raylib.DrawText("Controls:\nUp (W) Down (S)", 100, 50, 25, Raylib_cs.Color.White);
                Raylib.DrawText("Controls:\nUp (O) Down (L)", screenWidth - 250, 50, 25, Raylib_cs.Color.White);



                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }

    }
}
