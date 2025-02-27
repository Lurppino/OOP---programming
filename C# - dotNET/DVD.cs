using Raylib_cs;
using System.Numerics;

namespace DVD_Logo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector2 textPos = new Vector2(100, 100);
            Vector2 textDir = new Vector2(1, 1);
            float textSpeed = 100.0f;

            Font defaultFont = Raylib.GetFontDefault();
            string text = "DVD";
            float fontSize = 40.0f;
            float spacing = 1;

            Raylib.InitWindow(600, 400, "DVD Logo");
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                int screenWidth = Raylib.GetScreenWidth();
                int screenHeight = Raylib.GetScreenHeight();
                Vector2 textSize = Raylib.MeasureTextEx(defaultFont, text, fontSize, spacing);
                float deltaTime = Raylib.GetFrameTime();


                textPos += textDir * textSpeed * deltaTime;

                // En saanut logon pomppaamaan reunoista mitenkään joten 
                // Laitoin vain -75 ja -35 että se näyttää siltä 
                if (textPos.X + textSize.X >= screenWidth - 75 || textPos.X <= 0)
                    textDir.X *= -1; 

                if (textPos.Y + textSize.Y >= screenHeight - 35 || textPos.Y <= 0)
                    textDir.Y *= -1; 

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);
                Raylib.DrawTextEx(defaultFont, text, textPos, fontSize, spacing, Color.Yellow);
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
