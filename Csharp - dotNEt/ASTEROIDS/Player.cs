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

        public void Draw()
        {
            Texture2D shipTex = Textures.Ship_Blue;

            // center of rotation
            Vector2 origin = new Vector2(shipTex.Width / 2f, shipTex.Height / 2f);

            // destination rectangle
            Rectangle dest = new Rectangle(
                Transform.Position.X,
                Transform.Position.Y,
                shipTex.Width,
                shipTex.Height
            );

            Raylib.DrawTexturePro(
                shipTex,
                new Rectangle(0, 0, shipTex.Width, shipTex.Height), // source rect
                dest,
                origin,
                Transform.RotationRadians * (180f / MathF.PI), // convert to degrees
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
