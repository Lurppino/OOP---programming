using LukaLib;
using Raylib_cs;
using System;
using System.Numerics;
using static ASTEROIDS.Program;

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
            : base(new Transform2d(startPos), new Collision2d(20f)) 
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
            Texture2D tex = Textures.Ship_Blue;

            switch (Program.SelectedShipColor)
            {
                case ShipColor.Blue: tex = Textures.Ship_Blue; break;
                case ShipColor.Green: tex = Textures.Ship_Green; break;
                case ShipColor.Red: tex = Textures.Ship_Red; break;
                case ShipColor.Yellow: tex = Textures.Ship_Yellow; break;
            }

            Raylib.DrawTexturePro(
                tex,
                new Rectangle(0, 0, tex.Width, tex.Height),
                new Rectangle(Transform.Position.X, Transform.Position.Y, tex.Width, tex.Height),
                new Vector2(tex.Width / 2f, tex.Height / 2f),
                Transform.RotationRadians * (180f / MathF.PI),
                Color.White
            );
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
