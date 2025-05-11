using Raylib_cs;
using System;
using System.Numerics;

namespace ASTEROIDS
{
    internal class Player : Entity
    {
        public bool IsDead { get; set; } = false; 
        public float MaxSpeed = 5f;
        public float Size = 20f;
        public float Acceleration = 0.1f;
        public float Drag = 0.98f;

        public Player(Vector2 startPos) : base(startPos, 0f) { }

        public override void Update()
        {
            if (IsDead) return; 

            if (Raylib.IsKeyDown(KeyboardKey.Left)) rotation -= 3f;
            if (Raylib.IsKeyDown(KeyboardKey.Right)) rotation += 3f;
            if (Raylib.IsKeyDown(KeyboardKey.Up))
            {
                float angleRad = rotation * Program.Deg2Rad;
                velocity.Y -= (float)Math.Cos(angleRad) * Acceleration;
                velocity.X += (float)Math.Sin(angleRad) * Acceleration;

                if (velocity.Length() > MaxSpeed)
                    velocity = Vector2.Normalize(velocity) * MaxSpeed;
            }

            ApplyDrag();
            position += velocity;
            WrapAroundScreen();
        }

        public override void Draw()
        {
            Vector2 tip = new Vector2(0, -Size);
            Vector2 left = new Vector2(-Size / 2, Size / 2);
            Vector2 right = new Vector2(Size / 2, Size / 2);

            tip = RotateVector(tip, rotation);
            left = RotateVector(left, rotation);
            right = RotateVector(right, rotation);

            tip += position;
            left += position;
            right += position;
            Raylib.DrawTriangle(tip, left, right, Raylib_cs.Color.White);
        }

        public static Vector2 RotateVector(Vector2 vector, float angle)
        {
            float rad = angle * Program.Deg2Rad;
            float cosA = (float)Math.Cos(rad);
            float sinA = (float)Math.Sin(rad);

            return new Vector2(vector.X * cosA - vector.Y * sinA, vector.X * sinA + vector.Y * cosA);
        }

        protected void ApplyDrag()
        {
            if (velocity.Length() > 0)
            {
                velocity *= Drag;
            }
        }
    }
}
