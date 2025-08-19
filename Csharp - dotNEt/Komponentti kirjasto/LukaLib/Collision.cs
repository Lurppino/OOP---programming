using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LukaLib
{
    public class Collision2d
    {
        public float Radius;

        public Collision2d(float radius)
        {
            Radius = radius;
        }

        public static bool CheckCollision2d(Transform2d tA, Collision2d cA, Transform2d tB, Collision2d cB)
        {
            return Raylib_cs.Raylib.CheckCollisionCircles(tA.Position, cA.Radius, tB.Position, cB.Radius);
        }
    }
}
