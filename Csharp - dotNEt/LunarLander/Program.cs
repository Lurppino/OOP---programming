using Raylib_cs;
using System.Numerics;

namespace LunarLander
{
    internal class Lander
    {
        static void Main(string[] args)
        {
            Lander game = new Lander();
            game.Init();
            game.GameLoop();
        }

        ////////////// MUUTTUJAT ///////////////////////


        // Laskeutumisalustan katon sijainti y-akselilla. Y kasvaa alaspäin
        public int landingPosX = 300;
        public int landingPosY = 600;
        public int landingWidth = 400;
        public int landingHeight = 50;
        // ship objekti
        private Ship ship;

        // Ruudunpäivitykseen menevä aika

        // Painovoiman voimakkuus

        // Ikkunan leveys ja korkeus
        public int windowHeight = 800;
        public int windowWidth = 1000;

        private bool gameOver = false;
        private bool gameWin = false;
        void Init()
        {
            Raylib.InitWindow(windowWidth, windowHeight, "Lunar Lander");
            Raylib.SetTargetFPS(60);
            resetGame();
        }

        void GameLoop()
        {
            // Pyöritä gamelooppia niin kauan
            // kun Raylibin ikkuna on auki
            while (!Raylib.WindowShouldClose())
            {
                if (!gameOver && !gameWin)
                {
                    ship.Update();
                    CheckCollision();
                }
                else if (Raylib.IsKeyPressed(KeyboardKey.Enter))
                {
                    resetGame();
                }
                Draw();
            }
            // Sulje Raylib ikkuna
            Raylib.CloseWindow();
        }
        void CheckCollision()
        {
            if (ship.position.Y + 10 >= landingPosY &&
                ship.position.X >= landingPosX &&
                ship.position.X <= landingPosX + landingWidth)
            {
                if (ship.speed > 0.5f)
                {
                    gameOver = true;
                }
                else
                {
                    gameWin = true;
                    Raylib.DrawText("Perfect Landing!", windowWidth / 2 - 100, windowHeight / 3, 40, Color.Green);
                }
                ship.speed = 0; 
            }
        }

        void resetGame()
        {
            gameOver = false;
            gameWin = false;
            ship = new Ship(new Vector2(windowWidth / 2, 100), 0.009f, 5);
        }

        void Update()
        {
            // Kysy Raylibiltä miten pitkään yksi ruudunpäivitys kesti
            // Päivitä aluksen tilaa
            // Lisää painovoiman vaikutus

        }

        void Draw()
        {
            // Aloita piirtäminen
            Raylib.BeginDrawing();

            // Tyhjennä ruutu mustaksi
            Raylib.ClearBackground(Raylib_cs.Color.Black);

            //Piirrä laskeutumisalusta suorakulmiona
            Raylib.DrawRectangle(landingPosX,landingPosY,landingWidth,landingHeight,Raylib_cs.Color.White);
            // Piirrä alus
            ship.Draw();

            if (gameOver)
            {
                Raylib.DrawText("You Crashed!", windowWidth / 2 - 100, windowHeight / 3, 40, Color.Red);
                Raylib.DrawText("Press ENTER", windowWidth / 2 - 100, windowHeight / 2, 30, Color.Red);
            }
            if (gameWin)
            {
                Raylib.DrawText("Perfect Landing!", windowWidth / 2 - 100, windowHeight / 3, 40, Color.Green);
                Raylib.DrawText("Press ENTER", windowWidth / 2 - 100, windowHeight / 2, 30, Color.Green);
            }
            // Piirrä debug tietoja tarvittaessa, kuten nopeus

            //Lopeta piirtäminen
            Raylib.EndDrawing();
        }
    }
}