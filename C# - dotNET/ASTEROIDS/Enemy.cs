using Raylib_cs;
using System;
using System.Numerics;

namespace ASTEROIDS
{
    internal class Enemy : Entity
    {
        public float MaxSpeed = 1f;

        public Enemy(Vector2 position) : base(position, 0f)
        {
            velocity = new Vector2(0, 0);
        }

        public override void Update()
        {
            Vector2 direction = Program.PlayerPosition - position;
            direction = Vector2.Normalize(direction);
            velocity = direction * MaxSpeed;

            position += velocity;
        }

        public override void Draw()
        {
            Raylib.DrawCircleV(position, 20f, Color.Red);
        }
    }
}
