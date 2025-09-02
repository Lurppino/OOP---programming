using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valikkopeli
{
    public class Game
    {
        private float x = 100;
        private float y = 100;
        private float dx = 3;
        private float dy = 3;

        public void UpdateGame()
        {
            x += dx;
            y += dy;

            if (x < 0 || x > 800) dx *= -1;
            if (y < 0 || y > 600) dy *= -1;
        }

        public void DrawGame()
        {
            Raylib.DrawText("Peli kaynnissa!", 10, 10, 20, Color.Green);
            Raylib.DrawCircle((int)x, (int)y, 20, Color.Red);
        }
    }
}
