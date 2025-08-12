using Raylib_cs;
using System;
using System.Numerics;
using LukaLib;

namespace ASTEROIDS
{
    internal class Player : Entity
    {
        public bool IsDead { get; set; } = false;
        public float MaxSpeed = 100f;
        public float Acceleration = 10f;
        public float Drag = 0.98f;
        public float Size = 20f;

        public Player(Vector2 startPos)
            : base(new Transform(startPos), new Collision(20f)) 
        {
        }

        public override void Update()
        {
            if (IsDead) return;

            
            if (Raylib.IsKeyDown(KeyboardKey.Left))
                Transform.Turn(-3f * Program.Deg2Rad);
            if (Raylib.IsKeyDown(KeyboardKey.Right))
                Transform.Turn(3f * Program.Deg2Rad);

            
            if (Raylib.IsKeyDown(KeyboardKey.Up))
            {
                Vector2 acceleration = Transform.Direction * Acceleration;
                Transform.Velocity += acceleration;

                if (Transform.Velocity.Length() > MaxSpeed)
                    Transform.Velocity = Vector2.Normalize(Transform.Velocity) * MaxSpeed;
            }

         

            Transform.Velocity *= Drag;
        
            Transform.Move();
        }

        public override void Draw()
        {
            Vector2 tip = new Vector2(0, -Size);
            Vector2 left = new Vector2(-Size / 2, Size / 2);
            Vector2 right = new Vector2(Size / 2, Size / 2);

            
            tip = RotateVector(tip, Transform.RotationRadians * (180f / (float)Math.PI));
            left = RotateVector(left, Transform.RotationRadians * (180f / (float)Math.PI));
            right = RotateVector(right, Transform.RotationRadians * (180f / (float)Math.PI));

            tip += Transform.Position;
            left += Transform.Position;
            right += Transform.Position;

            Raylib.DrawTriangle(tip, left, right, Color.White);
        }

        private Vector2 RotateVector(Vector2 vector, float angleDegrees)
        {
            float rad = angleDegrees * Program.Deg2Rad;
            float cosA = (float)Math.Cos(rad);
            float sinA = (float)Math.Sin(rad);

            return new Vector2(
                vector.X * cosA - vector.Y * sinA,
                vector.X * sinA + vector.Y * cosA
            );
        }
    }
}
