using Raylib_cs;
using System.Numerics;

namespace ASTEROIDS
{
    internal class Enemy : Entity
    {
        public float MaxSpeed = 90f;

        public Enemy(Vector2 position)
            : base(new Transform(position), new Collision(20f)) 
        {
            Transform.Velocity = Vector2.Zero;
        }

        public override void Update()
        {
            Vector2 direction = Program.PlayerPosition - Transform.Position;
            if (direction != Vector2.Zero)
            {
                direction = Vector2.Normalize(direction);
                Transform.Velocity = direction * MaxSpeed;
            }

            Transform.Move();
        }

        public override void Draw()
        {
            Raylib.DrawCircleV(Transform.Position, 20f, Color.Red);
        }
    }
}
