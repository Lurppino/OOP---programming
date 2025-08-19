using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LukaLib
{
    public class Transform2d
    {
        public Vector2 Position;
        public Vector2 Velocity;
        public float RotationRadians;
        public float MaxSpeed;
        public Vector2 Direction;

        public Transform2d(Vector2 position, float maxSpeed = 200f)
        {
            Position = position;
            Velocity = Vector2.Zero;
            MaxSpeed = maxSpeed;
            Direction = new Vector2(0, -1);
            RotationRadians = 0f;
        }

        public bool WrapsAround = true;

        public void Move()
        {
            float deltaTime = Raylib_cs.Raylib.GetFrameTime();

            if (Velocity.Length() > MaxSpeed)
                Velocity = Vector2.Normalize(Velocity) * MaxSpeed;

            Position += Velocity * deltaTime;

            if (WrapsAround)
                WrapAroundScreen();
        }

        private void WrapAroundScreen()
        {
            int screenW = Raylib.GetScreenWidth();
            int screenH = Raylib.GetScreenHeight();

            if (Position.X < 0) Position.X += screenW;
            else if (Position.X >= screenW) Position.X -= screenW;

            if (Position.Y < 0) Position.Y += screenH;
            else if (Position.Y >= screenH) Position.Y -= screenH;
        }

        public void Turn(float amountRadians)
        {
            RotationRadians += amountRadians;
            Direction = Vector2.Transform(Direction, Matrix3x2.CreateRotation(amountRadians));
        }
    }

}
