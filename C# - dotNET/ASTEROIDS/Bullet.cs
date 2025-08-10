using Raylib_cs;
using System.Numerics;

namespace ASTEROIDS
{
    internal class Bullet : Entity
    {
        public float Speed;

        public Bullet(Vector2 position, Vector2 direction, float speed)
            : base(new Transform(position), new Collision(5f))
        {
            Speed = speed;
            Transform.Velocity = Vector2.Normalize(direction) * 200f;
            Transform.WrapsAround = false; 
        }

        public override void Update()
        {
            Transform.Move();
        }

        public override void Draw()
        {
            Raylib.DrawCircleV(Transform.Position, 5f, Color.White);
        }

        public bool IsDead()
        {
            
            return Transform.Position.X < 0 || Transform.Position.X > Program.ScreenWidth ||
                   Transform.Position.Y < 0 || Transform.Position.Y > Program.ScreenHeight;
        }
    }
}
